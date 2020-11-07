
namespace EmployeesWebApplication.BusinessLogicLayer.Models
{
    public class EmployeeMonthlyContract : Employee
    {
        public override long AnnualSalary => MonthlySalary * 12;

    }
}
