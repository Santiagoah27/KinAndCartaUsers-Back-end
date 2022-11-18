using System;
using KinUsers.Factories;
using KinUsers.Models;

namespace KinUsers.Interfaces.Implementations
{
    public class AllConnection : IPersistenceRetrieveEmployee
    {
        public List<EmployeeModel> getEmployees()
        {
            string[] continents = { "America", "Asia", "Europa" };
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (var item in continents)
            {
                IPersistenceRetrieveEmployee db = PersistenceRetrieveEmployeeCreator.createConnection(item);
                List<EmployeeModel> dbEmployess = db.getEmployees();
                employees.AddRange(dbEmployess);
            }

            return employees;
        }

        public List<EmployeeModel> getEmployeeByIdAndRegion(string Id)
        {
            throw new NotImplementedException();
        }

    }
}

