#pragma checksum "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\FAFinance_Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c7bd7361b754f8500c0ac643e942e5e5b250bd1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PowerDivChart_FAFinance_Dashboard), @"mvc.1.0.view", @"/Views/PowerDivChart/FAFinance_Dashboard.cshtml")]
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
#line 1 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\FAFinance_Dashboard.cshtml"
using ChartJSCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c7bd7361b754f8500c0ac643e942e5e5b250bd1", @"/Views/PowerDivChart/FAFinance_Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c7fdc47333b1198e8e179737775b19b20ff7a83", @"/Views/_ViewImports.cshtml")]
    public class Views_PowerDivChart_FAFinance_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\FAFinance_Dashboard.cshtml"
  
    ViewData["Title"] = "FAFinance_Dashboard";
    Layout = "~/Views/Shared/Site/_Layout.cshtml";
    Chart MaintenanceCostbyOffice = (Chart)ViewData["MaintenanceCostbyOffice"];
    Chart AssetAcquisitionOfficeWise = (Chart)ViewData["AssetAcquisitionOfficeWise"];
    Chart LandValuebyOffice = (Chart)ViewData["LandValuebyOffice"];
    Chart BookValuevsAccumulatedPrice = (Chart)ViewData["BookValuevsAccumulatedPrice"];
    Chart AssetDisposedAssetWise = (Chart)ViewData["AssetDisposedAssetWise"];
    Chart AssetDisposedOfficeWise = (Chart)ViewData["AssetDisposedOfficeWise"];
    Chart AssetAcquisitionAssetWise = (Chart)ViewData["AssetAcquisitionAssetWise"];
    Chart MaintenanceCostbyMonth = (Chart)ViewData["MaintenanceCostbyMonth"];
    Chart BookValuebyAssetType = (Chart)ViewData["BookValuebyAssetType"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<h4 style=""text-align:center"">Fixed Assets Finance Dashboard</h4>

<div class=""row p-4"">
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Maintenance Cost by Offices (Current FY)</h5>
                <canvas id=""MaintenanceCostbyOffice""></canvas>
            </div>
        </div>

    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Office wise Asset Acquisition Cost (Current FY)</h5>
                <canvas id=""AssetAcquisitionOfficeWise""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Land Value by Offices</h5>
                <canvas id=""LandValuebyOffice""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class");
            WriteLiteral(@"=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Book Value vs Accumulated Price</h5>
                <canvas id=""BookValuevsAccumulatedPrice""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Asset Disposed (Current FY)</h5>
                <canvas id=""AssetDisposedAssetWise""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-6 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Office wise Asset Disposed (Current FY)</h5>
                <canvas id=""AssetDisposedOfficeWise""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-4 p-1"">
        <div class=""card"">
            <div class=""card-body"">
                <h5 class=""card-title"">Asset Acquisition (Current FY)</h5>
                <canvas id=""AssetA");
            WriteLiteral(@"cquisitionAssetWise""></canvas>
            </div>
        </div>
    </div>
    <div class=""col-md-4 p-1"">
            <div class=""card"">
                <div class=""card-body"">
                    <h5 class=""card-title"">Maintenance Cost by Month</h5>
                    <canvas id=""MaintenanceCostbyMonth""></canvas>
                </div>
            </div>
        </div>
    <div class=""col-md-4 p-1"">
            <div class=""card"">
                <div class=""card-body"">
                    <h5 class=""card-title"">Book Value by Asset Type</h5>
                    <canvas id=""BookValuebyAssetType""></canvas>
                </div>
            </div>
        </div>

</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        ");
#nullable restore
#line 99 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\FAFinance_Dashboard.cshtml"
   Write(Html.Raw(MaintenanceCostbyOffice.CreateChartCode("MaintenanceCostbyOffice")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 100 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\FAFinance_Dashboard.cshtml"
   Write(Html.Raw(AssetAcquisitionOfficeWise.CreateChartCode("AssetAcquisitionOfficeWise")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 101 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\FAFinance_Dashboard.cshtml"
   Write(Html.Raw(LandValuebyOffice.CreateChartCode("LandValuebyOffice")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 102 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\FAFinance_Dashboard.cshtml"
   Write(Html.Raw(BookValuevsAccumulatedPrice.CreateChartCode("BookValuevsAccumulatedPrice")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 103 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\FAFinance_Dashboard.cshtml"
   Write(Html.Raw(AssetDisposedAssetWise.CreateChartCode("AssetDisposedAssetWise")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 104 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\FAFinance_Dashboard.cshtml"
   Write(Html.Raw(AssetDisposedOfficeWise.CreateChartCode("AssetDisposedOfficeWise")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 105 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\FAFinance_Dashboard.cshtml"
   Write(Html.Raw(AssetAcquisitionAssetWise.CreateChartCode("AssetAcquisitionAssetWise")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 106 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\FAFinance_Dashboard.cshtml"
   Write(Html.Raw(MaintenanceCostbyMonth.CreateChartCode("MaintenanceCostbyMonth")));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        ");
#nullable restore
#line 107 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\PowerDivChart\FAFinance_Dashboard.cshtml"
   Write(Html.Raw(BookValuebyAssetType.CreateChartCode("BookValuebyAssetType")));

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