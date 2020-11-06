using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using EmployeesWebApplication.BusinessLogicLayer;
using EmployeesWebApplication.BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EmployeesWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get( long? employeeId)
        {
            return JsonConvert.SerializeObject(Manager.EmployeeProcessor.GetEmployees(employeeId));
        }
    }
}
