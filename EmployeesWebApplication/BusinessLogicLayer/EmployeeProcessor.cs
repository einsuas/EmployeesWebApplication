using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccessLayer.Models;
using EmployeesWebApplication.BusinessLogicLayer.Models;
using EmployeesWebApplication.BusinessLogicLayer.Utils;

namespace EmployeesWebApplication.BusinessLogicLayer
{
    public class EmployeeProcessor : IEmployeeProcessor
    {
        private static List<Employee> employeeRepository = new List<Employee>();
        private readonly IMapper _mapper;

        public EmployeeProcessor(List<EmployeeInfo> employeesInfo)
        {
            var mapConfig = new MapperConfiguration(m =>
            {
                m.CreateMap<EmployeeInfo, EmployeeMonthlyContract>();
                m.CreateMap<EmployeeInfo, EmployeeHourlyContract>();
            });
            _mapper = mapConfig.CreateMapper();

            ProcessEmployees(employeesInfo);
        }


        public void ProcessEmployees(List<EmployeeInfo> employeesInfo)
        {
            foreach (var employee in employeesInfo)
            {
                switch (employee.ContractTypeName)
                {
                    case ContractType.HourlySalary:
                        employeeRepository.Add(_mapper.Map<EmployeeHourlyContract>(employee));
                        break;
                    case ContractType.MonthlySalary:
                        employeeRepository.Add(_mapper.Map<EmployeeMonthlyContract>(employee));
                        break;
                }
            }
        }

        public List<Employee> GetEmployees(long? id = null)
        {
            var employees = new List<Employee>();
            if (id != null)
            {
                var employee = employeeRepository.FirstOrDefault(e => e.Id == id);
                if (employee != null)
                    employees.Add(employee);
            }
            else
            {
                return employeeRepository;
            }

            return employees;
        }
    }


}
