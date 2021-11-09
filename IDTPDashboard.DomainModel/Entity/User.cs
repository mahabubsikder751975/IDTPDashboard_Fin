using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string OfficeCode { get; set; }
        public string OfficeName { get; set; }
        public string PbsName { get; set; }
        public string Role { get; set; }
    }
}
