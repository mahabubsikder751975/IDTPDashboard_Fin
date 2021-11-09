using IDTPDashboard.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Interface
{
    public interface IFAFinance_Repository
    {
         Task<FAFinance_Entity> GetAllReports(string Organization);
    }
}
