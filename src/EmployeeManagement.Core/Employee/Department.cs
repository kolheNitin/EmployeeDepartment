using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace EmployeeManagement.Core
{
    [Table("Department")]
    public class DepartmentDB : FullAuditedEntity
    {

        public const int MaxNameLength = 32;

        [Required]
        [MaxLength(MaxNameLength)]
        public string DeptName { get; set; }

        public ICollection<EmployeeDB> Employee { get; set; }
    }
}
