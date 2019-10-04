using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Domain.Repositories;
using EmployeeManagement.Authorization;
using EmployeeManagement.Core;
using EmployeeManagement.Employee.Dto;

namespace EmployeeManagement.Employee
{
    /// <summary>
    /// Added authorization to all api so only logged in user can access this api
    /// </summary>
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class EmployeeAppService : EmployeeManagementAppServiceBase, IEmployeeAppService
    {
        private readonly IRepository<EmployeeDB> _employeeDBRepository;
        private readonly IRepository<DepartmentDB> _deptDBRepository;

        public EmployeeAppService(IRepository<EmployeeDB> EmployeeDBRepository, IRepository<DepartmentDB> DepartmentDBRepository)
        {
            _employeeDBRepository = EmployeeDBRepository;
            _deptDBRepository = DepartmentDBRepository;
        }

        /// <summary>
        /// Add Department
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResult<string>> AddDepartment(DepartmenetRequest request)
        {
            ApiResult<string> Response = new ApiResult<string>();

            if (request != null )
            {
                DepartmentDB departmentDB = new DepartmentDB();

                departmentDB.DeptName = request.DeptName;
             
                Int64 cnt = await _deptDBRepository.InsertAndGetIdAsync(departmentDB);
                CurrentUnitOfWork.SaveChanges();

                if (cnt > 0)
                {
                    Response.Status = AppConsts.Success;
                    Response.Message = AppConsts.AddmsgDept;
                }
                else
                {
                    Response.Status = AppConsts.Fail;
                    Response.Message = AppConsts.Failmsg;
                }
            }
            else
            {
                Response.Status = AppConsts.Fail;
                Response.Message = AppConsts.inputmsg;

            }
            CurrentUnitOfWork.SaveChanges();
            return Response;
        }

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResult<string>> AddEmployee(EmployeeRequest request)
        {
            ApiResult<string> Response = new ApiResult<string>();

            if (request != null)
            {
                EmployeeDB employeeDB = new EmployeeDB();

                employeeDB.Name = request.Name;
                employeeDB.DeptIdFK = request.DeptId;

                Int64 cnt = await _employeeDBRepository.InsertAndGetIdAsync(employeeDB);
                CurrentUnitOfWork.SaveChanges();

                if (cnt > 0)
                {
                    Response.Status = AppConsts.Success;
                    Response.Message = AppConsts.AddmsgEmp;
                }
                else
                {
                    Response.Status = AppConsts.Fail;
                    Response.Message = AppConsts.Failmsg;
                }
            }
            else
            {
                Response.Status = AppConsts.Fail;
                Response.Message = AppConsts.inputmsg;

            }

            return Response;
        }

        public async Task<ApiResult<string>> DeleteEmployee(int EmployeeId)
        {
            ApiResult<string> Response = new ApiResult<string>();

            if (EmployeeId > 0)
            {
                var employee = _employeeDBRepository.GetAll().Where(x => x.Id == EmployeeId).SingleOrDefault();
                if (employee != null)
                {
                    await _employeeDBRepository.DeleteAsync(employee);
                    _ = CurrentUnitOfWork.SaveChangesAsync();
                    Response.Status = AppConsts.Success;
                    Response.Message = AppConsts.DeletemsgEmp;
                }
                else
                {
                    Response.Status = AppConsts.Fail;
                    Response.Message = AppConsts.Failmsg;
                }
            }
            else
            {
                Response.Status = AppConsts.Fail;
                Response.Message = AppConsts.inputmsg;
            }

            return Response;
        }

        /// <summary>
        /// Get all departement List
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResult<DepartmentResponseModel>> GetDepartment()
        {
            ApiResult<DepartmentResponseModel> apiResult = new ApiResult<DepartmentResponseModel>();
            List<DepartmentResponse> deptResponse = new List<DepartmentResponse>();

            var departments = await _deptDBRepository.GetAllListAsync();

            if (departments.Count() > 0)
            {
                foreach (var item in departments)
                {
                    DepartmentResponse DepartmentR = new DepartmentResponse
                    {
                        Id = item.Id,
                        DeptName = item.DeptName
                    };
                    deptResponse.Add(DepartmentR);
                }
                apiResult.Object = new DepartmentResponseModel();
                apiResult.Object.LstDept = deptResponse;
                apiResult.Status = AppConsts.Success;
            }
            else
            {
                apiResult.Status = AppConsts.Fail;
                apiResult.Message = AppConsts.norecmsg;
            }

            return apiResult;
        }

        /// <summary>
        /// Get all employee list
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResult<EmployeeResponseModel>> GetEmployee()
        {
            ApiResult<EmployeeResponseModel> apiResult = new ApiResult<EmployeeResponseModel>();
            List<EmployeeResponse> EmpResponse = new List<EmployeeResponse>();

            var employees = await _employeeDBRepository.GetAllListAsync();

            if (employees.Count() > 0)
            {
                foreach (var item in employees)
                {
                    EmployeeResponse EmployeeR = new EmployeeResponse
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DeptName = item.Department?.DeptName
                    };
                    EmpResponse.Add(EmployeeR);
                }
                apiResult.Object = new EmployeeResponseModel
                {
                    LstEmployee = EmpResponse
                };
                apiResult.Status = AppConsts.Success;
            }
            else
            {
                apiResult.Status = AppConsts.Fail;
                apiResult.Message = AppConsts.norecmsg;
            }

            return apiResult;
        }

        public async Task<ApiResult<string>> UpdateEmployee(EmployeeRequest request)
        {
            ApiResult<string> Response = new ApiResult<string>();

            if (request != null)
            {
                var contacts = _employeeDBRepository.GetAll().Where(x => x.Id == request.Eid).SingleOrDefault(); // Check Given id exits or not
                if (contacts != null)
                {
                    EmployeeDB employee = new EmployeeDB();

                    employee.Name = request.Name;
                    employee.DeptIdFK = request.DeptId;
                   
                    Int64 cnt = await _employeeDBRepository.InsertOrUpdateAndGetIdAsync(employee);
                    CurrentUnitOfWork.SaveChanges();

                    if (cnt > 0)
                    {
                        Response.Status = AppConsts.Success;
                        Response.Message = AppConsts.Updatemsg;
                    }
                    else
                    {
                        Response.Status = AppConsts.Fail;
                        Response.Message = AppConsts.Failmsg;
                    }
                }
                else
                {
                    Response.Status = AppConsts.Fail;
                    Response.Message = AppConsts.Failmsg;
                }
            }
            else
            {
                Response.Status = AppConsts.Fail;
                Response.Message = AppConsts.inputmsg;
            }

            return Response;
        }
    }
}
