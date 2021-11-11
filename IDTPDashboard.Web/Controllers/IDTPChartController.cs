using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ChartJSCore.Helpers;
using ChartJSCore.Models;
using IDTPDashboard.DataAccess.Interface;
using IDTPDashboard.DataAccess.Repositoty;
using IDTPDashboard.DomainModel.Common;
using IDTPDashboard.DomainModel.Entity;
using IDTPDashboard.Web.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IDTPDashboard.Web.Controllers
{
    [Authorize()]
    public class IDTPChartController : Controller
    {
        private readonly IHRManagement_Repository _repositoryHRManagement;

        public IDTPChartController(
            IHRManagement_Repository repositoryHRManagement)            
        {
            _repositoryHRManagement = repositoryHRManagement ?? throw new ArgumentNullException(nameof(repositoryHRManagement));
        }
        

        #region  IDTPDashboard1
        public async Task<IActionResult> IDTPDashboard1()
        {
            var Organization = HttpContext.User.FindFirstValue("Organization");

            HRManagement_Entity hRManagement_Entity = await _repositoryHRManagement.GetAllReports(Organization);            

            long TotalEmployee = hRManagement_Entity.TotalEmployeeList.FirstOrDefault().totalemployee;
            ViewData["totalemployee"] = Convert.ToDecimal(TotalEmployee).ToString("#,##0");
            // //JS Chartjs
            ViewData["totalEmpUtilityWise"] = hRManagement_Entity.TotalEmployeeUtilityWiseList;
            ViewData["filledPostVacantPosts"] = hRManagement_Entity.FilledPostVacantPostList;
            ViewData["upcommingRetirement"] = hRManagement_Entity.UpcommingRetirementCompanyWiseList;
            ViewData["retirementvsNewEmployee"] = hRManagement_Entity.RetirementvsNewEmployeeList;
            ViewData["foreignTourOrganizationWise"] = hRManagement_Entity.ForeignTourOrganizationWiseList;
            ViewData["netSalaryByMonth"] = hRManagement_Entity.NetSalaryByMonthList;
            ViewData["employeeJobStatusPieChart"] = hRManagement_Entity.EmployeeJobStatusList;
            ViewData["employeeQualifcationPieChart"] = hRManagement_Entity.EmployeeQualifcationList;
            return View();
        }
        #endregion
    }
}
