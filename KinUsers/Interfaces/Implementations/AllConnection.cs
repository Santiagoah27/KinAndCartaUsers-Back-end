using System;
using KinUsers.Factories;
using KinUsers.Models;

namespace KinUsers.Interfaces.Implementations
{
    public class AllConnection : IPersistenceRetrieveEmployee
    {
        public List<EmployeeModel> getEmployees()
        {
            IPersistenceRetrieveEmployee mysql = PersistenceRetrieveEmployeeCreator.createConnection("America");
            List<EmployeeModel> mysqlEmployees = mysql.getEmployees();
            IPersistenceRetrieveEmployee postgres = PersistenceRetrieveEmployeeCreator.createConnection("Asia");
            List<EmployeeModel> postgresEmployees = postgres.getEmployees();
            IPersistenceRetrieveEmployee mongo = PersistenceRetrieveEmployeeCreator.createConnection("Europa");
            List<EmployeeModel> mongoEmployees = mongo.getEmployees();
            return (List<EmployeeModel>)mysqlEmployees.Concat(postgresEmployees).Concat(mongoEmployees);
        }

    }
}

