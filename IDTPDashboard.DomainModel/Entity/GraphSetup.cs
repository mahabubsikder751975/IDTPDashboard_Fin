using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class GraphSetup
    {
        public GraphSetup()
        {
            GraphDataList = new List<GraphData>();
        }
        public int Id { get; set; }
        public string GraphName { get; set; }
        public string ChartType { get; set; }
        public string XAxisTitle { get; set; }
        public string YAxisTitle { get; set; }
        public List<GraphData> GraphDataList { get; set; }       

    }
    public class GraphData
    {
        public string ParticularName { get; set; }
        public long ParticularValue { get; set; }
       
    }
}
