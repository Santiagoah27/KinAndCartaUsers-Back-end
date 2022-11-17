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

    private static List<EmployeePostgresModel> connectionPostgres()
    {
            string server = "localhost";
            string bd = "userskin";
            string user = "postgres";
            string password = "password";
            string port = "54320";
            List<EmployeePostgresModel> data = new List<EmployeePostgresModel>();

            string strConnection = $"server={server}; port={port}; user id={user}; password={password}; database={bd};";

            NpgsqlConnection connectionBD = new NpgsqlConnection(strConnection);

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

                return data;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                connectionBD.Close();
            }
        }
    }
}

