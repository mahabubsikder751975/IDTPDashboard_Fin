#pragma checksum "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\Graph\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b51a22c275cf94f81d0b2d75364b7b527acd256"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Graph_Index), @"mvc.1.0.view", @"/Views/Graph/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b51a22c275cf94f81d0b2d75364b7b527acd256", @"/Views/Graph/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c7fdc47333b1198e8e179737775b19b20ff7a83", @"/Views/_ViewImports.cshtml")]
    public class Views_Graph_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IDTPDashboard.DomainModel.Entity.GraphSetup>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success float-right mb-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Graph", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\Graph\Index.cshtml"
  
    ViewData["Title"] = "Graph List";
    Layout = "~/Views/Shared/Site/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n        <h5>Graph List</h5>\r\n    </div>\r\n    <div class=\"col-md-6 mb-4\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b51a22c275cf94f81d0b2d75364b7b527acd2564471", async() => {
                WriteLiteral("<i class=\"fas fa-plus\"></i> <b>Create new graph</b>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
</div>
<div class=""container mt-1"">
    <table class=""table table-bordered nt-3"">
        <thead class=""thead-light"">
            <tr>
                <th>
                    Graph name
                </th>
                <th>
                    Chart Type
                </th>
                <th>#</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 29 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\Graph\Index.cshtml"
             foreach (var b in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 33 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\Graph\Index.cshtml"
               Write(Html.DisplayFor(modelItem => b.GraphName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 36 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\Graph\Index.cshtml"
               Write(Html.DisplayFor(modelItem => b.ChartType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <button type=\"button\" class=\"btn btn-light float-right\" data-toggle=\"modal\" data-target=\"#myModal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1262, "\"", 1288, 3);
            WriteAttributeValue("", 1272, "showGraph(", 1272, 10, true);
#nullable restore
#line 39 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\Graph\Index.cshtml"
WriteAttributeValue("", 1282, b.Id, 1282, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1287, ")", 1287, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"bi bi-bar-chart\"></i> Show Chart\r\n                    </button>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 44 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\Graph\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>

</div>


<!-- The Modal -->
<div class=""modal fade"" id=""myModal"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content "">
            <!-- Modal Header -->
            <div class=""modal-header"">
                <h4 class=""modal-title"">Chart Detail</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>

            <!-- Modal body -->
            <div class=""modal-body"">
");
            WriteLiteral(@"                <canvas id=""myChart"" style=""width:100%;max-width:600px""></canvas>
            </div>

            <!-- Modal footer -->
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
</div>
<!-- The Modal -->
<script>
    var graphList =");
#nullable restore
#line 76 "C:\Software\IDTPDashboard\IDTPDashboard.Web\Views\Graph\Index.cshtml"
              Write(Html.Raw(Json.Serialize(@Model)));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
    var chart;
    function showGraph(id) {        
        var graph = graphList.filter(g => g.id == id);
        var xValues = graph[0].graphDataList.map(p => p.particularName);
        var yValues = graph[0].graphDataList.map(p => p.particularValue);
        //console.log(graph);
        //var xValues = [""Italy"", ""France"", ""Spain"", ""USA"", ""Argentina""];
        //var yValues = [55, 49, 44, 24, 15];
        var barColors = [""#FE9666"", ""#01B8AA"", ""#698B69"", ""#008080"", ""#007EB9"", ""#5F6B6D"", ""#DFBFBF"", ""#660000"", ""#FFDEAD"", ""#9AFF9A"", ""#4F8E83"", ""#62B1F6"", ""#990099"", ""#9D6B84"", ""#551011""];
        var chartType = graph[0].chartType;
         chart=new Chart(""myChart"", {
            type: chartType,
            data: {
                labels: xValues,
                datasets: [{
                    //label:'Emplo',
                    backgroundColor: '#01B8AA',
                    data: yValues
                }]
            },
            options: {
                plugins: {
        ");
            WriteLiteral(@"            labels: false,
                },
                legend: { display: true },
                title: {
                    display: true,
                    text: graph[0].graphName
                }
            }
        });
    }
    $('#myModal').on('hidden.bs.modal', function (e) {
        // do something
        chart.destroy();
    })
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IDTPDashboard.DomainModel.Entity.GraphSetup>> Html { get; private set; }
    }
}
#pragma warning restore 1591