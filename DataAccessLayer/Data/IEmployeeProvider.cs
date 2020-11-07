using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Data
{
    public interface IEmployeeProvider
    { 
        Task<List<EmployeeInfo>> LoadEmployees();
    }
}
