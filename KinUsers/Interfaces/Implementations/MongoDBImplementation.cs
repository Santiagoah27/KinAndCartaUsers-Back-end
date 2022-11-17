using System;
using KinUsers.Models;
using MySqlConnector;
using System.Data;
using MongoDB.Driver;

namespace KinUsers.Interfaces.Implementations
{
    public class MongoDBImplementation : IPersistenceRetrieveEmployee
    {
        public List<EmployeeModel> getEmployees()
        {
            //Connection to MySql
            connectionMongoDB();
            return new List<EmployeeModel>();

        }

        private void connectionMongoDB()
        {
            var client = new MongoClient("mongodb://localhost:27018");
            var database = client.GetDatabase("userskin");

            var getTableUsers = database.GetCollection<EmployeeMongoDBModel>("Users");
            List<EmployeeMongoDBModel> data = getTableUsers.Find(d => true).ToList();
            Console.WriteLine(data);
        }
    }

}

