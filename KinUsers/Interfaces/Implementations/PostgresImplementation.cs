using System;
using System.Data;
using System.Net;
using KinUsers.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using MySqlConnector;
using Npgsql;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;

namespace KinUsers.Interfaces.Implementations
{
    public class PostgresImplementation : IPersistenceRetrieveEmployee
    {
            public List<EmployeeModel> getEmployees()
            {
            //Connection to MySql
                connectionPostgres();
                return new List<EmployeeModel>();

            }

    private void connectionPostgres()
    {
            string server = "localhost";
            string bd = "userskin";
            string user = "postgres";
            string password = "password";
            string port = "54320";
            List<EmployeePostgresModel> data = new List<EmployeePostgresModel>();

            //Crearemos la cadena de conexión concatenando las variables
            string strConnection = $"server={server}; port={port}; user id={user}; password={password}; database={bd};";

            //Instancia para conexión a MySQL, recibe la cadena de conexión
            NpgsqlConnection connectionBD = new NpgsqlConnection(strConnection);

            //Agregamos try-catch para capturar posibles errores de conexión o sintaxis.
            try
            {
                string consulta = "SELECT * FROM Users";
                NpgsqlCommand command = new NpgsqlCommand(consulta);
                command.Connection = connectionBD;
                connectionBD.Open();
                var ds = new DataSet();
                var da = new NpgsqlDataAdapter(command);
                da.Fill(ds);
                var usersPostgres = new EmployeePostgresModel();


                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    usersPostgres = new EmployeePostgresModel();
                    usersPostgres.EmployeeId = (int)row["employeeid"];
                    usersPostgres.FirstName = (string?)row["firstname"];
                    usersPostgres.LastName = (string?)row["lastname"];
                    usersPostgres.Age = (int)row["age"];
                    usersPostgres.Address = (string?)row["address"];
                    usersPostgres.Email = (string?)row["email"];
                    usersPostgres.City = (string?)row["city"];
                    usersPostgres.TimeWorkingInCompany = (int)row["timeworkingincompany"];
                    data.Add(usersPostgres);
                }

                Console.WriteLine(data); //Imprime en cuadro de dialogo el resultado
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message); //Si existe un error aquí muestra el mensaje
            }
            finally
            {
                connectionBD.Close(); //Cierra la conexión a MySQL
            }
        }
    }
}

