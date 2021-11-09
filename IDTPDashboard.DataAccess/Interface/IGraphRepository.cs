using IDTPDashboard.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Interface
{
    public interface IGraphRepository
    {
        Task<List<GraphSetup>> GetGraphSetupList(string Organization);
        Task<List<GraphItem>> GetGraphItemList(string Organization);
        Task InsertGraphSetup(string organization, GraphSetup graphSetup, string dataQuery);
        Task<GraphItem> GetGraphItemByParticularName(string particularName);
    }
}
