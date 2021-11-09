using IDTPDashboard.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Interface
{
    public interface IFinence_Executive_Repository
    {
        Task<Finence_Executive_Entity> GetAllReports(string Organization);
    }
}
