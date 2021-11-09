using IDTPDashboard.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Interface
{
    public interface IFAManagement_Repository
    {
        Task<FAManagement_Entity> GetAllReports(string Organization);
        Task<List<UsagesWiseLandByOrg>> GetUsagesWiseLandByOrg(string org);
        Task<List<OrgWiseLandByUsages>> GetOrgWiseLandByUsages(string usages);
        Task<List<FuleWiswPPByOrg>> GetFuleWiswPPByOrg(string org);
    }
}
