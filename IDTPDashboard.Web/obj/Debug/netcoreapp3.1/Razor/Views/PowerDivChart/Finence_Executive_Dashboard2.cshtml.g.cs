#pragma checksum "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\Finence_Executive_Dashboard2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63be20b21d776275247d29c1951883680f471eaa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PowerDivChart_Finence_Executive_Dashboard2), @"mvc.1.0.view", @"/Views/PowerDivChart/Finence_Executive_Dashboard2.cshtml")]
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
#line 1 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\Finence_Executive_Dashboard2.cshtml"
using ChartJSCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63be20b21d776275247d29c1951883680f471eaa", @"/Views/PowerDivChart/Finence_Executive_Dashboard2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c7fdc47333b1198e8e179737775b19b20ff7a83", @"/Views/_ViewImports.cshtml")]
    public class Views_PowerDivChart_Finence_Executive_Dashboard2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\Finence_Executive_Dashboard2.cshtml"
  
    ViewData["Title"] = "Finence_Executive_Dashboard";
    Layout = "~/Views/Shared/Site/_Layout.cshtml";
    Chart FinanceENetMargin = (Chart)ViewData["FinanceENetMargin"];
    Chart FinanceETotalTax = (Chart)ViewData["FinanceETotalTax"];
    Chart FinanceEProfitablyRatio = (Chart)ViewData["FinanceEProfitablyRatio"];
    Chart FinanceECurrentRatio = (Chart)ViewData["FinanceECurrentRatio"];
    Chart FinanceEQuickRatio = (Chart)ViewData["FinanceEQuickRatio"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<h4 style=""text-align:center"">Finence Executive Dashboard</h4>

<div class=""row p-4"">
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Net Margin (Last Two FY)</h5>
                <canvas id=""FinanceENetMargin""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Total Tax (Last Two FY)</h5>
                <canvas id=""FinanceETotalTax""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Profitability Ratio (Last Two FY)</h5>
                <canvas id=""FinanceEProfitablyRatio""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-bo");
            WriteLiteral(@"dy"">
                <h5 class=""card-title"">Current Ratio (Last Two FY)</h5>
                <canvas id=""FinanceECurrentRatio""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Quick Ratio (Last Two FY)</h5>
                <canvas id=""FinanceEQuickRatio""></canvas>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        ");
#nullable restore
#line 61 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\Finence_Executive_Dashboard2.cshtml"
   Write(Html.Raw(FinanceENetMargin.CreateChartCode("FinanceENetMargin")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 62 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\Finence_Executive_Dashboard2.cshtml"
   Write(Html.Raw(FinanceETotalTax.CreateChartCode("FinanceETotalTax")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 63 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\Finence_Executive_Dashboard2.cshtml"
   Write(Html.Raw(FinanceEProfitablyRatio.CreateChartCode("FinanceEProfitablyRatio")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 64 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\Finence_Executive_Dashboard2.cshtml"
   Write(Html.Raw(FinanceECurrentRatio.CreateChartCode("FinanceECurrentRatio")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 65 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\Finence_Executive_Dashboard2.cshtml"
   Write(Html.Raw(FinanceEQuickRatio.CreateChartCode("FinanceEQuickRatio")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n");
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
