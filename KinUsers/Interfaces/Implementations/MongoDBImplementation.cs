using System;
using KinUsers.Models;
using MySqlConnector;
using System.Data;
using MongoDB.Driver;
using KinUsers.Adapters;

namespace KinUsers.Interfaces.Implementations
{
    public class MongoDBImplementation : IPersistenceRetrieveEmployee
    {
        public List<EmployeeModel> getEmployees()
        {
            IMongoDatabase dataBase = connectionMongoDB();
            return MongoAdapter.MapEmployee(dataBase, Id: null);
        }

        public List<EmployeeModel> getEmployeeByIdAndRegion(string Id)
        {
            IMongoDatabase dataBase = connectionMongoDB();
            return MongoAdapter.MapEmployee(dataBase, Id);
        }

        private static IMongoDatabase connectionMongoDB()
        {
            var client = new MongoClient("mongodb://localhost:27018");
            var database = client.GetDatabase("userskin");
            return database;
        }

    }

}

