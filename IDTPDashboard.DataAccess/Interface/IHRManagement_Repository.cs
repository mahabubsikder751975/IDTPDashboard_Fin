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
        // Task<PagedList<DesignationWiseEmpCount>> GetDesignationWiseEmployeeCount(string org, string postType, string filter,int offset, int pageSize);
        // Task<List<OrgPostWiseEmp>> GetPostWiseEmploymentStatus();
        // Task<List<OrgWiseEmpByJobStatus>> GetOrgWiseEmpByJobStatus(string jobStatus);
        // Task<List<OrgWiseEmpByQualification>> GetOrgWiseEmpByQualification(string qualificaion);
        // Task<List<OrgWiseRetirementvsNewEmployee>> GetOrgWiseRetirementvsNewEmployee(string organization);
        // Task<List<DesignationWiseEmpByJobTypeAndOrg>> GetDesignationWiseEmpByJobTypeAndOrg(string org, string jobStatus);
        // Task<List<DesignationWiseEmpByQualificationAndOrg>> GetDesignationWiseEmpByQualificationAndOrg(string org, string qualification);
    }
}
