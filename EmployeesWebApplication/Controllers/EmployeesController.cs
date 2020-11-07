using System.Threading.Tasks;
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

        [HttpDelete]
        public bool Delete(long employeeId)
        {
            return Manager.EmployeeProcessor.DeleteEmployee(employeeId);
        }


        [HttpPost]
        [Route("UpdateEmployee")]
        public async Task<bool> UpdateEmployee()
        {
            var employee = Employee.GetObjectFromJson(await GetBodyAsText());
            return Manager.EmployeeProcessor.UpdateEmployee(employee);
        }

        protected async Task<string> GetBodyAsText()
        {
            using var reader = new System.IO.StreamReader(Request.Body);
            return await reader.ReadToEndAsync();
        }
    }
}
