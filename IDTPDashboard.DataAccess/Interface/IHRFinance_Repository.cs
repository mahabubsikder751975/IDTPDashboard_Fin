using IDTPDashboard.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Interface
{
    public interface IHRFinance_Repository
    {
        Task<HRFinance_Entity> GetAllReports(string Organization);
        Task<List<OrgWiseNetSalaryByMonth>> GetOrgWiseNetSalaryByMonth(string salaryDate);
    }
}
