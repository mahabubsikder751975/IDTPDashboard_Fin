using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class Menu_Entity
    {
        public string Organization { get; set; }
        public string MenuName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int MenuOrder { get; set; }
        public bool Status { get; set; }
    }
}
