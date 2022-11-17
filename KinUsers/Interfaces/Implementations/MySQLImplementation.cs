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
            connectionMysql();
            return new List<EmployeeModel>();
            
        }

        private void connectionMysql()
        {
            string server = "localhost";
            string bd = "userskin";
            string user = "root";
            string password = "password";
            string port = "33060";
            List<EmployeeMySQLModel> data = new List<EmployeeMySQLModel>();

            //Crearemos la cadena de conexión concatenando las variables
            string strConnection = $"server={server}; port={port}; user id={user}; password={password}; database={bd};";

            //Instancia para conexión a MySQL, recibe la cadena de conexión
            MySqlConnection connectionBD = new MySqlConnection(strConnection);

            //Agregamos try-catch para capturar posibles errores de conexión o sintaxis.
            try
            {
                string consulta = "SELECT * FROM Users";
                MySqlCommand command = new MySqlCommand(consulta);
                command.Connection = connectionBD;
                connectionBD.Open();
                var ds = new DataSet();
                var da = new MySqlDataAdapter(command);
                da.Fill(ds);
                var usersMysql = new EmployeeMySQLModel();


                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    usersMysql = new EmployeeMySQLModel();
                    usersMysql.EmployeeId = (int)row["EmployeeId"];
                    usersMysql.FirstName = (string?)row["FirstName"];
                    usersMysql.LastName = (string?)row["LastName"];
                    usersMysql.Age = (int)row["Age"];
                    usersMysql.Address = (string?)row["Address"];
                    usersMysql.Email = (string?)row["Email"];
                    usersMysql.City = (string?)row["City"];
                    usersMysql.TimeWorkingInCompany = (int)row["TimeWorkingInCompany"];
                    data.Add(usersMysql);
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

