using System;
using System.Collections.Generic;

namespace RealEstate_Angular4.models
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSite { get; set; }
        public DateTime? Created { get; set; }
        public int? EmployeeId { get; set; }
    }
}
