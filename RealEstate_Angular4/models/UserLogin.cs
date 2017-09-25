using System;
using System.Collections.Generic;

namespace RealEstate_Angular4.models
{
    public partial class UserLogin
    {
        public int UserLoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? PermissionLevel { get; set; }
    }
}
