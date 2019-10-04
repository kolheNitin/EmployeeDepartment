using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EmployeeManagement.Employee.Dto
{
    public class EmployeeResponseModel
    {
        List<EmployeeResponse> _lstEmployee = new List<EmployeeResponse>();
        [DataMember(EmitDefaultValue = false)]
        public List<EmployeeResponse> LstEmployee
        {
            get { return _lstEmployee; }
            set { _lstEmployee = value; }
        }
    }

    [DataContract]
    public class EmployeeResponse
    {
        int? _id = null;
        [DataMember(EmitDefaultValue = false)]
        public int? Id
        {
            get { return _id; }
            set { _id = value; }
        }

        string _name = null;
        [DataMember(EmitDefaultValue = false)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        string _deptname = null;
        [DataMember(EmitDefaultValue = false)]
        public string DeptName
        {
            get { return _deptname; }
            set { _deptname = value; }
        }

        int? _deptid = null;
        [DataMember(EmitDefaultValue = false)]
        public int? DeptId
        {
            get { return _deptid; }
            set { _deptid = value; }
        }
    }
}
