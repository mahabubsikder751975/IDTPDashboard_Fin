using IDTPDashboard.DataAccess.Interface;
using IDTPDashboard.DomainModel.Entity;
using IDTPDashboard.Web.Helper;
using IDTPDashboard.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IDTPDashboard.Web.Controllers
{
    public class GraphController : Controller
    {
        private readonly IGraphRepository _graphRepository;
       public GraphController(IGraphRepository graphRepository)
        {
            _graphRepository = graphRepository ?? throw new ArgumentNullException(nameof(graphRepository));
        }
        public async Task<IActionResult> Index()
        {
            var companyName = HttpContext.User.FindFirstValue("Organization");
            List<GraphSetup> graphList = await _graphRepository.GetGraphSetupList(companyName);
            
            return View(graphList);
        }
        public IActionResult Create()
        {
            //var companyName = HttpContext.User.FindFirstValue("Organization");
            //var graphItems = await _graphRepository.GetGraphItemList(companyName);
            //List<SelectListItem> items = graphItems.Select(i=>new SelectListItem { Text=i.ParticularName,Value=i.ParticularName}).ToList();

            GraphViewModel graph = new GraphViewModel();
            //graph.DataItems= graphItems.Select(i => new SelectListItem { Text = i.ParticularName, Value = i.ParticularName }).ToList();


            return View(graph);
        }
        [HttpPost]
        public async Task<IActionResult> Create(GraphViewModel model)
        {
            var companyName = HttpContext.User.FindFirstValue("Organization");            
            var graphSetup = new GraphSetup { GraphName = model.GraphName, ChartType = model.ChartType,XAxisTitle=model.XAxisTitle,YAxisTitle=model.YAxisTitle};
            var tableName = (await _graphRepository.GetGraphItemByParticularName(model.SelectedDataItems.First())).TableName;
            var query = QueryHelper.SqlSelectQuery(model.SelectedDataItems, tableName, model.SelectedOrganizations);

            await _graphRepository.InsertGraphSetup(companyName, graphSetup, query);
            return RedirectToAction("Index");
        }

        
        public async Task<JsonResult> GetGraphDataByModule(string module)
        {
            var companyName = HttpContext.User.FindFirstValue("Organization");
            var graphItems = await _graphRepository.GetGraphItemList(companyName);
            //List<SelectListItem> items = graphItems.Select(i=>new SelectListItem { Text=i.ParticularName,Value=i.ParticularName}).ToList();


            var resultData = graphItems.Where(g=>g.Category == module).Select(i => new SelectListItem { Text = i.ParticularName, Value = i.ParticularName }).ToList();

            return Json(resultData);
        }
    }
    
    
}
