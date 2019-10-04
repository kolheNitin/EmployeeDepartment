using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EmployeeManagement.MultiTenancy.Dto;

namespace EmployeeManagement.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

