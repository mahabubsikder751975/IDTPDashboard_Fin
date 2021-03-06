#pragma checksum "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3af629f36c3e5f38607d7d7ac523d502ddeb4ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IndividualOrgChart_HRManagement_Dashboard), @"mvc.1.0.view", @"/Views/IndividualOrgChart/HRManagement_Dashboard.cshtml")]
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
#line 1 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\_ViewImports.cshtml"
using IDTPDashboard.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\_ViewImports.cshtml"
using IDTPDashboard.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
using ChartJSCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3af629f36c3e5f38607d7d7ac523d502ddeb4ab", @"/Views/IndividualOrgChart/HRManagement_Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c7fdc47333b1198e8e179737775b19b20ff7a83", @"/Views/_ViewImports.cshtml")]
    public class Views_IndividualOrgChart_HRManagement_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
  
    ViewData["Title"] = "HRManagement_Dashboard";
    Layout = "~/Views/Shared/Site/_Layout.cshtml";

    string monthYear = DateTime.Now.AddMonths(-1).ToString("MMMM yyyy");
    string LastYear = DateTime.Now.AddYears(-1).ToString("yyyy");
    string CurrYear = DateTime.Now.ToString("yyyy");


    Chart rtpStatusByFIs = (Chart)ViewData["rtpStatusByFIs"];
    Chart transactionsSettledUnsettledPieChart = (Chart)ViewData["transactionsSettledUnsettledPieChart"];
    Chart transactionCountByTypePieChart = (Chart)ViewData["transactionCountByTypePieChart"];
    Chart netDebitCapPositionByFI = (Chart)ViewData["netDebitCapPositionByFI"];
    Chart foreignTourCategoryWisePieChart = (Chart)ViewData["foreignTourCategoryWisePieChart"];
    Chart foreignTourPurposeWiseOfficialPieChart = (Chart)ViewData["foreignTourPurposeWiseOfficialPieChart"];
    Chart foreignTourPurposeWisePersonalPieChart = (Chart)ViewData["foreignTourPurposeWisePersonalPieChart"];
    Chart upcommingRetirement = (Chart)ViewData["upcommingRetirement"];

    //HRE
    Chart EmployeeAgeRange = (Chart)ViewData["EmployeeAgeRange"];
    Chart YearlyTurnover = (Chart)ViewData["YearlyTurnover"];
    Chart YearlyRecruitment = (Chart)ViewData["YearlyRecruitment"];
    Chart YearlyTermination = (Chart)ViewData["YearlyTermination"];
    Chart YearlyPromotion = (Chart)ViewData["YearlyPromotion"];
    Chart EmployeebyCategory = (Chart)ViewData["EmployeebyCategory"];
    Chart MaleFemaleRatioBoth = (Chart)ViewData["MaleFemaleRatioBoth"];
    Chart MaleFemaleRatioOfficer = (Chart)ViewData["MaleFemaleRatioOfficer"];
    Chart MaleFemaleRatioStaff = (Chart)ViewData["MaleFemaleRatioStaff"];

    //HRF
    Chart transactionAmountBySettlementCycleId = (Chart)ViewData["transactionAmountBySettlementCycleId"];
    Chart salaryByOffices = (Chart)ViewData["salaryByOffices"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<h4 style=\"text-align:center\">Human Resource Management Dashboard</h4>\r\n<h6 style=\"color: #00008B; text-align: center\">Total Number of Employee: ");
#nullable restore
#line 39 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
                                                                    Write(ViewBag.totalemployee);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>

<div class=""row p-4"">

    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Employment Status</h5>
                <canvas id=""rtpStatusByFIs""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Employees by Age Group</h5>
                <canvas id=""EmployeeAgeRange""></canvas>
            </div>
        </div>

    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Upcoming Retirements - next 12 months </h5>
                <canvas id=""upcommingRetirement""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Yearly Turnover for Last Yea");
            WriteLiteral("r(");
#nullable restore
#line 72 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
                                                                Write(LastYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h5>
                <canvas id=""YearlyTurnover""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Yearly Recruitment for Last Year(");
#nullable restore
#line 80 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
                                                                   Write(LastYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h5>
                <canvas id=""YearlyRecruitment""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Yearly Termination for Last Year(");
#nullable restore
#line 88 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
                                                                   Write(LastYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h5>
                <canvas id=""YearlyTermination""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Yearly Promotion for Last Year(");
#nullable restore
#line 96 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
                                                                 Write(LastYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h5>
                <canvas id=""YearlyPromotion""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Retirement vs New Employee for Last Year(");
#nullable restore
#line 104 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
                                                                           Write(LastYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h5>
                <canvas id=""netDebitCapPositionByFI""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Total Salary by Month</h5>
                <canvas id=""transactionAmountBySettlementCycleId""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Office wise Last Month Salary (");
#nullable restore
#line 121 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
                                                                 Write(monthYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h5>
                <canvas id=""salaryByOffices""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Male-Female Ratio</h5>
                <canvas id=""MaleFemaleRatioBoth""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Male-Female Ratio (Officer)</h5>
                <canvas id=""MaleFemaleRatioOfficer""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Male-Female Ratio (Staff)</h5>
                <canvas id=""MaleFemaleRatioStaff""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""");
            WriteLiteral(@"card-body"">
                <h5 class=""card-title"">Employee by Cadre</h5>
                <canvas id=""EmployeebyCategory""></canvas>
            </div>
        </div>
    </div>


    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Employee Job Status</h5>
                <canvas id=""transactionsSettledUnsettledPieChart""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Employee Qualification</h5>
                <canvas id=""transactionCountByTypePieChart""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Foreign Tour Category wise</h5>
                <canvas id=""foreignTourCategoryWisePieChart""></canvas>
            </div>
 ");
            WriteLiteral(@"       </div>
    </div>

    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Foreign Tour Personal Purpose wise</h5>
                <canvas id=""foreignTourPurposeWisePersonalPieChart""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Foreign Tour Official Purpose wise</h5>
                <canvas id=""foreignTourPurposeWiseOfficialPieChart""></canvas>
            </div>
        </div>
    </div>

</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n\r\n        ");
#nullable restore
#line 211 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(netDebitCapPositionByFI.CreateChartCode("netDebitCapPositionByFI")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 212 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(rtpStatusByFIs.CreateChartCode("rtpStatusByFIs")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 213 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(upcommingRetirement.CreateChartCode("upcommingRetirement")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 214 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(transactionsSettledUnsettledPieChart.CreateChartCode("transactionsSettledUnsettledPieChart")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 215 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(transactionCountByTypePieChart.CreateChartCode("transactionCountByTypePieChart")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 216 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(foreignTourCategoryWisePieChart.CreateChartCode("foreignTourCategoryWisePieChart")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 217 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(foreignTourPurposeWiseOfficialPieChart.CreateChartCode("foreignTourPurposeWiseOfficialPieChart")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 218 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(foreignTourPurposeWisePersonalPieChart.CreateChartCode("foreignTourPurposeWisePersonalPieChart")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n\r\n        ");
#nullable restore
#line 220 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(EmployeeAgeRange.CreateChartCode("EmployeeAgeRange")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 221 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(YearlyTurnover.CreateChartCode("YearlyTurnover")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 222 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(YearlyRecruitment.CreateChartCode("YearlyRecruitment")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 223 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(YearlyTermination.CreateChartCode("YearlyTermination")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 224 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(YearlyPromotion.CreateChartCode("YearlyPromotion")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 225 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(EmployeebyCategory.CreateChartCode("EmployeebyCategory")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 226 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(MaleFemaleRatioBoth.CreateChartCode("MaleFemaleRatioBoth")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 227 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(MaleFemaleRatioOfficer.CreateChartCode("MaleFemaleRatioOfficer")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 228 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(MaleFemaleRatioStaff.CreateChartCode("MaleFemaleRatioStaff")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n\r\n        ");
#nullable restore
#line 230 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(transactionAmountBySettlementCycleId.CreateChartCode("transactionAmountBySettlementCycleId")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 231 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\IndividualOrgChart\HRManagement_Dashboard.cshtml"
   Write(Html.Raw(salaryByOffices.CreateChartCode("salaryByOffices")));

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
