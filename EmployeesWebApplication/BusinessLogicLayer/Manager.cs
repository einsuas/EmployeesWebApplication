using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;

namespace EmployeesWebApplication.BusinessLogicLayer
{
    public static class Manager
    {
        private static EmployeeProvider _employeeProvider;
        public static EmployeeProcessor EmployeeProcessor;

        public static async void InitializeEmployees()
        {
            _employeeProvider = new EmployeeProvider();
            var employeesInfo = await _employeeProvider.LoadEmployees();
            EmployeeProcessor = new EmployeeProcessor(employeesInfo);
        }

    }
}
