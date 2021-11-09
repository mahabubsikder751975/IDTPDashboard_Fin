using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class UserSetting
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }       
    }
}
