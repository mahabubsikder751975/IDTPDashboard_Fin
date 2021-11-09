using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class HRManagement_Part2_Entity
    {
        public HRManagement_Part2_Entity()
        {
            SanctionedPostVacantPostList = new List<SanctionedPostVacantPost>();
            MaleFemaleEmployeeList = new List<MaleFemaleEmployee>();
            BackgroundWisePostList = new List<BackgroundWisePost>();
            ZoneWiseOfficeList = new List<ZoneWiseOffice>();
            //EmployeePerformanceList = new List<EmployeePerformance>();
        }
        public List<SanctionedPostVacantPost> SanctionedPostVacantPostList { get; set; }
        public List<MaleFemaleEmployee> MaleFemaleEmployeeList { get; set; }
        public List<BackgroundWisePost> BackgroundWisePostList { get; set; }
        public List<ZoneWiseOffice> ZoneWiseOfficeList { get; set; }
        //public List<EmployeePerformance> EmployeePerformanceList { get; set; }
    }
    public class SanctionedPostVacantPost
    {
        public string Post { get; set; }
        public int SanctionedPosts { get; set; }
        public int VacantPosts { get; set; }
        public int Order { get; set; }
    }
    public class MaleFemaleEmployee
    {
        public string Post { get; set; }
        public int MaleEmployee { get; set; }
        public int FemaleEmployee { get; set; }
        public int Order { get; set; }
    }

    public class BackgroundWisePost
    {
        public string PostType { get; set; }
        public int Engineering { get; set; }
        public int Admin_HR { get; set; }
        public int Finance { get; set; }
        public int IT { get; set; }
        public int Order { get; set; }
    }
    public class ZoneWiseOffice
    {
        public string Zone { get; set; }
        public int NoOfOffices { get; set; }
        public int Order { get; set; }
    }
}
