using System;
using System.Collections.Generic;

namespace RealEstate_Angular4.models
{
    public partial class CompanyBilling
    {
        public int CompanyBillingId { get; set; }
        public string BillingName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public decimal? Amount { get; set; }
        public int? BillingCycle { get; set; }
        public DateTime? NextDueDate { get; set; }
        public int? CompanyId { get; set; }
    }
}
