using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class Finance_Entity
    {
        public Finance_Entity()
        {
        }
        public List<RevenueVsExpense> RevenueVsExpenseList { get; set; }
        public List<NetProfitVsGrossRevenue> NetProfitVsGrossRevenueList { get; set; }
        public List<AccountReceivableVsCashflow> AccountReceivableVsCashflowList { get; set; }
        public List<CapitalExpenditureVsOperationalExpenses> CapitalExpenditureVsOperationalExpensesList { get; set; }
        public List<AccountsPayable> AccountsPayableList { get; set; }
        public List<AccountsReceivable> AccountsReceivableList { get; set; }
        public List<YearlyTurnOver> YearlyTurnOverList { get; set; }
        public List<TotalAssetsvsTotalLiabilities> TotalAssetsvsTotalLiabilitiesList { get; set; }
        public List<TotalEquityvsDebt> TotalEquityvsDebtList { get; set; }
        public List<ExpensevsRevenue> ExpensevsRevenueList { get; set; }
        public List<GrossProfitvsNetProfit> GrossProfitvsNetProfitList { get; set; }
        public List<ReceivablevsPayable> ReceivablevsPayableList { get; set; }
        public List<FiscalYearlyTurnover> FiscalYearlyTurnoverList { get; set; }
        public List<CurrentRatioFiscalYearWise> CurrentRatioFiscalYearWiseList { get; set; }
        public List<QuickRatioFiscalYearWise> QuickRatioFiscalYearWiseList { get; set; }
        public List<DebtRatioFiscalYearWise> DebtRatioFiscalYearWiseList { get; set; }
        public List<UtilityWiseGrossProfit> UtilityWiseGrossProfitList { get; set; }
        public List<UtilityWiseNetProfit> UtilityWiseNetProfitList { get; set; }
        public List<UtilityWiseTurnover> UtilityWiseTurnoverList { get; set; }

        public List<UtilityWiseCashAndCashEquivalent> UtilityWiseCashAndCashEquivalentList { get; set; }
        public List<UtilityWiseCurrentRatio> UtilityWiseCurrentRatioList { get; set; }
        public List<UtilityWiseQuickRatio> UtilityWiseQuickRatioList { get; set; }
        public List<UtilityWiseDebtRatio> UtilityWiseDebtRatioList { get; set; }


    }
    public class RevenueVsExpense
    {
        public string Organization { get; set; }
        public string   OfficeName { get; set; }
        public double Expense { get; set; }
        public double Revenue { get; set; }
        public int SequenceNo { get; set; }
    }
    public class NetProfitVsGrossRevenue
    {
        public string Organization { get; set; }
        public string OfficeName { get; set; }
        public long NetProfit { get; set; }
        public long GrossRevenue { get; set; }
        public int SequenceNo { get; set; }
    }
    public class AccountReceivableVsCashflow
    {
        public string Organization { get; set; }
        public string OfficeName { get; set; }
        public long Receivable { get; set; }
        public long Cashflow { get; set; }
        public string YearConcern { get; set; }
        public int SequenceNo { get; set; }
    }
    public class CapitalExpenditureVsOperationalExpenses
    {
        public string Organization { get; set; }
        public string OfficeName { get; set; }
        public long CapEx { get; set; }
        public long OpEx { get; set; }
        public int SequenceNo { get; set; }
    }
    public class AccountsPayable
    {
        public string Organization { get; set; }
        public string OfficeName { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
    }
    public class AccountsReceivable
    {
        public string Organization { get; set; }
        public string OfficeName { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
    }
    public class YearlyTurnOver
    {
        public string Organization { get; set; }
        public string OfficeName { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
    }
    public class TotalAssetsvsTotalLiabilities
    {
        public string FiscalYear { get; set; }
        public long TotalAssets { get; set; }
        public long TotalLiabilities { get; set; }
    }
    public class TotalEquityvsDebt
    {
        public string FiscalYear { get; set; }
        public long TotalEquity { get; set; }
        public long TotalDebt { get; set; }
    }
    public class ExpensevsRevenue
    {
        public string FiscalYear { get; set; }
        public long Revenue { get; set; }
        public long Expense { get; set; }
    }
    public class GrossProfitvsNetProfit
    {
        public string FiscalYear { get; set; }
        public long GrossProfit { get; set; }
        public long NetProfit { get; set; }
    }
    public class ReceivablevsPayable
    {
        public string FiscalYear { get; set; }
        public long AccountReceivable { get; set; }
        public long AccountPayable { get; set; }
    }
    public class FiscalYearlyTurnover
    {
        public string FiscalYear { get; set; }
        public long Turnover { get; set; }
    }
    public class CurrentRatioFiscalYearWise
    {
        public string FiscalYear { get; set; }
        public double CurrentRatio { get; set; }
    }
    public class QuickRatioFiscalYearWise
    {
        public string FiscalYear { get; set; }
        public double QuickRatio { get; set; }
    }
    public class DebtRatioFiscalYearWise
    {
        public string FiscalYear { get; set; }
        public double DebtRatio { get; set; }
    }
    public class UtilityWiseGrossProfit
    {
        public string Organization { get; set; }
        public long GrossProfit { get; set; }
    }
    public class UtilityWiseNetProfit
    {
        public string Organization { get; set; }
        public long NetProfit { get; set; }
    }
    public class UtilityWiseTurnover
    {
        public string Organization { get; set; }
        public long Turnover { get; set; }
    }
    public class UtilityWiseCashAndCashEquivalent
    {
        public string Organization { get; set; }
        public long CashAndCashEquivalent { get; set; }
    }
    public class UtilityWiseCurrentRatio
    {
        public string Organization { get; set; }
        public double CurrentRatio { get; set; }
    }
    public class UtilityWiseQuickRatio
    {
        public string Organization { get; set; }
        public double QuickRatio { get; set; }
    }
    public class UtilityWiseDebtRatio
    {
        public string Organization { get; set; }
        public double DebtRatio { get; set; }
    }
}
