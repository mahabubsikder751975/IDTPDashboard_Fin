#pragma checksum "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\CommonChart\PR_Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b247a0946398bea23fb6d3fbc9a943789b88350f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CommonChart_PR_Dashboard), @"mvc.1.0.view", @"/Views/CommonChart/PR_Dashboard.cshtml")]
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
#line 2 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\CommonChart\PR_Dashboard.cshtml"
using ChartJSCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b247a0946398bea23fb6d3fbc9a943789b88350f", @"/Views/CommonChart/PR_Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c7fdc47333b1198e8e179737775b19b20ff7a83", @"/Views/_ViewImports.cshtml")]
    public class Views_CommonChart_PR_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\CommonChart\PR_Dashboard.cshtml"
  
    ViewData["Title"] = "HRManagement_Dashboard";
    Layout = "~/Views/Shared/Site/_Layout.cshtml";
    Chart procurementTrend = (Chart)ViewData["procurementTrend"];
    Chart topProcuredItemsbyOffice = (Chart)ViewData["topProcuredItemsbyOffice"];
    Chart procurementValuebyOffice = (Chart)ViewData["procurementValuebyOffice"];
    Chart procurementTypebyOffice = (Chart)ViewData["procurementTypebyOffice"];
    Chart procurementStatusPieChart = (Chart)ViewData["procurementStatusPieChart"];
    Chart appUtilizationPieChart = (Chart)ViewData["appUtilizationPieChart"];
    Chart requisitionStatusPieChart = (Chart)ViewData["requisitionStatusPieChart"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<h4 style=""text-align:center"">Procurement Dashboard</h4>

<div class=""row p-4"">
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Procurement Trend</h5>
                <canvas id=""procurementTrend""></canvas>
            </div>
        </div>

    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Top Items</h5>
                <canvas id=""topProcuredItemsbyOffice""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Procurement Value (Current Year)</h5>
                <canvas id=""procurementValuebyOffice""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
              ");
            WriteLiteral(@"  <h5 class=""card-title"">Procurement Types</h5>
                <canvas id=""procurementTypebyOffice""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Procurement Status</h5>
                <canvas id=""procurementStatusPieChart""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">APP Utilization</h5>
                <canvas id=""appUtilizationPieChart""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-4 p-1"">
            <div class=""card"">
                <div class=""card-body"">
                    <h5 class=""card-title"">Requisition Status</h5>
                    <canvas id=""requisitionStatusPieChart""></canvas>
                </div>
            </div>
        </div>

</div>
");
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        ");
#nullable restore
#line 84 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\CommonChart\PR_Dashboard.cshtml"
   Write(Html.Raw(procurementTrend.CreateChartCode("procurementTrend")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 85 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\CommonChart\PR_Dashboard.cshtml"
   Write(Html.Raw(topProcuredItemsbyOffice.CreateChartCode("topProcuredItemsbyOffice")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 86 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\CommonChart\PR_Dashboard.cshtml"
   Write(Html.Raw(procurementValuebyOffice.CreateChartCode("procurementValuebyOffice")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 87 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\CommonChart\PR_Dashboard.cshtml"
   Write(Html.Raw(procurementTypebyOffice.CreateChartCode("procurementTypebyOffice")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 88 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\CommonChart\PR_Dashboard.cshtml"
   Write(Html.Raw(procurementStatusPieChart.CreateChartCode("procurementStatusPieChart")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 89 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\CommonChart\PR_Dashboard.cshtml"
   Write(Html.Raw(appUtilizationPieChart.CreateChartCode("appUtilizationPieChart")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 90 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\CommonChart\PR_Dashboard.cshtml"
   Write(Html.Raw(requisitionStatusPieChart.CreateChartCode("requisitionStatusPieChart")));

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
