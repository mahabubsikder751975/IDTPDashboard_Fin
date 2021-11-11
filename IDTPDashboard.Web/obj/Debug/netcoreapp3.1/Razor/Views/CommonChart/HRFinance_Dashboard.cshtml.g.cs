#pragma checksum "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6262bdd50546881119250ffa6bd513f3af2bd98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CommonChart_HRFinance_Dashboard), @"mvc.1.0.view", @"/Views/CommonChart/HRFinance_Dashboard.cshtml")]
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
#line 1 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
using ChartJSCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6262bdd50546881119250ffa6bd513f3af2bd98", @"/Views/CommonChart/HRFinance_Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c7fdc47333b1198e8e179737775b19b20ff7a83", @"/Views/_ViewImports.cshtml")]
    public class Views_CommonChart_HRFinance_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
  
    ViewData["Title"] = "HRFinance_Dashboard";
    Layout = "~/Views/Shared/Site/_Layout.cshtml";

    string monthYear = DateTime.Now.AddMonths(-1).ToString("MMMM yyyy");
    string LastYear = DateTime.Now.AddYears(-1).ToString("yyyy");
    string CurrYear = DateTime.Now.ToString("yyyy");

    Chart salaryByEmployeeCategory = (Chart)ViewData["salaryByEmployeeCategory"];
    Chart netSalaryByMonth = (Chart)ViewData["netSalaryByMonth"];
    Chart allowanceDeductionByMonth = (Chart)ViewData["allowanceDeductionByMonth"];
    Chart salaryByOffices = (Chart)ViewData["salaryByOffices"];
    Chart grossSalaryExpenditurePieChart = (Chart)ViewData["grossSalaryExpenditurePieChart"];
    Chart festivalBonusPieChart = (Chart)ViewData["festivalBonusPieChart"];
    Chart cPFContributionPieChart = (Chart)ViewData["cPFContributionPieChart"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<h4 style=""text-align:center"">Human Resource Finance Dashboard</h4>

<div class=""row p-4"">
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Salary by Employee Category for Last Month(");
#nullable restore
#line 26 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
                                                                             Write(monthYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h5>
                <canvas id=""salaryByEmployeeCategory""></canvas>
            </div>
        </div>

    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Total Salary by Month</h5>
                <canvas id=""netSalaryByMonth""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Allowances and Deductions for Last Month(");
#nullable restore
#line 43 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
                                                                           Write(monthYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h5>
                <canvas id=""allowanceDeductionByMonth""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Total Salary by Offices for Last Month(");
#nullable restore
#line 51 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
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
                <h5 class=""card-title"">Salary Expenditure for Last Month(");
#nullable restore
#line 60 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
                                                                    Write(monthYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h5>
                <canvas id=""grossSalaryExpenditurePieChart""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Yearly Festival Bonus (FY)</h5>
                <canvas id=""festivalBonusPieChart""></canvas>
            </div>
        </div>
    </div>

     <div class=""col-md-4 p-1"">
            <div class=""card"">
                <div class=""card-body"">
                    <h5 class=""card-title"">CPF Contribution</h5>
                    <canvas id=""cPFContributionPieChart""></canvas>
                </div>
            </div>
        </div>

</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        ");
#nullable restore
#line 88 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
   Write(Html.Raw(salaryByEmployeeCategory.CreateChartCode("salaryByEmployeeCategory")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 89 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
   Write(Html.Raw(netSalaryByMonth.CreateChartCode("netSalaryByMonth")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 90 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
   Write(Html.Raw(allowanceDeductionByMonth.CreateChartCode("allowanceDeductionByMonth")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 91 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
   Write(Html.Raw(salaryByOffices.CreateChartCode("salaryByOffices")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 92 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
   Write(Html.Raw(grossSalaryExpenditurePieChart.CreateChartCode("grossSalaryExpenditurePieChart")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 93 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
   Write(Html.Raw(festivalBonusPieChart.CreateChartCode("festivalBonusPieChart")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 94 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\CommonChart\HRFinance_Dashboard.cshtml"
   Write(Html.Raw(cPFContributionPieChart.CreateChartCode("cPFContributionPieChart")));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";

        //chart.data.labels.forEach(function(value, index, array) {
        //        var a = [];
        //        a.push(value.slice(0, 5));
        //        var i = 1;
        //        while (value.length > (i * 5))
        //        {
        //            a.push(value.slice(i * 5, (i + 1) * 5));
        //            i++;
        //        }
        //        array[index] = a;
        //    })
    </script>
");
            }
            );
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
