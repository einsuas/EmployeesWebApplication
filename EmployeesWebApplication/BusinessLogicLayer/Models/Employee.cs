
using Newtonsoft.Json;

namespace EmployeesWebApplication.BusinessLogicLayer.Models
{
    public class Employee 
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ContractTypeName { get; set; }

        public long RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public long HourlySalary { get; set; }

        public long MonthlySalary { get; set; }

        public virtual long AnnualSalary { get; }

        public static Employee GetObjectFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Employee>(json); ;
        }
    }
}
