using System;
using System.Data;
using System.Net;
using KinUsers.Adapters;
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
            DataSet dataSet = connectionPostgres("SELECT * FROM Users"); 
            return PostgresAdapter.MapEmployee(dataSet);
        }

        public List<EmployeeModel> getEmployeeByIdAndRegion(string Id)
        {
            throw new NotImplementedException();
        }

        private static DataSet connectionPostgres(string query)
    {
            string server = "localhost";
            string bd = "userskin";
            string user = "postgres";
            string password = "password";
            string port = "54320";

            string strConnection = $"server={server}; port={port}; user id={user}; password={password}; database={bd};";

            NpgsqlConnection connectionBD = new NpgsqlConnection(strConnection);

            try
            {
                NpgsqlCommand command = new NpgsqlCommand(query);
                command.Connection = connectionBD;
                connectionBD.Open();
                var dataSet = new DataSet();
                var dataAdapter = new NpgsqlDataAdapter(command);
                dataAdapter.Fill(dataSet);

                return dataSet;
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

