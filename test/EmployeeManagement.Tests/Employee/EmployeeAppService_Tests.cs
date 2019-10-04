using EmployeeManagement.Employee;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using EmployeeManagement.Users;
using EmployeeManagement.Users.Dto;
using EmployeeManagement.Employee.Dto;
using Abp.Domain.Repositories;
using EmployeeManagement.Core;

namespace EmployeeManagement.Tests.Employee
{
    public class EmployeeAppService_Tests : EmployeeManagementTestBase
    {
        private readonly IEmployeeAppService _employeeAppService;

        public EmployeeAppService_Tests()
        {
            _employeeAppService = Resolve<IEmployeeAppService>();
        }



       [Fact]
        public async Task GetEmployees_Test()
        {
            // Act
            var output = await _employeeAppService.GetEmployee();

            // Assert
            output.Message.ShouldBeSameAs("No Records Found");
        }

        [MultiTenantFact]
        public async Task CreateEmployee_Test()
        {
            // Act
            await _employeeAppService.AddEmployee(
                new EmployeeRequest
                {
                    DeptId = 1,
                    Name = "John"
                });

            // Assert
            var output = await _employeeAppService.GetEmployee();
            output.Object.LstEmployee.Count.ShouldBeGreaterThan(0);


        }
    }
}
