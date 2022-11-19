using System;
using System.Data;
using KinUsers.Adapters;
using KinUsers.Models;
using MySqlConnector;

namespace KinUsers.Interfaces.Implementations
{
    public class MySQLImplementation : IPersistenceRetrieveEmployee
    {
        public List<EmployeeModel> getEmployees()
        {
            DataSet dataSet = connectionMysql("SELECT * FROM Users");
            return MySqlAdapter.MapEmployee(dataSet);
        }

        public List<EmployeeModel> getEmployeeByIdAndRegion(string Id)
        {
            DataSet dataSet = connectionMysql($"SELECT * FROM Users WHERE EmployeeId = {Id}");
            return MySqlAdapter.MapEmployee(dataSet);
        }

        private static DataSet connectionMysql(string query)
        {
            string server = "localhost";
            string bd = "userskin";
            string user = "root";
            string password = "password";
            string port = "33060";

            string strConnection = $"server={server}; port={port}; user id={user}; password={password}; database={bd};";

            MySqlConnection connectionBD = new MySqlConnection(strConnection);

            try
            {
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = connectionBD;
                connectionBD.Open();
                var dataSet = new DataSet();
                var dataAdapter = new MySqlDataAdapter(command);
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

