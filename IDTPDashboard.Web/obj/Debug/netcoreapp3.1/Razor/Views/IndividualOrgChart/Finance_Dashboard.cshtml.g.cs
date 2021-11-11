#pragma checksum "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\IndividualOrgChart\Finance_Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3515608927a89854d38879e7ef815db077b9b62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IndividualOrgChart_Finance_Dashboard), @"mvc.1.0.view", @"/Views/IndividualOrgChart/Finance_Dashboard.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\_ViewImports.cshtml"
using IDTPDashboard.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\_ViewImports.cshtml"
using IDTPDashboard.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\IndividualOrgChart\Finance_Dashboard.cshtml"
using ChartJSCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3515608927a89854d38879e7ef815db077b9b62", @"/Views/IndividualOrgChart/Finance_Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c7fdc47333b1198e8e179737775b19b20ff7a83", @"/Views/_ViewImports.cshtml")]
    public class Views_IndividualOrgChart_Finance_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\IndividualOrgChart\Finance_Dashboard.cshtml"
  
    ViewData["Title"] = "Finance_Dashboard";
    Layout = "~/Views/Shared/Site/_Layout.cshtml";
    //Chart RevenueVsExpense = (Chart)ViewData["RevenueVsExpense"];
    //Chart NetProfitVsGrossRevenue = (Chart)ViewData["NetProfitVsGrossRevenue"];
    //Chart AccountReceivableVsCashflow = (Chart)ViewData["AccountReceivableVsCashflow"];
    //Chart CapitalExpenditureVsOperationalExpenses = (Chart)ViewData["CapitalExpenditureVsOperationalExpenses"];
    //Chart AccountsPayable = (Chart)ViewData["AccountsPayable"];
    //Chart AccountsReceivable = (Chart)ViewData["AccountsReceivable"];
    //Chart YearlyTurnOver = (Chart)ViewData["YearlyTurnOver"];
    Chart TotalAssetsvsTotalLiabilities = (Chart)ViewData["TotalAssetsvsTotalLiabilities"];
    Chart TotalEquityvsDebt = (Chart)ViewData["TotalEquityvsDebt"];
    Chart ExpensevsRevenue = (Chart)ViewData["ExpensevsRevenue"];
    Chart GrossProfitvsNetProfit = (Chart)ViewData["GrossProfitvsNetProfit"];
    Chart ReceivablevsPayable = (Chart)ViewData["ReceivablevsPayable"];
    Chart FiscalYearlyTurnover = (Chart)ViewData["FiscalYearlyTurnover"];
    Chart CurrentRatioFiscalYearWise = (Chart)ViewData["CurrentRatioFiscalYearWise"];
    Chart QuickRatioFiscalYearWise = (Chart)ViewData["QuickRatioFiscalYearWise"];
    Chart DebtRatioFiscalYearWise = (Chart)ViewData["DebtRatioFiscalYearWise"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<h4 style=""text-align:center"">Finance Dashboard</h4>

<div class=""row p-4"">
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Total Asset vs Total Liabilities (3 Fiscal Years)</h5>
                <canvas id=""TotalAssetsvsTotalLiabilities""></canvas>
            </div>
        </div>

    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Total Equity vs Total Debt (3 Fiscal Years)</h5>
                <canvas id=""TotalEquityvsDebt""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Revenue vs Expenditure (3 Fiscal Years)</h5>
                <canvas id=""ExpensevsRevenue""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div");
            WriteLiteral(@" class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Gross Profit vs Net Profit (Last Two Fiscal Years)</h5>
                <canvas id=""GrossProfitvsNetProfit""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Accounts Receivable vs Payables (3 Fiscal Years)</h5>
                <canvas id=""ReceivablevsPayable""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Yearly Turnover (3Fiscal Year)</h5>
                <canvas id=""FiscalYearlyTurnover""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Current Ratio (3 Fiscal Years)</h5>
          ");
            WriteLiteral(@"      <canvas id=""CurrentRatioFiscalYearWise""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Quick Ratio (3 Fiscal Years)</h5>
                <canvas id=""QuickRatioFiscalYearWise""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Debt Ratio (3 Fiscal Years)</h5>
                <canvas id=""DebtRatioFiscalYearWise""></canvas>
            </div>
        </div>
    </div>
");
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n");
                WriteLiteral("         ");
#nullable restore
#line 172 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\IndividualOrgChart\Finance_Dashboard.cshtml"
    Write(Html.Raw(TotalAssetsvsTotalLiabilities.CreateChartCode("TotalAssetsvsTotalLiabilities")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n         ");
#nullable restore
#line 173 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\IndividualOrgChart\Finance_Dashboard.cshtml"
    Write(Html.Raw(TotalEquityvsDebt.CreateChartCode("TotalEquityvsDebt")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n         ");
#nullable restore
#line 174 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\IndividualOrgChart\Finance_Dashboard.cshtml"
    Write(Html.Raw(ExpensevsRevenue.CreateChartCode("ExpensevsRevenue")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n         ");
#nullable restore
#line 175 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\IndividualOrgChart\Finance_Dashboard.cshtml"
    Write(Html.Raw(GrossProfitvsNetProfit.CreateChartCode("GrossProfitvsNetProfit")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n         ");
#nullable restore
#line 176 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\IndividualOrgChart\Finance_Dashboard.cshtml"
    Write(Html.Raw(ReceivablevsPayable.CreateChartCode("ReceivablevsPayable")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n         ");
#nullable restore
#line 177 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\IndividualOrgChart\Finance_Dashboard.cshtml"
    Write(Html.Raw(FiscalYearlyTurnover.CreateChartCode("FiscalYearlyTurnover")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n         ");
#nullable restore
#line 178 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\IndividualOrgChart\Finance_Dashboard.cshtml"
    Write(Html.Raw(CurrentRatioFiscalYearWise.CreateChartCode("CurrentRatioFiscalYearWise")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n         ");
#nullable restore
#line 179 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\IndividualOrgChart\Finance_Dashboard.cshtml"
    Write(Html.Raw(QuickRatioFiscalYearWise.CreateChartCode("QuickRatioFiscalYearWise")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n         ");
#nullable restore
#line 180 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\IndividualOrgChart\Finance_Dashboard.cshtml"
    Write(Html.Raw(DebtRatioFiscalYearWise.CreateChartCode("DebtRatioFiscalYearWise")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591