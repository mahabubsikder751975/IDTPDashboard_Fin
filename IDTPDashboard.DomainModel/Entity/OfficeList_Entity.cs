using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class OfficeList_Entity
    {
        public OfficeList_Entity()
        {
        }
        public List<Office> officeList { get; set; }
    }
    public class Office
    {
        public int id { get; set; }
        public string OfficeCode { get; set; }
        public string OfficeName { get; set; }
        public string Organization { get; set; }
    }
}
