using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class Finence_Executive_Entity
    {
        public Finence_Executive_Entity()
        {
        }
        public List<FinanceETotalAssets> FinanceETotalAssetsList { get; set; }
        public List<FinanceETotalLiabilities> FinanceETotalLiabilitiesList { get; set; }
        public List<FinanceETotalEquity> FinanceETotalEquityList { get; set; }
        public List<FinanceETotalDebt> FinanceETotalDebtList { get; set; }
        public List<FinanceENetMargin> FinanceENetMarginList { get; set; }
        public List<FinanceETotalTax> FinanceETotalTaxList { get; set; }
        public List<FinanceEProfitablyRatio> FinanceEProfitablyRatioList { get; set; }
        public List<FinanceECurrentRatio> FinanceECurrentRatioList { get; set; }
        public List<FinanceEQuickRatio> FinanceEQuickRatioList { get; set; }
    }
    public class FinanceETotalAssets
    {
        public string Year { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
        public string Organization { get; set; }
    }
    public class FinanceETotalLiabilities
    {
        public string Year { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
        public string Organization { get; set; }
    }
    public class FinanceETotalEquity
    {
        public string Year { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
        public string Organization { get; set; }
    }
    public class FinanceETotalDebt
    {
        public string Year { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
        public string Organization { get; set; }
    }
    public class FinanceENetMargin
    {
        public string Year { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
        public string Organization { get; set; }
    }
    public class FinanceETotalTax
    {
        public string Year { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
        public string Organization { get; set; }
    }
    public class FinanceEProfitablyRatio
    {
        public string Year { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
        public string Organization { get; set; }
    }
    public class FinanceECurrentRatio
    {
        public string Year { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
        public string Organization { get; set; }
    }
    public class FinanceEQuickRatio
    {
        public string Year { get; set; }
        public long Amount { get; set; }
        public int SequenceNo { get; set; }
        public string Organization { get; set; }
    }
}
