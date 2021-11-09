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
            FilledPostVacantPostList = new List<FilledPostVacantPost>();
            UpcommingRetirementList = new List<UpcommingRetirement>();
            EmployeePerformanceList = new List<EmployeePerformance>();
            EmployeeJobStatusList = new List<EmployeeJobStatus>();
            EmployeeQualifcationList = new List<EmployeeQualifcation>();
            RetirementvsNewEmployeeList = new List<RetirementvsNewEmployee>();
            UpcommingRetirementCompanyWiseList = new List<UpcommingRetirementCompanyWise>();
            ForeignTourOrganizationWiseList = new List<ForeignTourOrganizationWise>();
            FilledPostVacantPostUtilityWiseList = new List<FilledPostVacantPostUtilityWise>();
            TotalEmployeeList = new List<TotalEmployee>();
            ForeignTourCategoryWiseList = new List<ForeignTourCategoryWise>();
            ForeignTourPurposeWiseOfficialList = new List<ForeignTourPurposeWiseOfficial>();
            ForeignTourPurposeWisePersonalList = new List<ForeignTourPurposeWisePersonal>();
            TotalEmployeeUtilityWiseList = new List<TotalEmployeeUtilityWise>();
            UtilitywiseLastFiscalYearSalaryList = new List<UtilitywiseLastFiscalYearSalary>();
            OrgPostWiseEmpList = new List<OrgPostWiseEmp>();
            OrgPostWiseUpcommingRetirmentList = new List<OrgPostWiseUpcommingRetirment>();
            OrgWiseEmpByJobStatusList = new List<OrgWiseEmpByJobStatus>();
            OrgWiseEmpByQualificationList = new List<OrgWiseEmpByQualification>();
            OrgWiseRetirementvsNewEmployeeList = new List<OrgWiseRetirementvsNewEmployee>();
            DesignationWiseEmpByJobTypeAndOrgList = new List<DesignationWiseEmpByJobTypeAndOrg>();
            DesignationWiseEmpByQualificationAndOrgList = new List<DesignationWiseEmpByQualificationAndOrg>();
            //DesignationWiseEmpCountList = new List<DesignationWiseEmpCount>();
        }
        public List<EmployeeAttendance> EmployeeAttendanceList { get; set; }
        public List<EmployeeOnLeave> EmployeeOnLeaveList { get; set; }
        public List<FilledPostVacantPost> FilledPostVacantPostList { get; set; }
        public List<UpcommingRetirement> UpcommingRetirementList { get; set; }
        public List<EmployeePerformance> EmployeePerformanceList { get; set; }
        public List<EmployeeJobStatus> EmployeeJobStatusList { get; set; }
        public List<EmployeeQualifcation> EmployeeQualifcationList { get; set; }
        public List<RetirementvsNewEmployee> RetirementvsNewEmployeeList { get; set; }
        public List<UpcommingRetirementCompanyWise> UpcommingRetirementCompanyWiseList { get; set; }
        public List<ForeignTourOrganizationWise> ForeignTourOrganizationWiseList { get; set; }
        public List<FilledPostVacantPostUtilityWise> FilledPostVacantPostUtilityWiseList { get; set; }
        public List<TotalEmployee> TotalEmployeeList { get; set; }
        public List<ForeignTourCategoryWise> ForeignTourCategoryWiseList { get; set; }
        public List<ForeignTourPurposeWiseOfficial> ForeignTourPurposeWiseOfficialList { get; set; }
        public List<ForeignTourPurposeWisePersonal> ForeignTourPurposeWisePersonalList { get; set; }
        public List<TotalEmployeeUtilityWise> TotalEmployeeUtilityWiseList { get; set; }
        public List<UtilitywiseLastFiscalYearSalary> UtilitywiseLastFiscalYearSalaryList { get; set; }
        public List<OrgPostWiseEmp> OrgPostWiseEmpList { get; set; }
        public List<OrgPostWiseUpcommingRetirment> OrgPostWiseUpcommingRetirmentList { get; set; }
        public List<DesignationWiseEmpCount> DesignationWiseEmpCountList { get; set; }
        public List<OrgWiseEmpByJobStatus> OrgWiseEmpByJobStatusList { get; set; }
        public List<OrgWiseEmpByQualification> OrgWiseEmpByQualificationList { get; set; }
        public List<OrgWiseRetirementvsNewEmployee> OrgWiseRetirementvsNewEmployeeList { get; set; }
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
    public class EmployeeJobStatus
    {
        public string JobStatus { get; set; }
        public int TotalEmployee { get; set; }
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
    public class EmployeeQualifcation
    {
        public string Qualification { get; set; }
        public int Total { get; set; }
    }
    public class FilledPostVacantPost
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
    public class RetirementvsNewEmployee
    {
        public string Organization { get; set; }
        public long Retirement { get; set; }
        public long NewEmployee { get; set; }
    }
    public class UpcommingRetirementCompanyWise
    {
        public string Organization { get; set; }
        public long Employee { get; set; }
    }
    public class ForeignTourOrganizationWise
    {
        public string Organization { get; set; }
        public long TourCount { get; set; }
    }
    public class FilledPostVacantPostUtilityWise
    {
        public string Organization { get; set; }
        public int SanctionPosts { get; set; }
        public int FilledPosts { get; set; }
        public int VacantPosts { get; set; }
    }
    public class TotalEmployee
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
    public class TotalEmployeeUtilityWise
    {
        public string Organization { get; set; }
        public long totalemployee { get; set; }
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
    public class OrgWiseRetirementvsNewEmployee
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
