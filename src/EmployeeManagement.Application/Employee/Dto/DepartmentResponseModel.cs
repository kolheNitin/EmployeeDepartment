using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeeManagement.Employee.Dto
{
    public class DepartmentResponseModel
    {
        List<DepartmentResponse> _lstDept = new List<DepartmentResponse>();
        [DataMember(EmitDefaultValue = false)]
        public List<DepartmentResponse> LstDept
        {
            get { return _lstDept; }
            set { _lstDept = value; }
        }
    }

    public class DepartmentResponse
    {
        int? _id = null;
        [DataMember(EmitDefaultValue = false)]
        public int? Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string _deptname = null;
        [DataMember(EmitDefaultValue = false)]
        public string DeptName
        {
            get { return _deptname; }
            set { _deptname = value; }
        }

       
    }
}
