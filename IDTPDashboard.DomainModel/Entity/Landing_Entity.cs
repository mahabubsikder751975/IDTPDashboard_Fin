using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class Landing_Entity
    {
        public Landing_Entity()
        {
        }
        public List<TotalPowerPlant> TotalPowerPlantList { get; set; }
        public List<TotalInstalledCapacityMW> TotalInstalledCapacityMWList { get; set; }
        public List<TotalEmployeeByStatus> TotalEmployeeByStatusesList { get; set; }
        public List<TotalExpenceRevenue> TotalExpenceRevenuesList { get; set; }       
        public List<APPUtilizedUnutilized> appUtilizedUnutilizedList { get; set; }
        public List<AccReceivableAndPayable> AccReceivableAndPayableList { get; set; }
        public List<FinancialPosition> FinancialPositionList { get; set; }

    }
    public class TotalPowerPlant
    {
        public string Type { get; set; }
        public int Number { get; set; }        
    }
    public class TotalInstalledCapacityMW
    {
        public string Type { get; set; }
        public long InstalledCapacityMW { get; set; }        
    }
    public class TotalEmployeeByStatus
    {
        public string Type { get; set; }
        public long EmployeeCount { get; set; }
    }
    public class TotalExpenceRevenue
    {
        public string Type { get; set; }
        public long Amount { get; set; }
    }
    public class APPUtilizedUnutilized
    {
        public string Type { get; set; }
        public long Amount { get; set; }
    }
    public class AccReceivableAndPayable
    {
        public string Type { get; set; }
        public long Amount { get; set; }
    }
    public class FinancialPosition
    {
        public string AccountCategory { get; set; }
        public long Value { get; set; }
    }
}
