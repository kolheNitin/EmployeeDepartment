using Abp.Application.Services;
using Abp.Dependency;
using EmployeeManagement.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Employee
{
    public interface IEmployeeAppService : IApplicationService
    {
        Task<ApiResult<string>> AddEmployee(EmployeeRequest request);

        Task<ApiResult<string>> UpdateEmployee(EmployeeRequest request);

        Task<ApiResult<string>> DeleteEmployee(int EmpId);

        Task<ApiResult<EmployeeResponseModel>> GetEmployee();

          Task<ApiResult<DepartmentResponseModel>> GetDepartment();

        Task<ApiResult<string>> AddDepartment(DepartmenetRequest request);

    }
}
