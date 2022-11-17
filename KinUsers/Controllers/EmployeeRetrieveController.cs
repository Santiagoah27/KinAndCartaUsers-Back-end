using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KinUsers.Models;
using Microsoft.AspNetCore.Mvc;
using KinUsers.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KinUsers.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmployeeRetrieveController : ControllerBase
    {
       [HttpGet]
       [Route("users/{region}")]
       public List<EmployeeModel> getEmployeesByRegion(string region)
        {
            var Service = new EmployeeRetrieveService();
            return Service.getEmployeesByRegion(region);
        }

    }
}

