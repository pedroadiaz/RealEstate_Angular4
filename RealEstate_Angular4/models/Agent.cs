using System;
using System.Collections.Generic;

namespace RealEstate_Angular4.models
{
    public partial class Agent
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string AgentImage { get; set; }
        public string Email { get; set; }
        public int? CompanyId { get; set; }
        public int? UserLoginId { get; set; }
    }
}
