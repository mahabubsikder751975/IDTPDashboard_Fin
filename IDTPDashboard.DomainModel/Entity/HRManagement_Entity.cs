using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity 
{
    public class HRManagement_Entity
    {
        public HRManagement_Entity()
        {
            EmployeeAttendanceList = new List<EmployeeAttendance>();
            EmployeeOnLeaveList = new List<EmployeeOnLeave>();
            RTPStatusByFIList = new List<RTPStatusByFI>();
            UpcommingRetirementList = new List<UpcommingRetirement>();
            EmployeePerformanceList = new List<EmployeePerformance>();
            TransactionsSettledUnsettledList = new List<TransactionsSettledUnsettled>();
            TransactionCountByTypeList = new List<TransactionCountByType>();
            NetDebitCapPositionByFIList = new List<NetDebitCapPositionByFI>();
            RegisteredUsersByFIList = new List<RegisteredUsersByFI>();
            TransactionsAmountTodayByFIList = new List<TransactionsAmountTodayByFI>();
            RTPStatusByFIUtilityWiseList = new List<RTPStatusByFIUtilityWise>();
            TotalNumberOfUsersList = new List<TotalNumberOfUsers>();
            ForeignTourCategoryWiseList = new List<ForeignTourCategoryWise>();
            ForeignTourPurposeWiseOfficialList = new List<ForeignTourPurposeWiseOfficial>();
            ForeignTourPurposeWisePersonalList = new List<ForeignTourPurposeWisePersonal>();
            TransactionsCountTodayByFIList = new List<TransactionsCountTodayByFI>();
            UtilitywiseLastFiscalYearSalaryList = new List<UtilitywiseLastFiscalYearSalary>();
            OrgPostWiseEmpList = new List<OrgPostWiseEmp>();
            OrgPostWiseUpcommingRetirmentList = new List<OrgPostWiseUpcommingRetirment>();
            OrgWiseEmpByJobStatusList = new List<OrgWiseEmpByJobStatus>();
            OrgWiseEmpByQualificationList = new List<OrgWiseEmpByQualification>();
            OrgWiseNetDebitCapPositionByFIList = new List<OrgWiseNetDebitCapPositionByFI>();
            DesignationWiseEmpByJobTypeAndOrgList = new List<DesignationWiseEmpByJobTypeAndOrg>();
            DesignationWiseEmpByQualificationAndOrgList = new List<DesignationWiseEmpByQualificationAndOrg>();
            TransactionAmountBySettlementCycleIdList = new List<TransactionAmountBySettlementCycleId>();
            TransactionCountBySettlementTimeList = new List<TransactionCountBySettlementTime>();
            FailedTransactionCountByFIList = new List<FailedTransactionCountByFI>();
        }
        public List<TransactionAmountBySettlementCycleId> TransactionAmountBySettlementCycleIdList { get; set; }

        public List<TransactionCountBySettlementTime> TransactionCountBySettlementTimeList { get; set; }

        public List<FailedTransactionCountByFI> FailedTransactionCountByFIList { get; set; }
        public List<EmployeeAttendance> EmployeeAttendanceList { get; set; }
        public List<EmployeeOnLeave> EmployeeOnLeaveList { get; set; }
        public List<RTPStatusByFI> RTPStatusByFIList { get; set; }
        public List<UpcommingRetirement> UpcommingRetirementList { get; set; }
        public List<EmployeePerformance> EmployeePerformanceList { get; set; }
        public List<TransactionsSettledUnsettled> TransactionsSettledUnsettledList { get; set; }
        public List<TransactionCountByType> TransactionCountByTypeList { get; set; }
        public List<NetDebitCapPositionByFI> NetDebitCapPositionByFIList { get; set; }
        public List<RegisteredUsersByFI> RegisteredUsersByFIList { get; set; }
        public List<TransactionsAmountTodayByFI> TransactionsAmountTodayByFIList { get; set; }
        public List<RTPStatusByFIUtilityWise> RTPStatusByFIUtilityWiseList { get; set; }
        public List<TotalNumberOfUsers> TotalNumberOfUsersList { get; set; }
        public List<ForeignTourCategoryWise> ForeignTourCategoryWiseList { get; set; }
        public List<ForeignTourPurposeWiseOfficial> ForeignTourPurposeWiseOfficialList { get; set; }
        public List<ForeignTourPurposeWisePersonal> ForeignTourPurposeWisePersonalList { get; set; }
        public List<TransactionsCountTodayByFI> TransactionsCountTodayByFIList { get; set; }
        public List<UtilitywiseLastFiscalYearSalary> UtilitywiseLastFiscalYearSalaryList { get; set; }
        public List<OrgPostWiseEmp> OrgPostWiseEmpList { get; set; }
        public List<OrgPostWiseUpcommingRetirment> OrgPostWiseUpcommingRetirmentList { get; set; }
        public List<DesignationWiseEmpCount> DesignationWiseEmpCountList { get; set; }
        public List<OrgWiseEmpByJobStatus> OrgWiseEmpByJobStatusList { get; set; }
        public List<OrgWiseEmpByQualification> OrgWiseEmpByQualificationList { get; set; }
        public List<OrgWiseNetDebitCapPositionByFI> OrgWiseNetDebitCapPositionByFIList { get; set; }
        public List<DesignationWiseEmpByJobTypeAndOrg> DesignationWiseEmpByJobTypeAndOrgList { get; set; }
        public List<DesignationWiseEmpByQualificationAndOrg> DesignationWiseEmpByQualificationAndOrgList { get; set; }
    }
    public class EmployeeAttendance
    {
        public string PostType { get; set; }
        public int Present { get; set; }
        public int Absent { get; set; }
        public int SequenceNo { get; set; }
    }
    public class TransactionsSettledUnsettled
    {
        public string JobStatus { get; set; }
        public int TotalNumberOfUsers { get; set; }
    }

    public class EmployeeOnLeave
    {
        public int OfficersOnLeave { get; set; }
        public int StaffOnLeave { get; set; }
        public int SequenceNo { get; set; }
        public string OfficeName { get; set; }
        public string PBSName { get; set; }
    }
    public class EmployeePerformance
    {
        public string ScoreRange { get; set; }
        public int NoOfOfficers { get; set; }
        public int SequenceNo { get; set; }
    }
    public class TransactionCountByType
    {
        public string Qualification { get; set; }
        public int Total { get; set; }
    }
    public class RTPStatusByFI
    {
        public string PostType { get; set; }
        public int SanctionPosts { get; set; }
        public int FilledPosts { get; set; }
        public int VacantPosts { get; set; }
    }
    public class UpcommingRetirement
    {
        public string MonthName { get; set; }
        public int Count { get; set; }
        public int SequenceNo { get; set; }
    }
    public class NetDebitCapPositionByFI
    {
        public string Organization { get; set; }
        public long Retirement { get; set; }
        public long NewEmployee { get; set; }
    }
    public class RegisteredUsersByFI
    {
        public string Organization { get; set; }
        public long Employee { get; set; }
    }
    public class TransactionsAmountTodayByFI
    {
        public string Organization { get; set; }
        public long TourCount { get; set; }
        public long RTPTotalAmount { get; set; }
    }
    public class RTPStatusByFIUtilityWise
    {
        public string Organization { get; set; }
        public int SanctionPosts { get; set; }
        public int FilledPosts { get; set; }
        public int VacantPosts { get; set; }
    }
    public class TotalNumberOfUsers
    {
        public long totalemployee { get; set; }
    }
    public class ForeignTourCategoryWise
    {
        public string TourCategory { get; set; }
        public int TotalTour { get; set; }
    }
    public class ForeignTourPurposeWiseOfficial
    {
        public string TourPurpose { get; set; }
        public int TotalTour { get; set; }
    }
    public class ForeignTourPurposeWisePersonal
    {
        public string TourPurpose { get; set; }
        public int TotalTour { get; set; }
    }
    public class TransactionsCountTodayByFI
    {
        public string Organization { get; set; }
        public long totalemployee { get; set; }
        public long RTPTransactionCount { get; set; }
    }
    public class UtilitywiseLastFiscalYearSalary
    {
        public string Organization { get; set; }
        public long TotalSalary { get; set; }
    }
    public class OrgPostWiseEmp
    {
        public string Organization { get; set; }
        public string PostType { get; set; }
        public int SanctionPost { get; set; }
        public int FilledPost { get; set; }
        public int VacantPost { get; set; }
    }
    public class OrgPostWiseUpcommingRetirment
    {
        public string PostType { get; set; }
        public int EmpQuantity { get; set; }
    }
    public class DesignationWiseEmpCount
    {
        public string Organization { get; set; }
        public string Designation { get; set; }
        public string PostType { get; set; }
        public int EmpQuantity { get; set; }
    }
    public class OrgWiseEmpByJobStatus
    {
        public string Organization { get; set; }
        public int TotalEmp{ get; set; }
    }
    public class OrgWiseEmpByQualification
    {
        public string Organization { get; set; }
        public int Total { get; set; }
    }
    public class OrgWiseNetDebitCapPositionByFI
    {
        public string PostType { get; set; }
        public int Retirement { get; set; }
        public int NewEmployee { get; set; }
    }
    public class DesignationWiseEmpByJobTypeAndOrg
    {
        public string Designation { get; set; }
        public int DesignationOrder { get; set; }
        public int TotalEmp { get; set; }
    }
    public class DesignationWiseEmpByQualificationAndOrg
    {
        public string Designation { get; set; }
        public int DesignationOrder { get; set; }
        public long TotalEmp { get; set; }
    }
}
