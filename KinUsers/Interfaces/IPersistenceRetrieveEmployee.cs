using System;
using KinUsers.Models;

namespace KinUsers
{
    public interface IPersistenceRetrieveEmployee
    {
        public List<EmployeeModel> getEmployees();
        public List<EmployeeModel> getEmployeeByIdAndRegion(string Id);
    }
}

