using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Core
{
    [Table("Employee")]
    public class EmployeeDB : FullAuditedEntity
    {
        public const int MaxNameLength = 32;
        
        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string Name { get; set; }


        public int DeptIdFK { get; set; }
        [ForeignKey("DeptIdFK")]
        public DepartmentDB Department { get; set; }




    }
}
