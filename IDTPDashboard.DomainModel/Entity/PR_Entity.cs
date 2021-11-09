using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class PR_Entity
    {
        public PR_Entity()
        {
        }
        public List<ProcurementTrend> ProcurementTrendList { get; set; }
        public List<TopProcuredItemsbyOffice> TopProcuredItemsbyOfficeList { get; set; }
        public List<ProcurementValuebyOffice> ProcurementValuebyOfficeList { get; set; }
        public List<ProcurementTypebyOffice> ProcurementTypebyOfficeList { get; set; }
        public List<ProcurementStatus> ProcurementStatusList { get; set; }
        public List<AppUtilization> AppUtilizationList { get; set; }
        public List<RequisitionStatus> RequisitionStatusList { get; set; }

    }
    public class ProcurementTrend
    {
        public string Organization { get; set; }
        public string   Year { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
    }
    public class TopProcuredItemsbyOffice
    {
        public string Organization { get; set; }
        public string OfficeName { get; set; }
        public long CopperCable11KV { get; set; }
        public long CopperCable33KV { get; set; }
        public long MeterSeal { get; set; }
        public int SequenceNo { get; set; }
    }
    public class ProcurementValuebyOffice
    {
        public string Organization { get; set; }
        public string OfficeName { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
    }
    public class ProcurementTypebyOffice
    {
        public string Organization { get; set; }
        public string OfficeName { get; set; }
        public long eGP { get; set; }
        public long OTM { get; set; }
        public long DPM { get; set; }
        public long SpotQuotation { get; set; }
        public int SequenceNo { get; set; }
    }
    public class ProcurementStatus
    {
        public string Organization { get; set; }
        public long Completed { get; set; }
        public long OnGoing { get; set; }
        public long NotInitiated { get; set; }
    }
    public class AppUtilization
    {
        public string Organization { get; set; }
        public long Unutilized { get; set; }
        public long Utilized { get; set; }
    }
    public class RequisitionStatus
    {
        public string Organization { get; set; }
        public long POIssued { get; set; }
        public long POPending { get; set; }
    }
}
