
namespace EmployeesWebApplication.BusinessLogicLayer.Models
{
    public class EmployeeHourlyContract : Employee
    {
        public override long AnnualSalary => 120 * HourlySalary * 12;

    }
}
