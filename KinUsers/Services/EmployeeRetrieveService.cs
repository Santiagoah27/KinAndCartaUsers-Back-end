using System;
using KinUsers.Factories;
using KinUsers.Models;

namespace KinUsers.Services
{
    public class EmployeeRetrieveService
    {
        public List<EmployeeModel> getEmployeesByRegion(String region)
        {
            IPersistenceRetrieveEmployee employee = PersistenceRetrieveEmployeeCreator.createConnection(region);

            return employee.getEmployees();
        }

        public List<EmployeeModel> getEmployeesByRegionAndId(String region, string Id)
        {
            IPersistenceRetrieveEmployee employee = PersistenceRetrieveEmployeeCreator.createConnection(region);

            return employee.getEmployeeByIdAndRegion(Id);
        }
    }
}

