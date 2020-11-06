using System.Collections.Generic;
using DataAccessLayer.Models;
using EmployeesWebApplication.BusinessLogicLayer.Models;

namespace EmployeesWebApplication.BusinessLogicLayer
{
    public interface IEmployeeProcessor
    {
        void ProcessEmployees(List<EmployeeInfo> employeesInfo);

        List<Employee> GetEmployees(long? id = null);
    }


}
