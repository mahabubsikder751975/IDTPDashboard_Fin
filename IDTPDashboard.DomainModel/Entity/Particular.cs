using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class Particular
    {
        public int Id { get; set; }
        public string ParticularName { get; set; }
        public string CurrentStatus { get; set; }       
        public DateTime LastUpdatedDate { get; set; }       
        
    }
}
