using IDTPDashboard.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Interface
{
    public interface IHRManagement_Part2_Repository
    {
        Task<HRManagement_Part2_Entity> GetAllReports(string Organization, string PBSName);
    }
}
