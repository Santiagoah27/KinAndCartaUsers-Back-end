using System;
using KinUsers.Models;
using System.Data;
using MongoDB.Driver;

namespace KinUsers.Adapters
{
    public class MongoAdapter
    {
        public static List<EmployeeModel> MapEmployee(IMongoDatabase database)
        {
            var getTableUsers = database.GetCollection<EmployeeMongoDBModel>("Users");
            List<EmployeeModel> employees = new List<EmployeeModel>();
            List<EmployeeMongoDBModel> employeesTable = getTableUsers.Find(d => true).ToList();

            foreach (EmployeeMongoDBModel row in employeesTable)
            {
                var usersPostgres = new EmployeeModel();
                usersPostgres = new EmployeeModel();
                usersPostgres.EmployeeId = (int)row.EmployeeId;
                usersPostgres.FirstName = row.FirstName;
                usersPostgres.LastName = row.LastName;
                usersPostgres.Age = row.Age;
                usersPostgres.Address = row.Address;
                usersPostgres.Email = row.Email;
                usersPostgres.City = row.City;
                usersPostgres.TimeWorkingInCompany = row.TimeWorkingInCompany;
                employees.Add(usersPostgres);
            }
            return employees;
        }
    }
}

