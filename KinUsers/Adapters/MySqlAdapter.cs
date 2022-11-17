using System;
using System.Data;
using KinUsers.Models;
using System.Linq;

namespace KinUsers.Adapters
{
    public class MySqlAdapter 
    {
        public static List<EmployeeModel> MapEmployee(DataSet dataSet)
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                var usersMysql = new EmployeeModel();
                usersMysql.EmployeeId = (int)row["EmployeeId"];
                usersMysql.FirstName = (string?)row["FirstName"];
                usersMysql.LastName = (string?)row["LastName"];
                usersMysql.Age = (int)row["Age"];
                usersMysql.Address = (string?)row["Address"];
                usersMysql.Email = (string?)row["Email"];
                usersMysql.City = (string?)row["City"];
                usersMysql.TimeWorkingInCompany = (int)row["TimeWorkingInCompany"];
                employees.Add(usersMysql);
            }
            return employees;
        }
    }
}

