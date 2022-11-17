using System;
namespace KinUsers.Models
{
    public class EmployeeModel
    {
        public long EmployeeIdentification { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? City { get; set; }

        public int TimeWorking { get; set; }
    }
}

