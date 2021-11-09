using IDTPDashboard.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Interface
{
    public interface IPR_Repository
    {
        Task<PR_Entity> GetAllReports(string Organization);
    }
}
