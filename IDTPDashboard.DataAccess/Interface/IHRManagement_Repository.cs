using IDTPDashboard.DomainModel.Common;
using IDTPDashboard.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Interface
{
    public interface IHRManagement_Repository
    {
        Task<HRManagement_Entity> GetAllReports(string Organization);        
    }
}
