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

           employees = employeesTable.Select(e => new EmployeeModel
           {
                EmployeeId = (int)e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Age = e.Age,
                Address = e.Address,
                Email = e.Email,
                City = e.City,
                TimeWorkingInCompany = e.TimeWorkingInCompany
           }).ToList();

        return employees;
        }
    }
}

