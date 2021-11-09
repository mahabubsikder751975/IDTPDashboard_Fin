using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class HRExecutive_Entity
    {
        public HRExecutive_Entity()
        {
        }
        public List<EmployeeAgeRange> EmployeeAgeRangeList { get; set; }
        public List<EmployeeYearsofService> EmployeeYearsofServiceList { get; set; }
        public List<YearlyTurnover> YearlyTurnoverList { get; set; }
        public List<YearlyRecruitment> YearlyRecruitmentList { get; set; }
        public List<YearlyTermination> YearlyTerminationList { get; set; }
        public List<YearlyPromotion> YearlyPromotionList { get; set; }
        public List<EmployeebyCategory> EmployeebyCategoryList { get; set; }
        public List<MaleFemaleRatio> MaleFemaleRatioBothList { get; set; }
        public List<MaleFemaleRatio> MaleFemaleRatioOfficerList { get; set; }
        public List<MaleFemaleRatio> MaleFemaleRatioStaffList { get; set; }
        public List<EmployeeAgeRangeGenderWise> EmployeeAgeRangeGenderWiseList { get; set; }
        public List<RetirementvsTerminatedOverall> RetirementvsTerminatedOverallList { get; set; }
        public List<TechnicalNonTechnicalCadrewiseinformation> TechnicalNonTechnicalCadrewiseinformationList { get; set; }
    }
    public class EmployeeAgeRange
    {
        public string Age { get; set; }
        public long Count { get; set; }
    }
    public class EmployeeYearsofService
    {
        public string Age { get; set; }
        public long Engineer { get; set; }
        public long Admin { get; set; }
        public long Finance { get; set; }

    }
    public class YearlyTurnover
    {
        public string Month { get; set; }
        public long Count { get; set; }
        public long Order { get; set; }
    }
    public class YearlyRecruitment
    {
        public string Month { get; set; }
        public long Count { get; set; }
        public long Order { get; set; }
    }
    public class YearlyTermination
    {
        public string Month { get; set; }
        public long Count { get; set; }
        public long Order { get; set; }
    }
    public class YearlyPromotion
    {
        public string Month { get; set; }
        public long Count { get; set; }
        public long Order { get; set; }
    }
    public class EmployeebyCategory
    {
        public string Category { get; set; }
        public long Count { get; set; }
    }
    public class MaleFemaleRatio
    {
        public string Gender { get; set; }
        public long EmpCount { get; set; }
    }
    public class EmployeeAgeRangeGenderWise
    {
        public string Age { get; set; }
        public long Male { get; set; }
        public long Female { get; set; }
    }
    public class RetirementvsTerminatedOverall
    {
        public string EmpStatus { get; set; }
        public long EmpCount { get; set; }
    }
    public class TechnicalNonTechnicalCadrewiseinformation
    {
        public string DesignationType { get; set; }
        public long Officer { get; set; }
        public long Staff { get; set; }
    }
}
