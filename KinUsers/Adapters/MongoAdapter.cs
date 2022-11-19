using System;
using KinUsers.Models;
using System.Data;
using MongoDB.Driver;

namespace KinUsers.Adapters
{
    public class MongoAdapter
    {
        public static List<EmployeeModel> MapEmployee(IMongoDatabase database, string? Id)
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            List<EmployeeMongoDBModel> employeesTable = new List<EmployeeMongoDBModel>();
            var getTableUsers = database.GetCollection<EmployeeMongoDBModel>("Users");
            if (Id == null)
            {
                employeesTable = getTableUsers.Find(d => true).ToList();
            } else
            {
                employeesTable = getTableUsers.Find(d => d.EmployeeId == (long)Convert.ToInt64(Id)).ToList();
            }

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

