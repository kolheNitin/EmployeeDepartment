using System;
using System.Runtime.Serialization;

namespace EmployeeManagement.Employee.Dto
{
    [DataContract]
    public class ApiResult<T>
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public T Object { get; set; }
        [DataMember]
        public string Error { get; set; }
        [DataMember]
        public string ErrorCode { get; set; }
    }
}
