using System.Collections.Generic;
using DataAccessLayer.Models;
using EmployeesWebApplication.BusinessLogicLayer.Models;

namespace EmployeesWebApplication.BusinessLogicLayer
{
    public interface IEmployeeProcessor
    {
        void ProcessEmployees(IEnumerable<EmployeeInfo> employeesInfo);

        IEnumerable<Employee> GetEmployees(long? id = null);

        public bool DeleteEmployee(long id);

        public bool UpdateEmployee(Employee employee);
    }
}
