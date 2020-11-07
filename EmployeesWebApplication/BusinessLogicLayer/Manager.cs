using System.Threading.Tasks;
using DataAccessLayer.Data;

namespace EmployeesWebApplication.BusinessLogicLayer
{
    public static class Manager
    {
        private static bool isInitialized;
        private static IEmployeeProvider _employeeProvider;
        public static EmployeeProcessor EmployeeProcessor;

        public static async Task InitializeEmployees()
        {
            if (!isInitialized)
            {
                _employeeProvider = new EmployeeProvider();
                var employeesInfo = await _employeeProvider.LoadEmployees();
                EmployeeProcessor = new EmployeeProcessor(employeesInfo);
                isInitialized = true;
            }
        }

    }
}
