using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace EmployeeManagement.Employee.Dto
{
    [DataContract]
    public class EmployeeRequest
    {
        [DataMember(EmitDefaultValue = false)]
        public int Eid { get; set; }

        string _name = null;
        [DataMember(EmitDefaultValue = false)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember(EmitDefaultValue = false)]
        public int DeptId { get; set; }
    }
}
