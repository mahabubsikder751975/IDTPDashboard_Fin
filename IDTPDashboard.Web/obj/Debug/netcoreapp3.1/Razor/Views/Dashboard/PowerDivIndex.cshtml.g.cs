#pragma checksum "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7bd948846d90017c6d9d4cf51772e2e187cdf96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_PowerDivIndex), @"mvc.1.0.view", @"/Views/Dashboard/PowerDivIndex.cshtml")]
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
#line 25 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
using ChartJSCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7bd948846d90017c6d9d4cf51772e2e187cdf96", @"/Views/Dashboard/PowerDivIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c7fdc47333b1198e8e179737775b19b20ff7a83", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_PowerDivIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IDTPDashboard.DomainModel.Entity.Menu_Entity>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-lg btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
  
    ViewData["Title"] = "IDTP Index";
    Layout = "~/Views/Shared/Site/_Layout.cshtml";
    static string GetCurrFinancialYear()
    {
        int CurrentYear = (DateTime.Now.Year);
        int PreviousYear = (DateTime.Now.Year - 1);
        int NextYear = (DateTime.Now.Year +1);
        string PreYear = PreviousYear.ToString();
        string NexYear = NextYear.ToString();
        string CurYear = CurrentYear.ToString();
        string FinYear = string.Empty;
        if (DateTime.Now.Month > 7)
        {
            FinYear = CurYear + "-" + NexYear;
        }
        else
        {
            FinYear = PreYear + "-" + CurYear;
        }
        return FinYear;
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
  
    //Chart UtilityWiseTurnover = (Chart)ViewData["UtilityWiseTurnover"];
    //Chart transactionsCountTodayByFI = (Chart)ViewData["transactionsCountTodayByFI"];
    Chart TotalPowerPlants = (Chart)ViewData["TotalPowerPlants"];
    Chart TotalInstalledCapacityMW = (Chart)ViewData["TotalInstalledCapacityMW"];
    //Chart procurementValuebyOffice = (Chart)ViewData["procurementValuebyOffice"];
    //Chart TotalNumberOfUsersByStatus = (Chart)ViewData["TotalNumberOfUsersByStatus"];
    Chart FinancialPosition = (Chart)ViewData["FinancialPosition"];
    Chart APPUtilizedUnutilized = (Chart)ViewData["APPUtilizedUnutilized"];
    //Chart fuelWisePowerPlant = (Chart)ViewData["fuelWisePowerPlant"];
    Chart AccReceivableAndPayable = (Chart)ViewData["AccReceivableAndPayable"];

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container mt-3\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 40 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-3\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7bd948846d90017c6d9d4cf51772e2e187cdf966049", async() => {
#nullable restore
#line 43 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
                                                                                                                    Write(item.MenuName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
                                                                 WriteLiteral(item.Controller);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
                                                                                               WriteLiteral(item.Action);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 45 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>
<div class=""container mt-3"">
</div>
<h4 style=""text-align: center; background-color: #1A6BA0; color: white; padding: 8px; "">Executive Dashboard for Bangladesh Bank IDTP</h4>
<div class=""row p-2"">
    <div class=""col-md-4 p-1"">
        <table class=""table table-bordered"">
            <tbody>
                <tr>
                    <td colspan=""2"" style=""background-color: #1A6BA0; color: white; text-align: center; border-color: #1A6BA0;""><h6><b>General Information(As On ");
#nullable restore
#line 56 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
                                                                                                                                                            Write(ViewBag.ParticularsDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</b></h6></td>\r\n                </tr>\r\n");
#nullable restore
#line 58 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
                 foreach (var items in ViewBag.particulars)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td style=\"background-color: #98AFC7;\"><b>");
#nullable restore
#line 61 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
                                                             Write(items.ParticularName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\r\n                        <td style=\"background-color: #ADD8E6;\"><b>");
#nullable restore
#line 62 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
                                                             Write(items.CurrentStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\r\n                    </tr>\r\n");
#nullable restore
#line 64 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    <div class=\"col-md-4 p-1\">\r\n");
            WriteLiteral(@"        <div class=""card container"" >
            <div class=""card-body"">
                <h6 class=""card-title"">Employment Status</h6>
                <canvas id=""TotalNumberOfUsersByStatus""></canvas>
            </div>
        </div>
        <div class=""card container mt-2"">
            <div class=""card-body"">
                <h6 class=""card-title"">Total Installed Capacity (MW)</h6>
                <canvas id=""TotalInstalledCapacityMW""></canvas>
            </div>
        </div>
        <div class=""card container mt-2"">
            <div class=""card-body"" >
                <h6 class=""card-title"">Accounts Receivable vs Payables (");
#nullable restore
#line 95 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
                                                                   Write(GetCurrFinancialYear());

#line default
#line hidden
#nullable disable
            WriteLiteral(")</h6>\r\n                <canvas id=\"AccReceivableAndPayable\"></canvas>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-4 p-1\">\r\n");
            WriteLiteral("        <div class=\"card container\" >\r\n            <div class=\"card-body\">\r\n                <h6 class=\"card-title\">APP Utilization (");
#nullable restore
#line 116 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
                                                   Write(GetCurrFinancialYear());

#line default
#line hidden
#nullable disable
            WriteLiteral(@") in Crore Tk</h6>
                <canvas id=""APPUtilizedUnutilized""></canvas>
            </div>
        </div>
        <div class=""card container mt-2"" >
            <div class=""card-body"">
                <h6 class=""card-title"">Total Number of Power Plant</h6>
                <canvas id=""TotalPowerPlants""></canvas>
            </div>
        </div>

        <div class=""card container mt-2"" >
            <div class=""card-body"">
                <h6 class=""card-title"">Financial Position (");
#nullable restore
#line 129 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
                                                      Write(GetCurrFinancialYear());

#line default
#line hidden
#nullable disable
            WriteLiteral(")</h6>\r\n                <canvas id=\"FinancialPosition\"></canvas>\r\n            </div>\r\n        </div>\r\n    </div>\r\n   \r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n");
                WriteLiteral("         ");
#nullable restore
#line 140 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
    Write(Html.Raw(TotalPowerPlants.CreateChartCode("TotalPowerPlants")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n         ");
#nullable restore
#line 141 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
    Write(Html.Raw(TotalInstalledCapacityMW.CreateChartCode("TotalInstalledCapacityMW")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n");
                WriteLiteral("         ");
#nullable restore
#line 143 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
    Write(Html.Raw(FinancialPosition.CreateChartCode("FinancialPosition")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n         ");
#nullable restore
#line 144 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
    Write(Html.Raw(APPUtilizedUnutilized.CreateChartCode("APPUtilizedUnutilized")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n");
                WriteLiteral("         ");
#nullable restore
#line 146 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
    Write(Html.Raw(AccReceivableAndPayable.CreateChartCode("AccReceivableAndPayable")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n");
                WriteLiteral("    </script>\r\n    <script type=\"text/javascript\">\r\n    $(document).ready(function () {\r\n        loadTotalEmpStatusChart();\r\n    });\r\n    function loadTotalEmpStatusChart() {\r\n            var totalNumberOfUsersByStatus =");
#nullable restore
#line 154 "C:\Software\IDTPDashboard_Fin\IDTPDashboard_Fin\IDTPDashboard.Web\Views\Dashboard\PowerDivIndex.cshtml"
                                       Write(Html.Raw(Json.Serialize(@ViewBag.totalNumberOfUsersByStatus)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
            var canvas = document.getElementById(""TotalNumberOfUsersByStatus"");
            var ctx = canvas.getContext(""2d"");
        var xValues = totalNumberOfUsersByStatus.map(o => o.type);
        var yValues = totalNumberOfUsersByStatus.map(v => v.employeeCount/1000);
            //var barColors = [""#FE9666"", ""#01B8AA"", ""#698B69"", ""#008080"", ""#007EB9"", ""#5F6B6D"", ""#DFBFBF"", ""#660000"", ""#FFDEAD"", ""#9AFF9A"", ""#4F8E83"", ""#62B1F6"", ""#990099"", ""#9D6B84"", ""#551011""];
        var dataSet = {
                //barPercentage: 0.5,
                barThickness: 40,
                maxBarThickness: 50,
                //minBarLength: 2,
                label: 'Number of Posts',
                backgroundColor: '#01B8AA',
                data: yValues
            };

            var chartData = chartHelper.data(xValues, dataSet);
            var chart = new Chart(ctx, chartHelper.config('bar',chartData));            
        }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IDTPDashboard.DomainModel.Entity.Menu_Entity>> Html { get; private set; }
    }
}
#pragma warning restore 1591
