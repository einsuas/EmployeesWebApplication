using System.Collections.Generic;
using System.Linq;
using EmployeesWebApplication.BusinessLogicLayer;
using EmployeesWebApplication.BusinessLogicLayer.Models;
using EmployeesWebApplication.BusinessLogicLayer.Utils;
using Xunit;

namespace XUnitTestEmployees
{
    public class TestBusinessLogic
    {
        [Fact]
        public async void TestGetAllEmployees()
        {
            await Manager.InitializeEmployees();
            var employees = Manager.EmployeeProcessor.GetEmployees();

            // Assert
            Assert.IsType<List<Employee>>(employees);
            Assert.Equal(2, employees.Count());
        }

        [Fact]
        public async void TestGetEmployee()
        {
            await Manager.InitializeEmployees();
            var idParam = 1;
            var employees = Manager.EmployeeProcessor.GetEmployees(idParam);

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Employee>>(employees);
            var collection = employees as Employee[] ?? employees.ToArray();
            Assert.Single(collection);
            Assert.Equal(idParam, collection.ElementAt(0).Id);
            Assert.Equal("Juan", collection.ElementAt(0).Name);
        }

        [Fact]
        public async void TestAnnualSalary()
        {
            await Manager.InitializeEmployees();
            var employees = Manager.EmployeeProcessor.GetEmployees();

            foreach (var employee in employees)
            {
                // Assert
                switch (employee.ContractTypeName)
                {
                    case ContractType.HourlySalary:
                        Assert.IsType<EmployeeHourlyContract>(employee);
                        Assert.Equal(employee.HourlySalary * 120 * 12, employee.AnnualSalary);
                        break;
                    case ContractType.MonthlySalary:
                        Assert.IsType<EmployeeMonthlyContract>(employee);
                        Assert.Equal(employee.MonthlySalary * 12, employee.AnnualSalary);
                        break;
                }
            }
        }

        [Fact]
        public async void TestFireEmployee()
        {
            await Manager.InitializeEmployees();
            var idParam = 2;
            Manager.EmployeeProcessor.DeleteEmployee(idParam);
            var allEmployees = Manager.EmployeeProcessor.GetEmployees();
            var singleEmployees = Manager.EmployeeProcessor.GetEmployees(idParam);

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Employee>>(allEmployees);
            var collection = allEmployees as Employee[] ?? allEmployees.ToArray();
            Assert.Single(collection);
            Assert.Equal(1, collection.ElementAt(0).Id);
            Assert.Equal("Juan", collection.ElementAt(0).Name);
            Assert.Empty(singleEmployees);
        }

        [Fact]
        public async void TestUpdateEmployee()
        {
            await Manager.InitializeEmployees();
            var idParam = 1;
            var singleEmployee = Manager.EmployeeProcessor.GetEmployees(idParam);

            var employee = singleEmployee.ElementAt(0);
            employee.Name = "Name1";
            employee.MonthlySalary = 0;
            employee.HourlySalary = 0;

            var response = Manager.EmployeeProcessor.UpdateEmployee(employee);

            singleEmployee = Manager.EmployeeProcessor.GetEmployees(idParam);

            // Assert
            Assert.True(response);
            var collection = singleEmployee as Employee[] ?? singleEmployee.ToArray();
            Assert.Single(collection);
            Assert.Equal(1, collection.ElementAt(0).Id);
            Assert.Equal("Name1", collection.ElementAt(0).Name);
            Assert.Equal(0, collection.ElementAt(0).AnnualSalary);
        }
    }
}
