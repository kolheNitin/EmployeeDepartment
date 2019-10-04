using Abp.Zero.EntityFrameworkCore;
using EmployeeManagement.Authorization.Roles;
using EmployeeManagement.Authorization.Users;
using EmployeeManagement.Core;
using EmployeeManagement.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.EntityFrameworkCore
{
    public class EmployeeManagementDbContext : AbpZeroDbContext<Tenant, Role, User, EmployeeManagementDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<EmployeeDB> Employees { get; set; }
        public DbSet<DepartmentDB> Departments { get; set; }


        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options)
            : base(options)
        {
        }
    }
}
