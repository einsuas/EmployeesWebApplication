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
        private List<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeProcessor(IEnumerable<EmployeeInfo> employeesInfo)
        {
            var mapConfig = new MapperConfiguration(m =>
            {
                m.CreateMap<EmployeeInfo, EmployeeMonthlyContract>();
                m.CreateMap<EmployeeInfo, EmployeeHourlyContract>();
            });
            _mapper = mapConfig.CreateMapper();
             
            ProcessEmployees(employeesInfo);
        }

        public void ProcessEmployees(IEnumerable<EmployeeInfo> employeesInfo)
        {
            _employeeRepository = new List<Employee>();
            foreach (var employee in employeesInfo)
            {
                switch (employee.ContractTypeName)
                {
                    case ContractType.HourlySalary:
                        _employeeRepository.Add(_mapper.Map<EmployeeHourlyContract>(employee));
                        break;
                    case ContractType.MonthlySalary:
                        _employeeRepository.Add(_mapper.Map<EmployeeMonthlyContract>(employee));
                        break;
                }
            }
        }

        public IEnumerable<Employee> GetEmployees(long? id = null)
        {
            var employees = new List<Employee>();
            if (id != null)
            {
                var employee = _employeeRepository.FirstOrDefault(e => e.Id == id);
                if (employee != null)
                    employees.Add(employee);
            }
            else
            {
                return _employeeRepository;
            }

            return employees;
        }

        public bool DeleteEmployee(long id)
        {
            var result = false; 
            var employee = _employeeRepository.Find( e=> e.Id == id);
            if (employee != null)
            {
                _employeeRepository.Remove(employee);
                result = true;
            }
            return result;
        }

        public bool UpdateEmployee(Employee employee)
        {
            var result = false;
            var existingEmployee = _employeeRepository.FirstOrDefault( e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                if (existingEmployee.Name != employee.Name)
                    existingEmployee.Name = employee.Name;
                if (existingEmployee.RoleDescription != employee.RoleDescription)
                    existingEmployee.RoleDescription = employee.RoleDescription;
                if (existingEmployee.RoleName != employee.RoleName)
                    existingEmployee.RoleName = employee.RoleName;
                if (existingEmployee.HourlySalary != employee.HourlySalary)
                    existingEmployee.HourlySalary = employee.HourlySalary;
                if (existingEmployee.MonthlySalary != employee.MonthlySalary)
                    existingEmployee.MonthlySalary = employee.MonthlySalary;
                result = true;
            }

            return result;
        }
    }


}
