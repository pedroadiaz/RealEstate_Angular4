using System;
using System.Collections.Generic;

namespace RealEstate_Angular4.models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public int? UserLoginId { get; set; }
    }
}
