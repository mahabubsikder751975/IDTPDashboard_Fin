using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IDTPDashboard.Web.Models
{
    public class GraphViewModel
    {
        public GraphViewModel()
        {
            this.DataItems = new List<SelectListItem>();
        }
        public int Id { get; set; }
        public string GraphName { get; set; }
        public string XAxisTitle { get; set; }
        public string YAxisTitle { get; set; }
        public string ChartType { get; set; }
        public List<SelectListItem> DataItems { get; set; }
        public string[] SelectedDataItems { get; set; }
        public string[] SelectedOrganizations { get; set; }

    }
}
