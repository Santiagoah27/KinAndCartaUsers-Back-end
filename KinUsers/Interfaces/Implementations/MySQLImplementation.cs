using System;
using System.Data;
using KinUsers.Models;
using MySqlConnector;

namespace KinUsers.Interfaces.Implementations
{
    public class MySQLImplementation : IPersistenceRetrieveEmployee
    {
        public List<EmployeeModel> getEmployees()
        {
            //Connection to MySql
            List<EmployeeModel> mysqlEmployees = connectionMysql();

            return new List<EmployeeModel>();
            
        }

        private static List<EmployeeModel> connectionMysql()
        {
            string server = "localhost";
            string bd = "userskin";
            string user = "root";
            string password = "password";
            string port = "33060";
            List<EmployeeModel> employees = new List<EmployeeModel>();

            string strConnection = $"server={server}; port={port}; user id={user}; password={password}; database={bd};";

            MySqlConnection connectionBD = new MySqlConnection(strConnection);

            try
            {
                string consulta = "SELECT * FROM Users";
                MySqlCommand command = new MySqlCommand(consulta);
                command.Connection = connectionBD;
                connectionBD.Open();
                var ds = new DataSet();
                var da = new MySqlDataAdapter(command);
                da.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var usersMysql = new EmployeeModel();
                    usersMysql.EmployeeId = (int)row["EmployeeId"];
                    usersMysql.FirstName = (string?)row["FirstName"];
                    usersMysql.LastName = (string?)row["LastName"];
                    usersMysql.Age = (int)row["Age"];
                    usersMysql.Address = (string?)row["Address"];
                    usersMysql.Email = (string?)row["Email"];
                    usersMysql.City = (string?)row["City"];
                    usersMysql.TimeWorkingInCompany = (int)row["TimeWorkingInCompany"];
                    employees.Add(usersMysql);
                }

                return employees; //Imprime en cuadro de dialogo el resultado
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message); //Si existe un error aquí muestra el mensaje
                throw;
            }
            finally
            {
                connectionBD.Close(); //Cierra la conexión a MySQL
            }
        }

    }
}

