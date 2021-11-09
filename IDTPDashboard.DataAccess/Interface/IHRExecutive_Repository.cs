using IDTPDashboard.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Interface
{
    public interface IHRExecutive_Repository
    {
        Task<HRExecutive_Entity> GetAllReports(string Organization);
    }
}
