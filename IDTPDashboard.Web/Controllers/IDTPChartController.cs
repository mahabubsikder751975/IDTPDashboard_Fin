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
    //[Authorize()]
    public class IDTPChartController : Controller
    {
        private readonly IIDTPDashboard_Repository _repositoryHRManagement;

        public IDTPChartController(
            IIDTPDashboard_Repository repositoryHRManagement)            
        {
            _repositoryHRManagement = repositoryHRManagement ?? throw new ArgumentNullException(nameof(repositoryHRManagement));
        }
        

        #region  IDTPDashboard1
        public async Task<IActionResult> IDTPDashboard1()
        {
            var Organization = "IDTP";//HttpContext.User.FindFirstValue("Organization");

            HRManagement_Entity hRManagement_Entity = await _repositoryHRManagement.GetAllReports(Organization);            

            long TotalNumberOfUsers = hRManagement_Entity.TotalNumberOfUsersList.FirstOrDefault().totalemployee;
            ViewData["totalemployee"] = Convert.ToDecimal(TotalNumberOfUsers).ToString("#,##0");
            // //JS Chartjs
            ViewData["totalEmpUtilityWise"] = hRManagement_Entity.TransactionsCountTodayByFIList;
            ViewData["rtpStatusByFIs"] = hRManagement_Entity.RTPStatusByFIList;
            ViewData["upcommingRetirement"] = hRManagement_Entity.RegisteredUsersByFIList;
            ViewData["netDebitCapPositionByFI"] = hRManagement_Entity.NetDebitCapPositionByFIList;
            ViewData["transactionsAmountTodayByFI"] = hRManagement_Entity.TransactionsAmountTodayByFIList;
            ViewData["transactionAmountBySettlementCycleId"] = hRManagement_Entity.TransactionAmountBySettlementCycleIdList;
            ViewData["transactionsSettledUnsettledPieChart"] = hRManagement_Entity.TransactionsSettledUnsettledList;
            ViewData["transactionCountByTypePieChart"] = hRManagement_Entity.TransactionCountByTypeList;
            return View();
        }
        #endregion
    }
}
