using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity 
{
    public class HRFinance_Entity
    {
        public HRFinance_Entity()
        {
            SalaryByEmployeeCategoryList = new List<SalaryByEmployeeCategory>();
            TransactionAmountBySettlementCycleIdList = new List<TransactionAmountBySettlementCycleId>();
            AllowanceDeductionByMonthList = new List<AllowanceDeductionByMonth>();
            SalaryByOfficesList = new List<SalaryByOffices>();
            GrossSalaryExpenditureList = new List<GrossSalaryExpenditure>();
            FestivalBonusList = new List<FestivalBonus>();
            CPFContributionList = new List<CPFContribution>();
            OrgWiseTransactionAmountBySettlementCycleIdList = new List<OrgWiseTransactionAmountBySettlementCycleId>();
        }
        public List<SalaryByEmployeeCategory> SalaryByEmployeeCategoryList { get; set; }
        public List<TransactionAmountBySettlementCycleId> TransactionAmountBySettlementCycleIdList { get; set; }
        public List<AllowanceDeductionByMonth> AllowanceDeductionByMonthList { get; set; }
        public List<SalaryByOffices> SalaryByOfficesList { get; set; }
        public List<GrossSalaryExpenditure> GrossSalaryExpenditureList { get; set; }
        public List<FestivalBonus> FestivalBonusList { get; set; }
        public List<CPFContribution> CPFContributionList { get; set; }
        public List<OrgWiseTransactionAmountBySettlementCycleId> OrgWiseTransactionAmountBySettlementCycleIdList { get; set; }
    }
    public class SalaryByEmployeeCategory
    {
        public double Technical { get; set; }
        public double CasualDailyBasis { get; set; }
        public double Consultant { get; set; }
        public double Contractual { get; set; }
        public double MusterRoll { get; set; }
        public double Permanent { get; set; }
        public int SequenceNo { get; set; }
        public string OfficeName { get; set; }
        public string PBSName { get; set; }
    }
    public class TransactionAmountBySettlementCycleId
    {
        public string SalaryDate { get; set; }
        public double TotalSalary { get; set; }
        public int SequenceNo { get; set; }
    }
    public class AllowanceDeductionByMonth
    {
        public int HouseRentAllowance { get; set; }
        public int TransportAllowance { get; set; }
        public int MedicalAllowance { get; set; }
        public int CPFContribution { get; set; }
        public int TDS { get; set; }
        public int SequenceNo { get; set; }
        public string OfficeName { get; set; }
        public string PBSName { get; set; }
    }
    public class SalaryByOffices
    {
        public int TotalSalary { get; set; }
        public int SequenceNo { get; set; }
        public string OfficeName { get; set; }
        public string PBSName { get; set; }
    }
    public class GrossSalaryExpenditure
    {
        public string ExpenditureType { get; set; }
        public int Amount { get; set; }
    }
    public class FestivalBonus
    {
        public string BonusName { get; set; }
        public double BonusAmount { get; set; }
    }
    public class CPFContribution
    {
        public double Amount { get; set; }
        public string OfficeName { get; set; }
        public string PBSName { get; set; }
    }
    public class OrgWiseTransactionAmountBySettlementCycleId
    {
        public double TotalSalary { get; set; }
        public string Organization { get; set; }
    }
}
