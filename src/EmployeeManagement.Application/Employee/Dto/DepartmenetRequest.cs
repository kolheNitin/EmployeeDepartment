using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace EmployeeManagement.Employee.Dto
{
    public class DepartmenetRequest
    {
        string _deptname = null;
        [DataMember(EmitDefaultValue = false)]
        public string DeptName
        {
            get { return _deptname; }
            set { _deptname = value; }
        }
    }
}
