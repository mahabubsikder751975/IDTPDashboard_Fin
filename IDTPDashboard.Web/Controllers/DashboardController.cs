using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IDTPDashboard.DataAccess.Interface;
using IDTPDashboard.DomainModel.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ChartJSCore.Helpers;
using ChartJSCore.Models;
using IDTPDashboard.Web.Helper;

namespace IDTPDashboard.Web.Controllers
{
    [Authorize()]
    public class DashboardController : Controller
    {
        private readonly IMenu_Repository _repository;
       // private readonly IParticularsRepository _particularsRepository;
        private readonly IIDTPDashboard_Repository _repositoryHRManagement;
       // private readonly IFinance_Repository _repositoryFinance;
       // private readonly ILanding_Repository _repositoryLanding;
      //  private readonly IPR_Repository _repositoryPR;
//        private readonly IFAManagement_Repository _repositoryFAManagement;
        public DashboardController(IMenu_Repository repository,
        IIDTPDashboard_Repository repositoryHRManagement
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _repositoryHRManagement = repositoryHRManagement ?? throw new ArgumentNullException(nameof(repositoryHRManagement));
        }
        public async Task<IActionResult> Index()
        {
            var companyName = HttpContext.User.FindFirstValue("Organization");
            List<Menu_Entity> menuList = await _repository.GetAllMenu(companyName);
            return View(menuList);
        }
        #region  PowerDivIndex
        public async Task<IActionResult> PowerDivIndex()
        {
            var companyName = HttpContext.User.FindFirstValue("Organization");
            HRManagement_Entity hRManagement_Entity = await _repositoryHRManagement.GetAllReports(companyName);
            Chart transactionsCountTodayByFI = TransactionsCountTodayByFIPieChart(hRManagement_Entity.TransactionsCountTodayByFIList);
            // Finance_Entity finance_Entity = await _repositoryFinance.GetAllReports(companyName);
            // Chart UtilityWiseTurnover = UtilityWiseTurnoverPieChart(finance_Entity.UtilityWiseTurnoverList.ToList());
            //Chart ExpensevsRevenue = ExpensevsRevenuePieChart(finance_Entity.ExpensevsRevenueList.ToList());
            //Chart ReceivablevsPayable = ReceivablevsPayablePieChart(finance_Entity.ReceivablevsPayableList.ToList());
            // PR_Entity pR_Entity = await _repositoryPR.GetAllReports(companyName);
            // Chart procurementValuebyOffice = ProcurementValuebyOfficePieChart(pR_Entity.ProcurementValuebyOfficeList);
            // FAManagement_Entity fAManagement_Entity = await _repositoryFAManagement.GetAllReports(companyName);
            // Chart fuelWisePowerPlant = FuelWisePowerPlantPieChart(fAManagement_Entity.FuelWisePowerPlantList);

            // Landing_Entity landing_Entity = await _repositoryLanding.GetAllReports();
            // Chart TotalPowerPlants = TotalPowerPlantsPieChart(landing_Entity.TotalPowerPlantList.ToList());
            // Chart TotalInstalledCapacityMW = TotalInstalledCapacityMWPieChart(landing_Entity.TotalInstalledCapacityMWList.ToList());
            // Chart TotalNumberOfUsersByStatus = TotalNumberOfUsersByStatusBarChart(landing_Entity.TotalNumberOfUsersByStatusesList.ToList());
            // Chart TotalExpenceRevenues = TotalExpenceRevenuesPieChart(landing_Entity.TotalExpenceRevenuesList.ToList());
            // Chart APPUtilizedUnutilized = APPUtilizedUnutilizedPieChart(landing_Entity.appUtilizedUnutilizedList.ToList());
            // Chart AccReceivableAndPayable = AccReceivableAndPayableBarChart(landing_Entity.AccReceivableAndPayableList.ToList());
            // Chart FinancialPosition = FinancialPositionBarChart(landing_Entity.FinancialPositionList.ToList());
             List<Menu_Entity> menuList = await _repository.GetAllMenu(companyName);
            // List<Particular> particulars = await _particularsRepository.GetParticulars(companyName);

            ViewData["transactionsCountTodayByFI"] = transactionsCountTodayByFI;
            // ViewData["UtilityWiseTurnover"] = UtilityWiseTurnover;
            // ViewData["procurementValuebyOffice"] = procurementValuebyOffice;
            // ViewData["TotalPowerPlants"] = TotalPowerPlants;
            // ViewData["TotalInstalledCapacityMW"] = TotalInstalledCapacityMW;
            // ViewData["TotalNumberOfUsersByStatus"] = TotalNumberOfUsersByStatus;
            // if (particulars.Count > 0)
            // {
            //     ViewData["ParticularsDate"] = particulars[0].LastUpdatedDate.ToString("dd-MMM-yy");
            //     ViewData["particulars"] = particulars;
            // }           
            // ViewData["totalNumberOfUsersByStatus"] = landing_Entity.TotalNumberOfUsersByStatusesList.ToList();
            // ViewData["TotalExpenceRevenues"] = TotalExpenceRevenues;
            // ViewData["APPUtilizedUnutilized"] = APPUtilizedUnutilized;
            // ViewData["fuelWisePowerPlant"] = fuelWisePowerPlant;
            // ViewData["AccReceivableAndPayable"] = AccReceivableAndPayable;
            // ViewData["FinancialPosition"] = FinancialPosition;

            return View(menuList);
        }
        private Chart TransactionsCountTodayByFIPieChart(List<TransactionsCountTodayByFI> transactionsCountTodayByFI)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = transactionsCountTodayByFI.Select(e => Convert.ToDouble(e.totalemployee)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = transactionsCountTodayByFI.Select(e => e.Organization).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Number of Employees",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart UtilityWiseTurnoverPieChart(List<UtilityWiseTurnover> utilityWiseTurnover)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = utilityWiseTurnover.Select(e => Convert.ToDouble(e.Turnover)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = utilityWiseTurnover.Select(e => e.Organization).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Amount",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart TotalPowerPlantsPieChart(List<TotalPowerPlant> totalPowerPlant)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = totalPowerPlant.Select(e => Convert.ToDouble(e.Number)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = totalPowerPlant.Select(e => e.Type).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Number",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart TotalInstalledCapacityMWPieChart(List<TotalInstalledCapacityMW> totalInstalledCapacityMW)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = totalInstalledCapacityMW.Select(e => Convert.ToDouble(e.InstalledCapacityMW)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = totalInstalledCapacityMW.Select(e => e.Type).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Number",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart TotalNumberOfUsersByStatusBarChart(List<TotalNumberOfUsersByStatus> totalNumberOfUsersByStatus)
        {
            List<double?> EmployeeCount = totalNumberOfUsersByStatus.Select(e => Convert.ToDouble(e.EmployeeCount).ConvertThousand()).Cast<double?>().ToList();
            List<string> Lables = totalNumberOfUsersByStatus.Select(e => e.Type).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Number of Posts",
                Data = EmployeeCount,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#01B8AA"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#01B8AA"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Post", "Number of post in Thousand", dataset1);
        }
        private Chart TotalExpenceRevenuesPieChart(List<TotalExpenceRevenue> totalExpenceRevenue)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> Amount = totalExpenceRevenue.Select(e => Convert.ToDouble(e.Amount).ConvertCrores()).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(Amount.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = totalExpenceRevenue.Select(e => e.Type).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Amount",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = Amount
            };
            return ChartHelper.GeneratePieWithOutLabelChart(Lables, dataset);
        }
        private Chart ProcurementValuebyOfficePieChart(List<ProcurementValuebyOffice> procurementValuebyOffice)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = procurementValuebyOffice.Select(e => Convert.ToDouble(e.Amount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = procurementValuebyOffice.Select(e => e.OfficeName).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Amount",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart APPUtilizedUnutilizedPieChart(List<APPUtilizedUnutilized> aPPUtilizedUnutilized)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = aPPUtilizedUnutilized.Select(e => Convert.ToDouble(e.Amount).ConvertCrores()).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = aPPUtilizedUnutilized.Select(e => e.Type).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Amount",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart FuelWisePowerPlantPieChart(List<FuelWisePowerPlant> fuelWisePowerPlant)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> totalPowerPlant = fuelWisePowerPlant.Select(e => Convert.ToDouble(e.TotalPowerPlant)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(totalPowerPlant.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = fuelWisePowerPlant.Select(e => e.FuelType).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Power Plant",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = totalPowerPlant
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart AccReceivableAndPayableBarChart(List<AccReceivableAndPayable> accReceivableAndPayable)
        {
            List<double?> amount = accReceivableAndPayable.Select(e => Convert.ToDouble(e.Amount).ConvertCrores()).Cast<double?>().ToList();
            List<string> Lables = accReceivableAndPayable.Select(e => e.Type).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Amount",
                Data = amount,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#01B8AA"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#01B8AA"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Accounts", "Amount in Crore Tk", dataset1);
        }
        private Chart FinancialPositionBarChart(List<FinancialPosition> financialPosition)
        {
            List<double?> amount = financialPosition.Select(e => Convert.ToDouble(e.Value).ConvertCrores()).Cast<double?>().ToList();
            List<string> Lables = financialPosition.Select(e => e.AccountCategory).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Amount",
                Data = amount,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#01B8AA"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#01B8AA"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Account Category", "Amount in Crore Tk", dataset1);
        }
        #endregion

        #region  PowerDivIndex
        public async Task<IActionResult> OrgIndex()
        {
            var companyName = HttpContext.User.FindFirstValue("Organization");
            //HRManagement_Entity hRManagement_Entity = await _repositoryHRManagement.GetAllReports(companyName);
            //Chart transactionsCountTodayByFI = TransactionsCountTodayByFIPieChart(hRManagement_Entity.TransactionsCountTodayByFIList);
            //Finance_Entity finance_Entity = await _repositoryFinance.GetAllReports(companyName);
            //Chart UtilityWiseTurnover = UtilityWiseTurnoverPieChart(finance_Entity.UtilityWiseTurnoverList.ToList());
            ////Chart ExpensevsRevenue = ExpensevsRevenuePieChart(finance_Entity.ExpensevsRevenueList.ToList());
            ////Chart ReceivablevsPayable = ReceivablevsPayablePieChart(finance_Entity.ReceivablevsPayableList.ToList());
            //PR_Entity pR_Entity = await _repositoryPR.GetAllReports(companyName);
            //Chart procurementValuebyOffice = ProcurementValuebyOfficePieChart(pR_Entity.ProcurementValuebyOfficeList);
            //FAManagement_Entity fAManagement_Entity = await _repositoryFAManagement.GetAllReports(companyName);
            //Chart fuelWisePowerPlant = FuelWisePowerPlantPieChart(fAManagement_Entity.FuelWisePowerPlantList);

            //Landing_Entity landing_Entity = await _repositoryLanding.GetAllReports();
            //Chart TotalPowerPlants = TotalPowerPlantsPieChart(landing_Entity.TotalPowerPlantList.ToList());
            //Chart TotalInstalledCapacityMW = TotalInstalledCapacityMWPieChart(landing_Entity.TotalInstalledCapacityMWList.ToList());
            //Chart TotalNumberOfUsersByStatus = TotalNumberOfUsersByStatusBarChart(landing_Entity.TotalNumberOfUsersByStatusesList.ToList());
            //Chart TotalExpenceRevenues = TotalExpenceRevenuesPieChart(landing_Entity.TotalExpenceRevenuesList.ToList());
            //Chart APPUtilizedUnutilized = APPUtilizedUnutilizedPieChart(landing_Entity.appUtilizedUnutilizedList.ToList());
            //Chart AccReceivableAndPayable = AccReceivableAndPayableBarChart(landing_Entity.AccReceivableAndPayableList.ToList());
            //Chart FinancialPosition = FinancialPositionBarChart(landing_Entity.FinancialPositionList.ToList());
            List<Menu_Entity> menuList = await _repository.GetAllMenu(companyName);
            //List<Particular> particulars = await _particularsRepository.GetParticulars(companyName);

            ViewData["OrgName"] = companyName;
            //ViewData["transactionsCountTodayByFI"] = transactionsCountTodayByFI;
            //ViewData["UtilityWiseTurnover"] = UtilityWiseTurnover;
            //ViewData["procurementValuebyOffice"] = procurementValuebyOffice;
            //ViewData["TotalPowerPlants"] = TotalPowerPlants;
            //ViewData["TotalInstalledCapacityMW"] = TotalInstalledCapacityMW;
            //ViewData["TotalNumberOfUsersByStatus"] = TotalNumberOfUsersByStatus;
            //ViewData["particulars"] = particulars;
            //ViewData["TotalNumberOfUsersByStatus"] = TotalNumberOfUsersByStatus;
            //ViewData["TotalExpenceRevenues"] = TotalExpenceRevenues;
            //ViewData["APPUtilizedUnutilized"] = APPUtilizedUnutilized;
            //ViewData["fuelWisePowerPlant"] = fuelWisePowerPlant;
            //ViewData["AccReceivableAndPayable"] = AccReceivableAndPayable;
            //ViewData["FinancialPosition"] = FinancialPosition;

            return View(menuList);
        }


        #endregion
    }
}
