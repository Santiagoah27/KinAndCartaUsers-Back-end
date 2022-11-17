using System;
using KinUsers.Models;
using System.Data;

namespace KinUsers.Adapters
{
    public class PostgresAdapter
    {
        public static List<EmployeeModel> MapEmployee(DataSet dataSet)
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                var usersPostgres = new EmployeeModel();
                usersPostgres = new EmployeeModel();
                usersPostgres.EmployeeId = (int)row["employeeid"];
                usersPostgres.FirstName = (string?)row["firstname"];
                usersPostgres.LastName = (string?)row["lastname"];
                usersPostgres.Age = (int)row["age"];
                usersPostgres.Address = (string?)row["address"];
                usersPostgres.Email = (string?)row["email"];
                usersPostgres.City = (string?)row["city"];
                usersPostgres.TimeWorkingInCompany = (int)row["timeworkingincompany"];
                employees.Add(usersPostgres);
            }
            return employees;
        }
    }
}

