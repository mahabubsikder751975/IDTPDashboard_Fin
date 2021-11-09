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
        private readonly IHRManagement_Part2_Repository _repositoryHRManagement_Part2;
        private readonly IHRFinance_Repository _repositoryHRFinance;
        private readonly IFAManagement_Repository _repositoryFAManagement;
        private readonly IPR_Repository _repositoryPR;
        private readonly IFAFinance_Repository _repositoryFAFinance;
        private readonly IFinance_Repository _repositoryFinance;
        private readonly IHRExecutive_Repository _repositoryHRExecutive;
        private readonly IFinence_Executive_Repository _repositoryFinence_Executive;

        public IDTPChartController(IHRManagement_Repository repositoryHRManagement,
                                    IHRManagement_Part2_Repository repositoryHRManagement_Part2,
                                    IHRFinance_Repository repositoryHRFinance,
                                    IFAManagement_Repository repositoryFAManagement,
                                    IFAFinance_Repository repositoryFAFinance,
                                    IPR_Repository repositoryPR,
                                    IFinance_Repository repositoryFinance,
                                    IHRExecutive_Repository repositoryHRExecutive,
                                    IFinence_Executive_Repository repositoryFinence_Executive
                                    )
            
        {
            _repositoryHRManagement = repositoryHRManagement ?? throw new ArgumentNullException(nameof(repositoryHRManagement));
            _repositoryHRManagement_Part2 = repositoryHRManagement_Part2 ?? throw new ArgumentNullException(nameof(_repositoryHRManagement_Part2));
            _repositoryHRFinance = repositoryHRFinance ?? throw new ArgumentNullException(nameof(repositoryHRFinance));
            _repositoryFAManagement = repositoryFAManagement ?? throw new ArgumentNullException(nameof(repositoryFAManagement));
            _repositoryPR = repositoryPR ?? throw new ArgumentNullException(nameof(repositoryPR));
            _repositoryFAFinance = repositoryFAFinance ?? throw new ArgumentNullException(nameof(repositoryFAFinance));
            _repositoryFinance = repositoryFinance ?? throw new ArgumentNullException(nameof(repositoryFinance));
            _repositoryHRExecutive = repositoryHRExecutive ?? throw new ArgumentNullException(nameof(repositoryHRExecutive));
            _repositoryFinence_Executive = repositoryFinence_Executive ?? throw new ArgumentNullException(nameof(repositoryFinence_Executive));
        }
        

        #region  HRManagement_Dashboard
        public async Task<IActionResult> HRManagement_Dashboard()
        {
            var Organization = HttpContext.User.FindFirstValue("Organization");

            HRManagement_Entity hRManagement_Entity = await _repositoryHRManagement.GetAllReports(Organization);
            Chart attendanceInfo = AttendanceInfoBarChart(hRManagement_Entity.EmployeeAttendanceList);
            Chart retirementvsNewEmployee = RetirementvsNewEmployeeBarChart(hRManagement_Entity.RetirementvsNewEmployeeList);
            Chart foreignTourOrganizationWise = ForeignTourOrganizationWiseBarChart(hRManagement_Entity.ForeignTourOrganizationWiseList);
            Chart employeeOnLeave = EmployeeOnLeaveBarChart(hRManagement_Entity.EmployeeOnLeaveList);
            Chart filledPostVacantPosts = FilledPostVacantPostBarChart(hRManagement_Entity.FilledPostVacantPostList);
            Chart filledPostVacantPostUtilityWise = FilledPostVacantPostUtilityWiseBarChart(hRManagement_Entity.FilledPostVacantPostUtilityWiseList);
            Chart upcommingRetirement = UpcommingRetirementBarChart(hRManagement_Entity.UpcommingRetirementCompanyWiseList);
            Chart totalEmployeeUtilityWise = TotalEmployeeUtilityWiseBarChart(hRManagement_Entity.TotalEmployeeUtilityWiseList);
            Chart utilitywiseLastFiscalYearSalary = UtilitywiseLastFiscalYearSalaryBarChart(hRManagement_Entity.UtilitywiseLastFiscalYearSalaryList);
            Chart employeePerformancePieChart = EmployeePerformancePieChart(hRManagement_Entity.EmployeePerformanceList);
            Chart employeeJobStatusPieChart = EmployeeJobStatusPieChart(hRManagement_Entity.EmployeeJobStatusList);
            Chart employeeQualifcationPieChart = EmployeeQualifcationPieChart(hRManagement_Entity.EmployeeQualifcationList);
            Chart foreignTourCategoryWisePieChart = ForeignTourCategoryWisePieChart(hRManagement_Entity.ForeignTourCategoryWiseList);
            Chart foreignTourPurposeWiseOfficialPieChart = ForeignTourPurposeWiseOfficialPieChart(hRManagement_Entity.ForeignTourPurposeWiseOfficialList);
            Chart foreignTourPurposeWisePersonalPieChart = ForeignTourPurposeWisePersonalPieChart(hRManagement_Entity.ForeignTourPurposeWisePersonalList);

            //HRE
            HRExecutive_Entity hRExecutive_Entity = await _repositoryHRExecutive.GetAllReports(Organization);
            Chart EmployeeAgeRange = EmployeeAgeRangeBarChart(hRExecutive_Entity.EmployeeAgeRangeList.ToList());
            Chart EmployeeAgeRangeGenderWise = EmployeeAgeRangeGenderWiseBarChart(hRExecutive_Entity.EmployeeAgeRangeGenderWiseList.ToList());
            Chart EmployeeYearsofService = EmployeeYearsofServiceBarChart(hRExecutive_Entity.EmployeeYearsofServiceList.ToList());
            Chart YearlyTurnover = YearlyTurnoverBarChart(hRExecutive_Entity.YearlyTurnoverList.OrderBy(e => e.Order).ToList());
            Chart YearlyRecruitment = YearlyRecruitmentBarChart(hRExecutive_Entity.YearlyRecruitmentList.OrderBy(e => e.Order).ToList());
            Chart YearlyTermination = YearlyTerminationBarChart(hRExecutive_Entity.YearlyTerminationList.OrderBy(e => e.Order).ToList());
            Chart YearlyPromotion = YearlyPromotionBarChart(hRExecutive_Entity.YearlyPromotionList.OrderBy(e => e.Order).ToList());
            Chart EmployeebyCategory = EmployeebyCategoryPieChart(hRExecutive_Entity.EmployeebyCategoryList);
            Chart MaleFemaleRatioBoth = MaleFemaleRatioPieChart(hRExecutive_Entity.MaleFemaleRatioBothList);
            Chart MaleFemaleRatioOfficer = MaleFemaleRatioPieChart(hRExecutive_Entity.MaleFemaleRatioOfficerList);
            Chart MaleFemaleRatioStaff = MaleFemaleRatioPieChart(hRExecutive_Entity.MaleFemaleRatioStaffList);
            Chart RetirementvsTerminatedOverall = RetirementvsTerminatedOverallPieChart(hRExecutive_Entity.RetirementvsTerminatedOverallList);
            Chart TechnicalNonTechnicalCadrewiseinformation = TechnicalNonTechnicalCadrewiseinformationBarChart(hRExecutive_Entity.TechnicalNonTechnicalCadrewiseinformationList.ToList());

            //HRF
            HRFinance_Entity hRFinance_Entity = await _repositoryHRFinance.GetAllReports(Organization);
            Chart salaryByEmployeeCategory = SalaryByEmployeeCategoryStackedBarChart(hRFinance_Entity.SalaryByEmployeeCategoryList);
            Chart netSalaryByMonth = NetSalaryByMonthBarChart(hRFinance_Entity.NetSalaryByMonthList);
            Chart allowanceDeductionByMonth = AllowanceDeductionByMonthStackedBarChart(hRFinance_Entity.AllowanceDeductionByMonthList);
            Chart salaryByOffices = SalaryByOfficesBarChart(hRFinance_Entity.SalaryByOfficesList);
            Chart grossSalaryExpenditurePieChart = GrossSalaryExpenditurePieChart(hRFinance_Entity.GrossSalaryExpenditureList);
            Chart festivalBonusPieChart = FestivalBonusPieChart(hRFinance_Entity.FestivalBonusList);
            Chart cPFContributionPieChart = CPFContributionPieChart(hRFinance_Entity.CPFContributionList);

            long TotalEmployee = hRManagement_Entity.TotalEmployeeList.FirstOrDefault().totalemployee;
            ViewData["totalemployee"] = Convert.ToDecimal(TotalEmployee).ToString("#,##0");
            ViewData["attendanceInfo"] = attendanceInfo;
            //ViewData["retirementvsNewEmployee"] = retirementvsNewEmployee;
            //ViewData["foreignTourOrganizationWise"] = foreignTourOrganizationWise;
            ViewData["employeeOnLeave"] = employeeOnLeave;
            ViewData["filledPostVacantPosts"] = filledPostVacantPosts;
            ViewData["filledPostVacantPostUtilityWise"] = filledPostVacantPostUtilityWise;
            ViewData["upcommingRetirement"] = upcommingRetirement;
            ViewData["totalEmployeeUtilityWise"] = totalEmployeeUtilityWise;
            ViewData["utilitywiseLastFiscalYearSalary"] = utilitywiseLastFiscalYearSalary;
            ViewData["employeePerformancePieChart"] = employeePerformancePieChart;
            //ViewData["employeeJobStatusPieChart"] = employeeJobStatusPieChart;
            //ViewData["employeeQualifcationPieChart"] = employeeQualifcationPieChart;
            ViewData["foreignTourCategoryWisePieChart"] = foreignTourCategoryWisePieChart;
            ViewData["foreignTourPurposeWiseOfficialPieChart"] = foreignTourPurposeWiseOfficialPieChart;
            ViewData["foreignTourPurposeWisePersonalPieChart"] = foreignTourPurposeWisePersonalPieChart;

            //HRE
            ViewData["EmployeeAgeRange"] = EmployeeAgeRange;
            ViewData["EmployeeYearsofService"] = EmployeeYearsofService;
            ViewData["YearlyTurnover"] = YearlyTurnover;
            ViewData["YearlyRecruitment"] = YearlyRecruitment;
            ViewData["YearlyTermination"] = YearlyTermination;
            ViewData["YearlyPromotion"] = YearlyPromotion;
            ViewData["EmployeebyCategory"] = EmployeebyCategory;
            ViewData["MaleFemaleRatioBoth"] = MaleFemaleRatioBoth;
            ViewData["MaleFemaleRatioOfficer"] = MaleFemaleRatioOfficer;
            ViewData["MaleFemaleRatioStaff"] = MaleFemaleRatioStaff;
            ViewData["EmployeeAgeRangeGenderWise"] = EmployeeAgeRangeGenderWise;
            ViewData["RetirementvsTerminatedOverall"] = RetirementvsTerminatedOverall;
            ViewData["TechnicalNonTechnicalCadrewiseinformation"] = TechnicalNonTechnicalCadrewiseinformation;

            //HEF
            ViewData["salaryByEmployeeCategory"] = salaryByEmployeeCategory;
            //ViewData["netSalaryByMonth"] = netSalaryByMonth;
            ViewData["allowanceDeductionByMonth"] = allowanceDeductionByMonth;
            ViewData["salaryByOffices"] = salaryByOffices;
            ViewData["grossSalaryExpenditurePieChart"] = grossSalaryExpenditurePieChart;
            ViewData["festivalBonusPieChart"] = festivalBonusPieChart;
            ViewData["cPFContributionPieChart"] = cPFContributionPieChart;
            //JS Chartjs
            ViewData["totalEmpUtilityWise"] = hRManagement_Entity.TotalEmployeeUtilityWiseList;
            ViewData["filledPostVacantPosts"] = hRManagement_Entity.FilledPostVacantPostList;
            ViewData["upcommingRetirement"] = hRManagement_Entity.UpcommingRetirementCompanyWiseList;
            ViewData["retirementvsNewEmployee"] = hRManagement_Entity.RetirementvsNewEmployeeList;
            ViewData["foreignTourOrganizationWise"] = hRManagement_Entity.ForeignTourOrganizationWiseList;
            ViewData["netSalaryByMonth"] = hRFinance_Entity.NetSalaryByMonthList;
            //ViewData["netSalaryByMonth"] = hRManagement_Entity.UtilitywiseLastFiscalYearSalaryList;
            ViewData["employeeJobStatusPieChart"] = hRManagement_Entity.EmployeeJobStatusList;
            ViewData["employeeQualifcationPieChart"] = hRManagement_Entity.EmployeeQualifcationList;
            return View();
        }
        private Chart AttendanceInfoBarChart(List<EmployeeAttendance> attendances)
        {
            List<double?> presentValue = attendances.Select(e => Convert.ToDouble(e.Present)).Cast<double?>().ToList();
            List<double?> absentValue = attendances.Select(e => Convert.ToDouble(e.Absent)).Cast<double?>().ToList();
            List<string> Lables = attendances.Select(e => e.PostType).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Present",
                Data = presentValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Absent",
                Data = absentValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#01B8AA"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromRgb(54, 162, 235),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Post Type", "Employee Count", dataset1, dataset2);
        }
        private Chart RetirementvsNewEmployeeBarChart(List<RetirementvsNewEmployee> retirementvsNewEmployee)
        {
            List<double?> retirementValue = retirementvsNewEmployee.Select(e => Convert.ToDouble(e.Retirement)).Cast<double?>().ToList();
            List<double?> newemployeeValue = retirementvsNewEmployee.Select(e => Convert.ToDouble(e.NewEmployee)).Cast<double?>().ToList();
            List<string> Lables = retirementvsNewEmployee.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Retirement",
                Data = retirementValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset2 = new BarDataset()
            {
                Label = "New Employee",
                Data = newemployeeValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#01B8AA"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromRgb(54, 162, 235),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateStackedBarWithOutLabelChart(Lables, "Utilities", "Number of Employees ", dataset1, dataset2);
        }
        private Chart ForeignTourOrganizationWiseBarChart(List<ForeignTourOrganizationWise> foreignTourOrganizationWise)
        {
            List<double?> TotalTour = foreignTourOrganizationWise.Select(e => Convert.ToDouble(e.TourCount)).Cast<double?>().ToList();
            List<string> Lables = foreignTourOrganizationWise.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Number of Foreign Tour",
                Data = TotalTour,
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

            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Number of Foreign Tour", dataset1);
        }
        private Chart EmployeeOnLeaveBarChart(List<EmployeeOnLeave> employeeOnLeaves)
        {
            List<double?> officerOnLeave = employeeOnLeaves.Select(e => Convert.ToDouble(e.OfficersOnLeave)).Cast<double?>().ToList();
            List<double?> staffOnLeave = employeeOnLeaves.Select(e => Convert.ToDouble(e.StaffOnLeave)).Cast<double?>().ToList();
            List<string> Lables = employeeOnLeaves.Select(e => e.OfficeName).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Officers On Leave",
                Data = officerOnLeave,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Staff On Leave",
                Data = staffOnLeave,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#01B8AA"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromRgb(54, 162, 235),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, GetXaxisLable(), "Employee Count", dataset1, dataset2);
        }
        private Chart FilledPostVacantPostBarChart(List<FilledPostVacantPost> filledPostVacantPosts)
        {
            List<double?> sanctionPostsValue = filledPostVacantPosts.Select(e => Convert.ToDouble(e.SanctionPosts)).Cast<double?>().ToList();
            List<double?> filledPostsValue = filledPostVacantPosts.Select(e => Convert.ToDouble(e.FilledPosts)).Cast<double?>().ToList();
            List<double?> vacantPostsValue = filledPostVacantPosts.Select(e => Convert.ToDouble(e.VacantPosts)).Cast<double?>().ToList();
            List<string> Lables = filledPostVacantPosts.Select(e => e.PostType).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Sanction Posts",
                Data = sanctionPostsValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Filled Posts",
                Data = filledPostsValue,
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
            BarDataset dataset3 = new BarDataset()
            {
                Label = "Vacant Posts",
                Data = vacantPostsValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Post Type", "Number of Posts", dataset1, dataset2, dataset3);
        }
        private Chart FilledPostVacantPostUtilityWiseBarChart(List<FilledPostVacantPostUtilityWise> filledPostVacantPostUtilityWise)
        {
            //List<double?> sanctionPostsValue = filledPostVacantPostUtilityWise.Select(e => Convert.ToDouble(e.SanctionPosts)).Cast<double?>().ToList();
            List<double?> filledPostsValue = filledPostVacantPostUtilityWise.Select(e => Convert.ToDouble(e.FilledPosts)).Cast<double?>().ToList();
            List<double?> vacantPostsValue = filledPostVacantPostUtilityWise.Select(e => Convert.ToDouble(e.VacantPosts)).Cast<double?>().ToList();
            List<string> Lables = filledPostVacantPostUtilityWise.Select(e => e.Organization).ToList();
            //BarDataset dataset1 = new BarDataset()
            //{
            //    Label = "Sanction Posts",
            //    Data = sanctionPostsValue,
            //    BackgroundColor = new List<ChartColor>
            //    {
            //        ChartColor.FromHexString("#FE9666"),
            //    },
            //    BorderColor = new List<ChartColor>
            //    {
            //       ChartColor.FromHexString("#FE9666"),
            //    },
            //    BorderWidth = new List<int>() { 1 }
            //};
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Filled Posts",
                Data = filledPostsValue,
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
            BarDataset dataset3 = new BarDataset()
            {
                Label = "Vacant Posts",
                Data = vacantPostsValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateStackedBarWithOutLabelChart(Lables, "Utilities", "Number of Posts", dataset2, dataset3);
        }
        private Chart UpcommingRetirementBarChart(List<UpcommingRetirementCompanyWise> upcommingRetirements)
        {
            List<double?> countValue = upcommingRetirements.Select(e => Convert.ToDouble(e.Employee)).Cast<double?>().ToList();
            List<string> Lables = upcommingRetirements.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Employee Count",
                Data = countValue,
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

            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Number of Employees", dataset1);
        }
        private Chart TotalEmployeeUtilityWiseBarChart(List<TotalEmployeeUtilityWise> totalEmployeeUtilityWise)
        {
            List<double?> totalemployeeValue = totalEmployeeUtilityWise.Select(e => Convert.ToDouble(e.totalemployee)).Cast<double?>().ToList();
            List<string> Lables = totalEmployeeUtilityWise.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Employee Count",
                Data = totalemployeeValue,
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

            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Number of Employees", dataset1);
        }
        private Chart UtilitywiseLastFiscalYearSalaryBarChart(List<UtilitywiseLastFiscalYearSalary> utilitywiseLastFiscalYearSalary)
        {
            List<double?> TotalSalaryValue = utilitywiseLastFiscalYearSalary.Select(e => Convert.ToDouble(e.TotalSalary).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = utilitywiseLastFiscalYearSalary.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Amount",
                Data = TotalSalaryValue,
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

            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Salary Amount (in million Taka)", dataset1);
           // return ChartHelper.GenerateBarChart(Lables, "Utility", "Salary Amount (in million Taka)", dataset1).AddMillionWithYaxes();
        }
        private Chart EmployeePerformancePieChart(List<EmployeePerformance> employeePerformances)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = employeePerformances.Select(e => Convert.ToDouble(e.NoOfOfficers)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = employeePerformances.Select(e => e.ScoreRange).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Employee Count",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart EmployeeJobStatusPieChart(List<EmployeeJobStatus> employeeJobStatuses)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = employeeJobStatuses.Select(e => Convert.ToDouble(e.TotalEmployee)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = employeeJobStatuses.Select(e => e.JobStatus).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Employee Count",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart EmployeeQualifcationPieChart(List<EmployeeQualifcation> employeeQualifcations)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = employeeQualifcations.Select(e => Convert.ToDouble(e.Total)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = employeeQualifcations.Select(e => e.Qualification).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Employee Count",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart ForeignTourCategoryWisePieChart(List<ForeignTourCategoryWise> foreignTourCategoryWise)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> TotalTourValue = foreignTourCategoryWise.Select(e => Convert.ToDouble(e.TotalTour)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(TotalTourValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = foreignTourCategoryWise.Select(e => e.TourCategory).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Total Tour",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = TotalTourValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart ForeignTourPurposeWiseOfficialPieChart(List<ForeignTourPurposeWiseOfficial> foreignTourPurposeWiseOfficial)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> TotalTourValue = foreignTourPurposeWiseOfficial.Select(e => Convert.ToDouble(e.TotalTour)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(TotalTourValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = foreignTourPurposeWiseOfficial.Select(e => e.TourPurpose).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Total Tour",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = TotalTourValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart ForeignTourPurposeWisePersonalPieChart(List<ForeignTourPurposeWisePersonal> foreignTourPurposeWisePersonal)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> TotalTourValue = foreignTourPurposeWisePersonal.Select(e => Convert.ToDouble(e.TotalTour)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(TotalTourValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = foreignTourPurposeWisePersonal.Select(e => e.TourPurpose).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Total Tour",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = TotalTourValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }

        //HRE
        private Chart EmployeeAgeRangeBarChart(List<EmployeeAgeRange> EmployeeAgeRange)
        {
            List<double?> Count = EmployeeAgeRange.Select(e => Convert.ToDouble(e.Count)).Cast<double?>().ToList();
            List<string> Lables = EmployeeAgeRange.Select(e => e.Age).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Number of Employees",
                Data = Count,
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

            return ChartHelper.GenerateBarChart(Lables, "Age", "Number of Employees", dataset1);
        }
        private Chart EmployeeYearsofServiceBarChart(List<EmployeeYearsofService> EmployeeYearsofService)
        {
            List<double?> Engineer = EmployeeYearsofService.Select(e => Convert.ToDouble(e.Engineer)).Cast<double?>().ToList();
            List<double?> Admin = EmployeeYearsofService.Select(e => Convert.ToDouble(e.Admin)).Cast<double?>().ToList();
            List<double?> Finance = EmployeeYearsofService.Select(e => Convert.ToDouble(e.Finance)).Cast<double?>().ToList();
            List<string> Lables = EmployeeYearsofService.Select(e => e.Age).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Engineers",
                Data = Engineer,
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
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Admin",
                Data = Admin,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset3 = new BarDataset()
            {
                Label = "Finance",
                Data = Finance,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            return ChartHelper.GenerateStackedBarChart(Lables, "Year of Service", "Number of Employees(Cader wise)", dataset1, dataset2, dataset3);
        }
        private Chart YearlyTurnoverBarChart(List<YearlyTurnover> YearlyTurnover)
        {
            List<double?> Count = YearlyTurnover.Select(e => Convert.ToDouble(e.Count)).Cast<double?>().ToList();
            List<string> Lables = YearlyTurnover.Select(e => e.Month).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Number of Employees",
                Data = Count,
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

            return ChartHelper.GenerateBarChart(Lables, "Month", "Number of Employees", dataset1);
        }
        private Chart YearlyRecruitmentBarChart(List<YearlyRecruitment> YearlyRecruitment)
        {
            List<double?> Count = YearlyRecruitment.Select(e => Convert.ToDouble(e.Count)).Cast<double?>().ToList();
            List<string> Lables = YearlyRecruitment.Select(e => e.Month).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Number of Employees",
                Data = Count,
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

            return ChartHelper.GenerateBarChart(Lables, "Month", "Number of Employees", dataset1);
        }
        private Chart YearlyTerminationBarChart(List<YearlyTermination> YearlyTermination)
        {
            List<double?> Count = YearlyTermination.Select(e => Convert.ToDouble(e.Count)).Cast<double?>().ToList();
            List<string> Lables = YearlyTermination.Select(e => e.Month).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Number of Employees",
                Data = Count,
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

            return ChartHelper.GenerateBarChart(Lables, "Month", "Number of Employees", dataset1);
        }
        private Chart YearlyPromotionBarChart(List<YearlyPromotion> YearlyPromotion)
        {
            List<double?> Count = YearlyPromotion.Select(e => Convert.ToDouble(e.Count)).Cast<double?>().ToList();
            List<string> Lables = YearlyPromotion.Select(e => e.Month).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Number of Employees",
                Data = Count,
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

            return ChartHelper.GenerateBarChart(Lables, "Month", "Number of Employees", dataset1);
        }
        private Chart EmployeebyCategoryPieChart(List<EmployeebyCategory> EmployeebyCategory)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> Count = EmployeebyCategory.Select(e => Convert.ToDouble(e.Count)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(Count.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = EmployeebyCategory.Select(e => e.Category).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Number of Employees",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = Count
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart MaleFemaleRatioPieChart(List<MaleFemaleRatio> MaleFemaleRatio)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> EmpCount = MaleFemaleRatio.Select(e => Convert.ToDouble(e.EmpCount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(EmpCount.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = MaleFemaleRatio.Select(e => e.Gender).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Number of Employees",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = EmpCount
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart EmployeeAgeRangeGenderWiseBarChart(List<EmployeeAgeRangeGenderWise> employeeAgeRangeGenderWise)
        {
            List<double?> MaleValue = employeeAgeRangeGenderWise.Select(e => Convert.ToDouble(e.Male)).Cast<double?>().ToList();
            List<double?> FemaleValue = employeeAgeRangeGenderWise.Select(e => Convert.ToDouble(e.Female)).Cast<double?>().ToList();
            List<string> Lables = employeeAgeRangeGenderWise.Select(e => e.Age).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Male",
                Data = MaleValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Female",
                Data = FemaleValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#01B8AA"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromRgb(54, 162, 235),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Age", "Employee Count", dataset1, dataset2);
        }
        private Chart RetirementvsTerminatedOverallPieChart(List<RetirementvsTerminatedOverall> RetirementvsTerminatedOverall)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> EmpCount = RetirementvsTerminatedOverall.Select(e => Convert.ToDouble(e.EmpCount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(EmpCount.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = RetirementvsTerminatedOverall.Select(e => e.EmpStatus).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Number of Employees",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = EmpCount
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart TechnicalNonTechnicalCadrewiseinformationBarChart(List<TechnicalNonTechnicalCadrewiseinformation> technicalNonTechnicalCadrewiseinformation)
        {
            List<double?> OfficerValue = technicalNonTechnicalCadrewiseinformation.Select(e => Convert.ToDouble(e.Officer)).Cast<double?>().ToList();
            List<double?> StaffValue = technicalNonTechnicalCadrewiseinformation.Select(e => Convert.ToDouble(e.Staff)).Cast<double?>().ToList();
            List<string> Lables = technicalNonTechnicalCadrewiseinformation.Select(e => e.DesignationType).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Officer",
                Data = OfficerValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Staff",
                Data = StaffValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#01B8AA"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromRgb(54, 162, 235),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Designation Type", "Employee Count", dataset1, dataset2);
        }

        //HRF
        private Chart SalaryByEmployeeCategoryStackedBarChart(List<SalaryByEmployeeCategory> salaryByEmployeeCategories)
        {
            List<double?> technicalValue = salaryByEmployeeCategories.Select(e => e.Technical.ConvertMillions()).Cast<double?>().ToList();
            List<double?> casualDailyBasisValue = salaryByEmployeeCategories.Select(e => e.CasualDailyBasis.ConvertMillions()).Cast<double?>().ToList();
            List<double?> consultantValue = salaryByEmployeeCategories.Select(e => e.Consultant.ConvertMillions()).Cast<double?>().ToList();
            List<double?> contractualValue = salaryByEmployeeCategories.Select(e => e.Contractual.ConvertMillions()).Cast<double?>().ToList();
            List<double?> musterRollValue = salaryByEmployeeCategories.Select(e => e.MusterRoll.ConvertMillions()).Cast<double?>().ToList();
            List<double?> permanentValue = salaryByEmployeeCategories.Select(e => e.Permanent.ConvertMillions()).Cast<double?>().ToList();

            List<string> Lables = salaryByEmployeeCategories.Select(e => e.OfficeName).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Apprentice (Technical)",
                Data = technicalValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Casual-Daily Basis",
                Data = casualDailyBasisValue,
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
            BarDataset dataset3 = new BarDataset()
            {
                Label = "Consultant",
                Data = consultantValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset4 = new BarDataset()
            {
                Label = "Contractual Employees",
                Data = contractualValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#008080"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#008080"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset5 = new BarDataset()
            {
                Label = "Muster Roll Employees",
                Data = musterRollValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#007EB9"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#007EB9"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset6 = new BarDataset()
            {
                Label = "Permanent Employees",
                Data = permanentValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#5F6B6D"),
                },
                BorderColor = new List<ChartColor>
                {
                     ChartColor.FromHexString("#5F6B6D"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateStackedBarChart(Lables, GetXaxisLable(), "Amount", dataset1, dataset2, dataset3, dataset4, dataset5, dataset6).AddMillionWithYaxes();
        }
        private Chart NetSalaryByMonthBarChart(List<NetSalaryByMonth> netSalaryByMonths)
        {
            List<double?> totalSalaryValue = netSalaryByMonths.OrderByDescending(e => e.SequenceNo).Select(e => e.TotalSalary.ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = netSalaryByMonths.OrderByDescending(e => e.SequenceNo).Select(e => e.SalaryDate).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Month",
                Data = totalSalaryValue,
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
            return ChartHelper.GenerateBarChart(Lables, "Salary Period", "Salary Amount (in million Taka)", dataset1);
            //return ChartHelper.GenerateBarChart(Lables, "Salary Period", "Salary Amount (in million Taka)", dataset1).AddMillionWithYaxes();

        }
        private Chart AllowanceDeductionByMonthStackedBarChart(List<AllowanceDeductionByMonth> allowanceDeductionByMonths)
        {
            List<double?> houseRentAllowanceValue = allowanceDeductionByMonths.Select(e => Convert.ToDouble(e.HouseRentAllowance).ConvertMillions()).Cast<double?>().ToList();
            List<double?> transportAllowanceValue = allowanceDeductionByMonths.Select(e => Convert.ToDouble(e.TransportAllowance).ConvertMillions()).Cast<double?>().ToList();
            List<double?> medicalAllowanceValue = allowanceDeductionByMonths.Select(e => Convert.ToDouble(e.MedicalAllowance).ConvertMillions()).Cast<double?>().ToList();
            List<double?> cPFContributionValue = allowanceDeductionByMonths.Select(e => Convert.ToDouble(e.CPFContribution).ConvertMillions()).Cast<double?>().ToList();
            List<double?> tDSValue = allowanceDeductionByMonths.Select(e => Convert.ToDouble(e.TDS).ConvertMillions()).Cast<double?>().ToList();

            List<string> Lables = allowanceDeductionByMonths.Select(e => e.OfficeName).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "House Rent Allowance",
                Data = houseRentAllowanceValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Transport Allowance",
                Data = transportAllowanceValue,
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
            BarDataset dataset3 = new BarDataset()
            {
                Label = "Medical Allowance",
                Data = medicalAllowanceValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset4 = new BarDataset()
            {
                Label = "CPF Contribution",
                Data = cPFContributionValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#008080"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#008080"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset5 = new BarDataset()
            {
                Label = "TDS",
                Data = tDSValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#007EB9"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#007EB9"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            //return ChartHelper.GenerateStackedBarChart(Lables, GetXaxisLable(), "Amount", dataset1, dataset2, dataset3, dataset4, dataset5).AddMillionWithYaxes();
            return ChartHelper.GenerateStackedBarChart(Lables, GetXaxisLable(), "Amount", dataset1, dataset2, dataset3, dataset4, dataset5);
        }
        private Chart SalaryByOfficesBarChart(List<SalaryByOffices> salaryByOffices)
        {
            List<double?> totalSalaryValue = salaryByOffices.Select(e => Convert.ToDouble(e.TotalSalary).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = salaryByOffices.Select(e => e.OfficeName).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = GetXaxisLable(),
                Data = totalSalaryValue,
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

            return ChartHelper.GenerateBarChart(Lables, "Utility", "Salary Amount (in million Taka)", dataset1);
            //return ChartHelper.GenerateBarChart(Lables, "Utility", "Salary Amount (in million Taka)", dataset1).AddMillionWithYaxes();
        }
        private Chart GrossSalaryExpenditurePieChart(List<GrossSalaryExpenditure> grossSalaryExpenditures)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> amountValue = grossSalaryExpenditures.Select(e => Convert.ToDouble(e.Amount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(amountValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = grossSalaryExpenditures.Select(e => e.ExpenditureType).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Expenditure Type",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = amountValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart FestivalBonusPieChart(List<FestivalBonus> festivalBonus)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> amountValue = festivalBonus.Select(e => Convert.ToDouble(e.BonusAmount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(amountValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = festivalBonus.Select(e => e.BonusName).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Bonus",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = amountValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart CPFContributionPieChart(List<CPFContribution> cPFContributions)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> amountValue = cPFContributions.Select(e => Convert.ToDouble(e.Amount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(amountValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = cPFContributions.Select(e => e.OfficeName).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = amountValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        #endregion

        #region  FAManagement_Dashboard
        public async Task<IActionResult> FAManagement_Dashboard()
        {
            var Organization = HttpContext.User.FindFirstValue("Organization");

            FAManagement_Entity fAManagement_Entity = await _repositoryFAManagement.GetAllReports(Organization);
            Chart insuredNonInsuredAssets = InsuredNonInsuredAssetBarChart(fAManagement_Entity.InsuredNonInsuredAssetsList.OrderByDescending(e => e.SequenceNo).ToList());
            Chart serviceLifeAnalyses = ServiceLifeAnalysisBarChart(fAManagement_Entity.ServiceLifeAnalysesList);
            Chart operationalNonOperationalTransformer = OperationalNonOperationalTransformerBarChart(fAManagement_Entity.OperationalNonOperationalTransformerList);
            Chart landUsagesbyOffice = LandUsagesbyOfficeBarChart(fAManagement_Entity.LandUsagesbyOfficeList);
            Chart transformerOperationalAnalysisbyOffice = TransformerOperationalAnalysisbyOfficeBarChart(fAManagement_Entity.TransformerOperationalAnalysisbyOfficeList);
            Chart transformerOperationalAnalysisbyMonth = TransformerOperationalAnalysisbyMonthBarChart(fAManagement_Entity.TransformerOperationalAnalysisbyMonthList.OrderByDescending(e => e.SequenceNo).ToList());
            Chart landAreabyOfficePieChart = LandAreabyOfficePieChart(fAManagement_Entity.LandAreabyOfficeList);
            Chart landEncroachmentRatioPieChart = LandEncroachmentRatioPieChart(fAManagement_Entity.LandEncroachmentRatioList);
            Chart subStationsbyOfficePieChart = SubStationsbyOfficePieChart(fAManagement_Entity.SubStationsbyOfficeList);
            Chart utilitywiseTotalLand = UtilitywiseTotalLandBarChart(fAManagement_Entity.UtilitywiseTotalLandList);
            Chart totalLandbyUsages = TotalLandbyUsagesBarChart(fAManagement_Entity.TotalLandbyUsagesList);
            Chart utilitywiseTotalBuilding = UtilitywiseTotalBuildingBarChart(fAManagement_Entity.UtilitywiseTotalBuildingList);
            Chart utilitywiseTotalNumberofPowerPlant = UtilitywiseTotalNumberofPowerPlantBarChart(fAManagement_Entity.UtilitywiseTotalNumberofPowerPlantList);
            Chart utilitywiseTotalNumberofPowerPlantinOperation = UtilitywiseTotalNumberofPowerPlantinOperationBarChart(fAManagement_Entity.UtilitywiseTotalNumberofPowerPlantinOperationList);
            Chart utilitywiseTotalNumberofPowerPlantUnderMaintenance = UtilitywiseTotalNumberofPowerPlantUnderMaintenanceBarChart(fAManagement_Entity.UtilitywiseTotalNumberofPowerPlantUnderMaintenanceList);
            Chart utilitywiseTotalInstalledCapacityofPowerPlant = UtilitywiseTotalInstalledCapacityofPowerPlantBarChart(fAManagement_Entity.UtilitywiseTotalInstalledCapacityofPowerPlantList);
            Chart utilitywiseTotalInstalledCapacityofPowerPlantinOperation = UtilitywiseTotalInstalledCapacityofPowerPlantinOperationBarChart(fAManagement_Entity.UtilitywiseTotalInstalledCapacityofPowerPlantinOperationList);
            Chart utilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenance = UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenanceBarChart(fAManagement_Entity.UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenanceList);
            Chart fuelWisePowerPlant = FuelWisePowerPlantPieChart(fAManagement_Entity.FuelWisePowerPlantList);
            Chart pPTypeWisePowerPlant = PPTypeWisePowerPlantPieChart(fAManagement_Entity.PPTypeWisePowerPlantList);

            //FAF
            FAFinance_Entity fAFinance_Entity = await _repositoryFAFinance.GetAllReports(Organization);
            Chart MaintenanceCostbyOffice = MaintenanceCostbyOfficeBarChart(fAFinance_Entity.MaintenanceCostbyOfficeList.OrderByDescending(e => e.SequenceNo).ToList());
            Chart AssetAcquisitionOfficeWise = AssetAcquisitionOfficeWiseBarChart(fAFinance_Entity.AssetAcquisitionOfficeWiseList.OrderBy(e => e.SequenceNo).ToList());
            Chart LandValuebyOffice = LandValuebyOfficeBarChart(fAFinance_Entity.LandValuebyOfficeList.OrderBy(e => e.SequenceNo).ToList());
            Chart BookValuevsAccumulatedPrice = BookValuevsAccumulatedPriceBarChart(fAFinance_Entity.BookValuevsAccumulatedPriceList.OrderBy(e => e.SequenceNo).ToList());
            Chart AssetDisposedAssetWise = AssetDisposedAssetWiseBarChart(fAFinance_Entity.AssetDisposedAssetWiseList.OrderBy(e => e.SequenceNo).ToList());
            Chart AssetDisposedOfficeWise = AssetDisposedOfficeWiseBarChart(fAFinance_Entity.AssetDisposedOfficeWiseList.OrderBy(e => e.SequenceNo).ToList());
            Chart AssetAcquisitionAssetWise = AssetAcquisitionAssetWisePieChart(fAFinance_Entity.AssetAcquisitionAssetWiseList);
            Chart MaintenanceCostbyMonth = MaintenanceCostbyMonthPieChart(fAFinance_Entity.MaintenanceCostbyMonthList);
            Chart BookValuebyAssetType = BookValuebyAssetTypePieChart(fAFinance_Entity.BookValuebyAssetTypeList);
            Chart AcquisitionVsBookValue = AcquisitionVsBookValueBarChart(fAFinance_Entity.AcquisitionVsBookValueList);

            
            ViewData["OrganizationName"] = Organization;
            long TotalLand = fAManagement_Entity.TotalLandAreaList.FirstOrDefault().TotalArea;
            ViewData["totalLand"] = Convert.ToDecimal(TotalLand).ToString("#,##0");
            long TotalPowerPlant = fAManagement_Entity.TotalNumberofPowerPlantList.FirstOrDefault().TotalPowerPlant;
            ViewData["totalPowerPlant"] = Convert.ToDecimal(TotalPowerPlant).ToString("#,##0");
            long TotalCapacity = fAManagement_Entity.TotalInstalledCapacityofPowerPlantList.FirstOrDefault().TotalCapacity;
            ViewData["totalCapacity"] = Convert.ToDecimal(TotalCapacity).ToString("#,##0");
            long TotalDistributionSS = fAManagement_Entity.TotalDistributionSubStationsList.FirstOrDefault().TotalDistributionSS;
            ViewData["totalDistributionSS"] = Convert.ToDecimal(TotalDistributionSS).ToString("#,##0");

            ViewData["insuredNonInsuredAssets"] = insuredNonInsuredAssets;
            ViewData["serviceLifeAnalyses"] = serviceLifeAnalyses;
            ViewData["operationalNonOperationalTransformer"] = operationalNonOperationalTransformer;
            ViewData["landUsagesbyOffice"] = landUsagesbyOffice;
            ViewData["transformerOperationalAnalysisbyOffice"] = transformerOperationalAnalysisbyOffice;
            ViewData["transformerOperationalAnalysisbyMonth"] = transformerOperationalAnalysisbyMonth;
            ViewData["landAreabyOfficePieChart"] = landAreabyOfficePieChart;
            ViewData["landEncroachmentRatioPieChart"] = landEncroachmentRatioPieChart;
            ViewData["subStationsbyOfficePieChart"] = subStationsbyOfficePieChart;
            //ViewData["utilitywiseTotalLand"] = utilitywiseTotalLand;
            //ViewData["totalLandbyUsages"] = totalLandbyUsages;
            ViewData["utilitywiseTotalBuilding"] = utilitywiseTotalBuilding;
            //ViewData["utilitywiseTotalNumberofPowerPlant"] = utilitywiseTotalNumberofPowerPlant;
            ViewData["utilitywiseTotalNumberofPowerPlantinOperation"] = utilitywiseTotalNumberofPowerPlantinOperation;
            ViewData["utilitywiseTotalNumberofPowerPlantUnderMaintenance"] = utilitywiseTotalNumberofPowerPlantUnderMaintenance;
            ViewData["utilitywiseTotalInstalledCapacityofPowerPlant"] = utilitywiseTotalInstalledCapacityofPowerPlant;
            ViewData["utilitywiseTotalInstalledCapacityofPowerPlantinOperation"] = utilitywiseTotalInstalledCapacityofPowerPlantinOperation;
            ViewData["utilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenance"] = utilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenance;
            ViewData["fuelWisePowerPlant"] = fuelWisePowerPlant;
            ViewData["pPTypeWisePowerPlant"] = pPTypeWisePowerPlant;

            //FAF
            ViewData["MaintenanceCostbyOffice"] = MaintenanceCostbyOffice;
            ViewData["AssetAcquisitionOfficeWise"] = AssetAcquisitionOfficeWise;
            ViewData["LandValuebyOffice"] = LandValuebyOffice;
            ViewData["BookValuevsAccumulatedPrice"] = BookValuevsAccumulatedPrice;
            ViewData["AssetDisposedAssetWise"] = AssetDisposedAssetWise;
            ViewData["AssetDisposedOfficeWise"] = AssetDisposedOfficeWise;
            ViewData["AssetAcquisitionAssetWise"] = AssetAcquisitionAssetWise;
            ViewData["MaintenanceCostbyMonth"] = MaintenanceCostbyMonth;
            ViewData["BookValuebyAssetType"] = BookValuebyAssetType;
            ViewData["AcquisitionVsBookValue"] = AcquisitionVsBookValue;
            //JS Chartjs
            ViewData["utilitywiseTotalLand"] = fAManagement_Entity.UtilitywiseTotalLandList;
            ViewData["totalLandbyUsages"] = fAManagement_Entity.TotalLandbyUsagesList;
            ViewData["utilitywiseTotalNumberofPowerPlant"] = fAManagement_Entity.UtilitywiseTotalNumberofPowerPlantList;
            return View();
        }
        private Chart InsuredNonInsuredAssetBarChart(List<InsuredNonInsuredAsset> insuredNonInsuredAssets)
        {
            List<double?> insuredValue = insuredNonInsuredAssets.Select(e => Convert.ToDouble(e.Insured)).Cast<double?>().ToList();
            List<double?> nonInsuredValue = insuredNonInsuredAssets.Select(e => Convert.ToDouble(e.NonInsured)).Cast<double?>().ToList();
            List<string> Lables = insuredNonInsuredAssets.Select(e => e.AssetType).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Insured",
                Data = insuredValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Non-Insured",
                Data = nonInsuredValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#01B8AA"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromRgb(54, 162, 235),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateStackedBarChart(Lables, "Asset Type", "Amount", dataset1, dataset2);
        }
        private Chart ServiceLifeAnalysisBarChart(List<ServiceLifeAnalysis> serviceLifeAnalyses)
        {
            List<double?> transformer = serviceLifeAnalyses.Select(e => Convert.ToDouble(e.Transformer)).Cast<double?>().ToList();
            List<double?> subStation = serviceLifeAnalyses.Select(e => Convert.ToDouble(e.SubStation)).Cast<double?>().ToList();
            List<double?> powerTransformer = serviceLifeAnalyses.Select(e => Convert.ToDouble(e.PowerTransformer)).Cast<double?>().ToList();
            List<double?> circuitBreaker = serviceLifeAnalyses.Select(e => Convert.ToDouble(e.CircuitBreaker)).Cast<double?>().ToList();
            List<double?> machinery = serviceLifeAnalyses.Select(e => Convert.ToDouble(e.Machinery)).Cast<double?>().ToList();
            List<double?> vehicle = serviceLifeAnalyses.Select(e => Convert.ToDouble(e.Vehicle)).Cast<double?>().ToList();
            List<string> Lables = serviceLifeAnalyses.Select(e => e.OfficeName).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "% Transformer > 5y",
                Data = transformer,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset2 = new BarDataset()
            {
                Label = "% Distribution Sub-Station > 10Y",
                Data = subStation,
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
            BarDataset dataset3 = new BarDataset()
            {
                Label = "Power Transformer",
                Data = powerTransformer,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset4 = new BarDataset()
            {
                Label = "% Circuit Breaker > 5y",
                Data = circuitBreaker,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#008080"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#008080"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset5 = new BarDataset()
            {
                Label = " % Machinery > 5y",
                Data = machinery,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#007EB9"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#007EB9"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset6 = new BarDataset()
            {
                Label = "% Vehicle > 5y",
                Data = vehicle,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#5F6B6D"),
                },
                BorderColor = new List<ChartColor>
                {
                     ChartColor.FromHexString("#5F6B6D"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateStackedBarChart(Lables, GetXaxisLable(), "Count", dataset1, dataset2, dataset3, dataset4, dataset5, dataset6);
        }
        private Chart OperationalNonOperationalTransformerBarChart(List<OperationalNonOperationalTransformer> operationalNonOperationalTransformers)
        {
            List<double?> operationalValue = operationalNonOperationalTransformers.Select(e => Convert.ToDouble(e.Operational)).Cast<double?>().ToList();
            List<double?> nonOperationalValue = operationalNonOperationalTransformers.Select(e => Convert.ToDouble(e.NonOperational)).Cast<double?>().ToList();
            List<string> Lables = operationalNonOperationalTransformers.Select(e => e.OfficeName).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Operational",
                Data = operationalValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Non-Operational",
                Data = nonOperationalValue,
                BackgroundColor = new List<ChartColor>
                    {
                        ChartColor.FromHexString("#01B8AA"),
                    },
                BorderColor = new List<ChartColor>
                    {
                        ChartColor.FromRgb(54, 162, 235),
                    },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, GetXaxisLable(), "Count", dataset1, dataset2);
        }
        private Chart LandUsagesbyOfficeBarChart(List<LandUsagesbyOffice> landUsagesbyOffices)
        {
            List<double?> powerPlant = landUsagesbyOffices.Select(e => Math.Round(e.PowerPlant,2)).Cast<double?>().ToList();
            List<double?> subStation = landUsagesbyOffices.Select(e => Math.Round(e.SubStation,2)).Cast<double?>().ToList();
            List<double?> OfficeBuilding = landUsagesbyOffices.Select(e => Math.Round(e.OfficeBuilding,2)).Cast<double?>().ToList();
            List<double?> ResidentialBuilding = landUsagesbyOffices.Select(e => Math.Round(e.ResidentialBuilding,2)).Cast<double?>().ToList();
            List<double?> Road = landUsagesbyOffices.Select(e => Math.Round(e.Road,2)).Cast<double?>().ToList();
            List<double?> UndevelopedLand = landUsagesbyOffices.Select(e => Math.Round(e.UndevelopedLand,2)).Cast<double?>().ToList();
            List<double?> others = landUsagesbyOffices.Select(e => Math.Round(e.Others,2)).Cast<double?>().ToList();
            List<string> Lables = landUsagesbyOffices.Select(e => e.OfficeName).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Power Plant",
                Data = powerPlant,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Sub Station",
                Data = subStation,
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
            BarDataset dataset3 = new BarDataset()
            {
                Label = "Office Building",
                Data = OfficeBuilding,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset4 = new BarDataset()
            {
                Label = "Residential Building",
                Data = ResidentialBuilding,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#008080"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#008080"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset5 = new BarDataset()
            {
                Label = "Road",
                Data = Road,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#007EB9"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#007EB9"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset6 = new BarDataset()
            {
                Label = "Undeveloped Land",
                Data = UndevelopedLand,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#5F6B6D"),
                },
                BorderColor = new List<ChartColor>
                {
                     ChartColor.FromHexString("#5F6B6D"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset7 = new BarDataset()
            {
                Label = "Others",
                Data = others,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#DFBFBF"),
                },
                BorderColor = new List<ChartColor>
                {
                     ChartColor.FromHexString("#DFBFBF"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateStackedBarChart(Lables, GetXaxisLable(), "Acres", dataset1, dataset2, dataset3, dataset4, dataset5, dataset6, dataset7);
        }
        private Chart TransformerOperationalAnalysisbyOfficeBarChart(List<TransformerOperationalAnalysisbyOffice> transformerOperationalAnalysisbyOffices)
        {
            List<double?> overloadedValue = transformerOperationalAnalysisbyOffices.Select(e => Convert.ToDouble(e.Overloaded)).Cast<double?>().ToList();
            List<double?> burntValue = transformerOperationalAnalysisbyOffices.Select(e => Convert.ToDouble(e.Burnt)).Cast<double?>().ToList();
            List<string> Lables = transformerOperationalAnalysisbyOffices.Select(e => e.OfficeName).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Overloaded",
                Data = overloadedValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Burnt",
                Data = burntValue,
                BackgroundColor = new List<ChartColor>
                    {
                        ChartColor.FromHexString("#01B8AA"),
                    },
                BorderColor = new List<ChartColor>
                    {
                        ChartColor.FromRgb(54, 162, 235),
                    },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, GetXaxisLable(), "Transformer Count", dataset1, dataset2);
        }
        private Chart TransformerOperationalAnalysisbyMonthBarChart(List<TransformerOperationalAnalysisbyMonth> transformerOperationalAnalysisbyMonths)
        {
            List<double?> overloadedValue = transformerOperationalAnalysisbyMonths.Select(e => Convert.ToDouble(e.Overloaded)).Cast<double?>().ToList();
            List<double?> burntValue = transformerOperationalAnalysisbyMonths.Select(e => Convert.ToDouble(e.Burnt)).Cast<double?>().ToList();
            List<string> Lables = transformerOperationalAnalysisbyMonths.Select(e => e.Month).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Overloaded",
                Data = overloadedValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Burnt",
                Data = burntValue,
                BackgroundColor = new List<ChartColor>
                    {
                        ChartColor.FromHexString("#01B8AA"),
                    },
                BorderColor = new List<ChartColor>
                    {
                        ChartColor.FromRgb(54, 162, 235),
                    },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Month Name", "Transformer Count", dataset1, dataset2);
        }
        private Chart LandAreabyOfficePieChart(List<LandAreabyOffice> landAreabyOffices)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> totalAreaValue = landAreabyOffices.Select(e => Convert.ToDouble(e.TotalAreaOfLand)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(totalAreaValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = landAreabyOffices.Select(e => e.OfficeName).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Total Area of Land",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = totalAreaValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart LandEncroachmentRatioPieChart(List<LandEncroachmentRatio> landEncroachmentRatios)
        {

            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = new List<double?>();
            //--landEncroachmentRatios.Select(e => Convert.ToDouble(e.Encroachment)).Cast<double?>().ToList();
            countValue.Add(Convert.ToDouble(landEncroachmentRatios.FirstOrDefault().Encroachment));
            countValue.Add(Convert.ToDouble(landEncroachmentRatios.FirstOrDefault().PhysicalPossession));

            List<double?> physicalPossessionValue = landEncroachmentRatios.Select(e => Convert.ToDouble(e.PhysicalPossession)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = new List<string>() { "Encroachment", "Physical Possession" };
            PieDataset dataset = new PieDataset()
            {
                Label = "",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart SubStationsbyOfficePieChart(List<SubStationsbyOffice> subStationsbyOffices)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = subStationsbyOffices.Select(e => Convert.ToDouble(e.TotalSubStation)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = subStationsbyOffices.Select(e => e.OfficeName).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Count",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart UtilitywiseTotalLandBarChart(List<UtilitywiseTotalLand> utilitywiseTotalLand)
        {
            List<double?> totalArea = utilitywiseTotalLand.Select(e => Convert.ToDouble(e.TotalArea)).Cast<double?>().ToList();
            List<string> Lables = utilitywiseTotalLand.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Land Area",
                Data = totalArea,
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
        

            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Land Area in Acre", dataset1);
        }
        private Chart TotalLandbyUsagesBarChart(List<TotalLandbyUsages> totalLandbyUsages)
        {
            List<double?> totalArea = totalLandbyUsages.Select(e => Convert.ToDouble(e.TotalArea)).Cast<double?>().ToList();
            List<string> Lables = totalLandbyUsages.Select(e => e.Usages).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Land Area",
                Data = totalArea,
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


            return ChartHelper.GenerateBarChart(Lables, "Usages Group", "Land Area in Acre", dataset1);
        }
        private Chart UtilitywiseTotalBuildingBarChart(List<UtilitywiseTotalBuilding> utilitywiseTotalBuilding)
        {
            List<double?> totalArea = utilitywiseTotalBuilding.Select(e => Convert.ToDouble(e.TotalArea)).Cast<double?>().ToList();
            List<string> Lables = utilitywiseTotalBuilding.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Buildings",
                Data = totalArea,
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


            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Number of Building", dataset1);
        }
        private Chart UtilitywiseTotalNumberofPowerPlantBarChart(List<UtilitywiseTotalNumberofPowerPlant> utilitywiseTotalNumberofPowerPlant)
        {
            List<double?> totalPowerPlant = utilitywiseTotalNumberofPowerPlant.Select(e => Convert.ToDouble(e.TotalPowerPlant)).Cast<double?>().ToList();
            List<string> Lables = utilitywiseTotalNumberofPowerPlant.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Power Plant",
                Data = totalPowerPlant,
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


            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Number of Power Plant", dataset1);
        }
        private Chart UtilitywiseTotalNumberofPowerPlantinOperationBarChart(List<UtilitywiseTotalNumberofPowerPlantinOperation> utilitywiseTotalNumberofPowerPlantinOperation)
        {
            List<double?> totalPowerPlant = utilitywiseTotalNumberofPowerPlantinOperation.Select(e => Convert.ToDouble(e.TotalPowerPlant)).Cast<double?>().ToList();
            List<string> Lables = utilitywiseTotalNumberofPowerPlantinOperation.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Power Plant",
                Data = totalPowerPlant,
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


            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Number of Power Plant", dataset1);
        }
        private Chart UtilitywiseTotalNumberofPowerPlantUnderMaintenanceBarChart(List<UtilitywiseTotalNumberofPowerPlantUnderMaintenance> utilitywiseTotalNumberofPowerPlantUnderMaintenance)
        {
            List<double?> totalPowerPlant = utilitywiseTotalNumberofPowerPlantUnderMaintenance.Select(e => Convert.ToDouble(e.TotalPowerPlant)).Cast<double?>().ToList();
            List<string> Lables = utilitywiseTotalNumberofPowerPlantUnderMaintenance.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Power Plant",
                Data = totalPowerPlant,
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


            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Number of Power Plant", dataset1);
        }
        private Chart UtilitywiseTotalInstalledCapacityofPowerPlantBarChart(List<UtilitywiseTotalInstalledCapacityofPowerPlant> utilitywiseTotalInstalledCapacityofPowerPlant)
        {
            List<double?> totalCapacity = utilitywiseTotalInstalledCapacityofPowerPlant.Select(e => Convert.ToDouble(e.TotalCapacity)).Cast<double?>().ToList();
            List<string> Lables = utilitywiseTotalInstalledCapacityofPowerPlant.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Installed Capacity",
                Data = totalCapacity,
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


            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Installed Capacity (MW)", dataset1);
        }
        private Chart UtilitywiseTotalInstalledCapacityofPowerPlantinOperationBarChart(List<UtilitywiseTotalInstalledCapacityofPowerPlantinOperation> utilitywiseTotalInstalledCapacityofPowerPlantinOperation)
        {
            List<double?> totalCapacity = utilitywiseTotalInstalledCapacityofPowerPlantinOperation.Select(e => Convert.ToDouble(e.TotalCapacity)).Cast<double?>().ToList();
            List<string> Lables = utilitywiseTotalInstalledCapacityofPowerPlantinOperation.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Installed Capacity",
                Data = totalCapacity,
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


            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Installed Capacity (MW)", dataset1);
        }
        private Chart UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenanceBarChart(List<UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenance> utilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenance)
        {
            List<double?> totalCapacity = utilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenance.Select(e => Convert.ToDouble(e.TotalCapacity)).Cast<double?>().ToList();
            List<string> Lables = utilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenance.Select(e => e.Organization).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Installed Capacity",
                Data = totalCapacity,
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


            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Installed Capacity (MW)", dataset1);
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
        private Chart PPTypeWisePowerPlantPieChart(List<PPTypeWisePowerPlant> pPTypeWisePowerPlant)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> totalPowerPlant = pPTypeWisePowerPlant.Select(e => Convert.ToDouble(e.TotalPowerPlant)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(totalPowerPlant.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = pPTypeWisePowerPlant.Select(e => e.PowerPlantType).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Power Plant",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = totalPowerPlant
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }

        //FAF
        private Chart MaintenanceCostbyOfficeBarChart(List<MaintenanceCostbyOffice> MaintenanceCostbyOffice)
        {
            List<double?> TransformerValue = MaintenanceCostbyOffice.Select(e => Convert.ToDouble(e.Transformer).ConvertMillions()).Cast<double?>().ToList();
            List<double?> VehicleValue = MaintenanceCostbyOffice.Select(e => Convert.ToDouble(e.Vehicle).ConvertMillions()).Cast<double?>().ToList();
            List<double?> OfficeEuqipmentValue = MaintenanceCostbyOffice.Select(e => Convert.ToDouble(e.OfficeEuqipment).ConvertMillions()).Cast<double?>().ToList();
            List<double?> BuildingValue = MaintenanceCostbyOffice.Select(e => Convert.ToDouble(e.Building).ConvertMillions()).Cast<double?>().ToList();
            List<double?> CivilWorksValue = MaintenanceCostbyOffice.Select(e => Convert.ToDouble(e.CivilWorks).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = MaintenanceCostbyOffice.Select(e => e.OfficeName).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Transformer",
                Data = TransformerValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Vehicle",
                Data = VehicleValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset3 = new BarDataset()
            {
                Label = "Office Euqipment",
                Data = OfficeEuqipmentValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#008080"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#008080"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset4 = new BarDataset()
            {
                Label = "Building",
                Data = BuildingValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#007EB9"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#007EB9"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset5 = new BarDataset()
            {
                Label = "Civil Works",
                Data = CivilWorksValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#5F6B6D"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#5F6B6D"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            return ChartHelper.GenerateStackedBarChart(Lables, GetXaxisLable(), "Amount", dataset1, dataset2, dataset3, dataset4, dataset5).AddMillionWithYaxes();
        }
        private Chart AssetAcquisitionOfficeWiseBarChart(List<AssetAcquisitionOfficeWise> AssetAcquisitionOfficeWise)
        {
            List<double?> AcquisitionAmount = AssetAcquisitionOfficeWise.Select(e => Convert.ToDouble(e.AcquisitionAmount).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = AssetAcquisitionOfficeWise.Select(e => e.OfficeName).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Acquisition Amount",
                Data = AcquisitionAmount,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            return ChartHelper.GenerateBarChart(Lables, GetXaxisLable(), "Amount", dataset1).AddMillionWithYaxes();
        }
        private Chart LandValuebyOfficeBarChart(List<LandValuebyOffice> LandValuebyOffice)
        {
            List<double?> LandValue = LandValuebyOffice.Select(e => Convert.ToDouble(e.LandValue).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = LandValuebyOffice.Select(e => e.OfficeName).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Land Value",
                Data = LandValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            return ChartHelper.GenerateBarChart(Lables, GetXaxisLable(), "Amount", dataset1).AddMillionWithYaxes();
        }
        private Chart BookValuevsAccumulatedPriceBarChart(List<BookValuevsAccumulatedPrice> BookValuevsAccumulatedPrice)
        {
            List<double?> BookValue = BookValuevsAccumulatedPrice.Select(e => Convert.ToDouble(e.BookValue).ConvertMillions()).Cast<double?>().ToList();
            List<double?> AccumulatedDepreciation = BookValuevsAccumulatedPrice.Select(e => Convert.ToDouble(e.AccumulatedDepreciation).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = BookValuevsAccumulatedPrice.Select(e => e.AssetSubType).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Book Value",
                Data = BookValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Accumulated Depreciation",
                Data = AccumulatedDepreciation,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            return ChartHelper.GenerateStackedBarChart(Lables, "Asset Type", "Amount", dataset1, dataset2).AddMillionWithYaxes();
        }
        private Chart AssetDisposedAssetWiseBarChart(List<AssetDisposedAssetWise> AssetDisposedAssetWise)
        {
            List<double?> SoldAmount = AssetDisposedAssetWise.Select(e => Convert.ToDouble(e.SoldAmount).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = AssetDisposedAssetWise.Select(e => e.AssetType).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Amount",
                Data = SoldAmount,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            return ChartHelper.GenerateBarChart(Lables, "Asset Type", "Amount", dataset1).AddMillionWithYaxes();
        }
        private Chart AssetDisposedOfficeWiseBarChart(List<AssetDisposedOfficeWise> AssetDisposedOfficeWise)
        {
            List<double?> SoldAmount = AssetDisposedOfficeWise.Select(e => Convert.ToDouble(e.SoldAmount).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = AssetDisposedOfficeWise.Select(e => e.OfficeName).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Amount",
                Data = SoldAmount,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            return ChartHelper.GenerateBarChart(Lables, GetXaxisLable(), "Amount", dataset1).AddMillionWithYaxes();
        }
        private Chart AssetAcquisitionAssetWisePieChart(List<AssetAcquisitionAssetWise> AssetAcquisitionAssetWise)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> AcquisitionAmount = AssetAcquisitionAssetWise.Select(e => Convert.ToDouble(e.AcquisitionAmount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(AcquisitionAmount.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = AssetAcquisitionAssetWise.Select(e => e.AssetType).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Amount",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = AcquisitionAmount
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart MaintenanceCostbyMonthPieChart(List<MaintenanceCostbyMonth> MaintenanceCostbyMonth)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> MaintenanceCost = MaintenanceCostbyMonth.Select(e => Convert.ToDouble(e.MaintenanceCost)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(MaintenanceCost.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = MaintenanceCostbyMonth.Select(e => e.Month).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Amount",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = MaintenanceCost
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart BookValuebyAssetTypePieChart(List<BookValuebyAssetType> BookValuebyAssetType)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> BookValue = BookValuebyAssetType.Select(e => Convert.ToDouble(e.BookValue)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(BookValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = BookValuebyAssetType.Select(e => e.AssetType).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Book Value",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = BookValue
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart AcquisitionVsBookValueBarChart(List<AcquisitionVsBookValue> acquisitionVsBookValue)
        {
            List<double?> AcquisitionValue = acquisitionVsBookValue.Select(e => Convert.ToDouble(e.Acquisition).ConvertBilions()).Cast<double?>().ToList();
            List<double?> BookValue = acquisitionVsBookValue.Select(e => Convert.ToDouble(e.BookValue).ConvertBilions()).Cast<double?>().ToList();
            List<string> Lables = acquisitionVsBookValue.Select(e => e.Organization).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Acquisition",
                Data = AcquisitionValue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Book Value",
                Data = BookValue,
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
            //return ChartHelper.GenerateBarChart(Lables, GetXaxisLable(), "Amount", dataset1,dataset2).AddMillionWithYaxes();
            return ChartHelper.GenerateBarChartforthickbar(Lables, "Utilities", "Value in Billion Tk", dataset1,dataset2);
        }
        #endregion

        #region  PR_Dashboard
        public async Task<IActionResult> PR_Dashboard()
        {
            var Organization = HttpContext.User.FindFirstValue("Organization");
            PR_Entity pR_Entity = await _repositoryPR.GetAllReports(Organization);
            Chart procurementTrend = ProcurementTrendBarChart(pR_Entity.ProcurementTrendList);
            Chart topProcuredItemsbyOffice = TopProcuredItemsbyOfficeBarChart(pR_Entity.TopProcuredItemsbyOfficeList);
            Chart procurementValuebyOffice = ProcurementValuebyOfficeBarChart(pR_Entity.ProcurementValuebyOfficeList);
            Chart procurementTypebyOffice = ProcurementTypebyOfficeBarChart(pR_Entity.ProcurementTypebyOfficeList);
            Chart procurementStatusPieChart = ProcurementStatusPieChart(pR_Entity.ProcurementStatusList);
            Chart appUtilizationPieChart = AppUtilizationPieChart(pR_Entity.AppUtilizationList);
            Chart requisitionStatusPieChart = RequisitionStatusPieChart(pR_Entity.RequisitionStatusList);

            ViewData["procurementTrend"] = procurementTrend;
            ViewData["topProcuredItemsbyOffice"] = topProcuredItemsbyOffice;
            ViewData["procurementValuebyOffice"] = procurementValuebyOffice;
            ViewData["procurementTypebyOffice"] = procurementTypebyOffice;
            ViewData["procurementStatusPieChart"] = procurementStatusPieChart;
            ViewData["appUtilizationPieChart"] = appUtilizationPieChart;
            ViewData["requisitionStatusPieChart"] = requisitionStatusPieChart;
            return View();
        }
        private Chart ProcurementTrendBarChart(List<ProcurementTrend> procurementTrends)
        {
            List<double?> amount = procurementTrends.Select(e => Convert.ToDouble(e.Amount).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = procurementTrends.Select(e => e.Year).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Amount",
                Data = amount,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };

           // return ChartHelper.GenerateBarChart(Lables, "Year", "Amount", dataset1).AddMillionWithYaxes();
            return ChartHelper.GenerateBarChart(Lables, "Year", "Amount in Million Tk", dataset1);
        }
        private Chart TopProcuredItemsbyOfficeBarChart(List<TopProcuredItemsbyOffice> topProcuredItemsbyOffices)
        {
            List<double?> copperCable11KV = topProcuredItemsbyOffices.Select(e => Convert.ToDouble(e.CopperCable11KV)).Cast<double?>().ToList();
            List<double?> copperCable33KV = topProcuredItemsbyOffices.Select(e => Convert.ToDouble(e.CopperCable33KV)).Cast<double?>().ToList();
            List<double?> meterSeal = topProcuredItemsbyOffices.Select(e => Convert.ToDouble(e.MeterSeal)).Cast<double?>().ToList();
            List<string> Lables = topProcuredItemsbyOffices.Select(e => e.OfficeName).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "11 KV 3-core 300sq mm XLPE U/G Copper Cable",
                Data = copperCable11KV,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset2 = new BarDataset()
            {
                Label = "33 KV 1-core 500sq.mm XLPE U/G Copper Cable",
                Data = copperCable33KV,
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
            BarDataset dataset3 = new BarDataset()
            {
                Label = "Twist-tight Meter Seal",
                Data = meterSeal,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };            

            return ChartHelper.GenerateStackedBarChart(Lables, GetXaxisLable(), "Item Count", dataset1, dataset2, dataset3);
        }
        private Chart ProcurementValuebyOfficeBarChart(List<ProcurementValuebyOffice> procurementValuebyOffices)
        {
            List<double?> amount = procurementValuebyOffices.Select(e => Convert.ToDouble(e.Amount).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = procurementValuebyOffices.Select(e => e.OfficeName).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "Amount",
                Data = amount,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };


            //return ChartHelper.GenerateBarChart(Lables, GetXaxisLable(), "Amount", dataset1).AddMillionWithYaxes();
            return ChartHelper.GenerateBarChart(Lables, "Utilites", "Amount in Million Tk", dataset1);
        }
        private Chart ProcurementTypebyOfficeBarChart(List<ProcurementTypebyOffice> procurementTypebyOffices)
        {
            List<double?> eGP = procurementTypebyOffices.Select(e => Convert.ToDouble(e.eGP).ConvertMillions()).Cast<double?>().ToList();
            List<double?> oTM = procurementTypebyOffices.Select(e => Convert.ToDouble(e.OTM).ConvertMillions()).Cast<double?>().ToList();
            List<double?> dPM = procurementTypebyOffices.Select(e => Convert.ToDouble(e.DPM).ConvertMillions()).Cast<double?>().ToList();
            List<double?> spotQuotation = procurementTypebyOffices.Select(e => Convert.ToDouble(e.SpotQuotation).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = procurementTypebyOffices.Select(e => e.OfficeName).ToList();
            BarDataset dataset1 = new BarDataset()
            {
                Label = "e-GP",
                Data = eGP,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#698B69"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#698B69"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset2 = new BarDataset()
            {
                Label = "OTM/LTM/RFG",
                Data = oTM,
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
            BarDataset dataset3 = new BarDataset()
            {
                Label = "DPM",
                Data = dPM,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            BarDataset dataset4 = new BarDataset()
            {
                Label = "Spot Quotation",
                Data = spotQuotation,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#008080"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#008080"),
                },
                BorderWidth = new List<int>() { 1 }
            };            

            return ChartHelper.GenerateStackedBarChart(Lables, GetXaxisLable(), "Amount", dataset1, dataset2, dataset3, dataset4).AddMillionWithYaxes();
        }
        private Chart ProcurementStatusPieChart(List<ProcurementStatus> procurementStatuses)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = new List<double?>();
            //--landEncroachmentRatios.Select(e => Convert.ToDouble(e.Encroachment)).Cast<double?>().ToList();
            countValue.Add(Convert.ToDouble(procurementStatuses.FirstOrDefault().Completed));
            countValue.Add(Convert.ToDouble(procurementStatuses.FirstOrDefault().OnGoing));
            countValue.Add(Convert.ToDouble(procurementStatuses.FirstOrDefault().NotInitiated));

            List<ChartColor> backgroundColorList = new List<ChartColor>();
            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = new List<string>() { "Completed", "On-Going(In Progress)", "Not Initiated" };
            PieDataset dataset = new PieDataset()
            {
                Label = "",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };

            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart AppUtilizationPieChart(List<AppUtilization> appUtilizations)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = new List<double?>();

            countValue.Add(Convert.ToDouble(appUtilizations.FirstOrDefault().Unutilized));
            countValue.Add(Convert.ToDouble(appUtilizations.FirstOrDefault().Utilized));

            List<ChartColor> backgroundColorList = new List<ChartColor>();
            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = new List<string>() { "Yet to Utilize", "Utilized" };
            PieDataset dataset = new PieDataset()
            {
                Label = "",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };

            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart RequisitionStatusPieChart(List<RequisitionStatus> requisitionStatuses)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> countValue = new List<double?>();

            countValue.Add(Convert.ToDouble(requisitionStatuses.FirstOrDefault().POIssued));
            countValue.Add(Convert.ToDouble(requisitionStatuses.FirstOrDefault().POPending));

            List<ChartColor> backgroundColorList = new List<ChartColor>();
            foreach (var item in colorList.Take(countValue.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = new List<string>() { "PO Issued", "PO Pending" };
            PieDataset dataset = new PieDataset()
            {
                Label = "",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = countValue
            };

            return ChartHelper.GeneratePieChart(Lables, dataset);
        }


        #endregion

        #region  Finance_Dashboard
        public async Task<IActionResult> Finance_Dashboard()
        {
            var Organization = HttpContext.User.FindFirstValue("Organization");
            Finance_Entity finance_Entity = await _repositoryFinance.GetAllReports(Organization);
            Chart RevenueVsExpense = RevenueVsExpenseBarChart(finance_Entity.RevenueVsExpenseList.OrderBy(e => e.SequenceNo).ToList());
            Chart NetProfitVsGrossRevenue = NetProfitVsGrossRevenueBarChart(finance_Entity.NetProfitVsGrossRevenueList.OrderBy(e => e.SequenceNo).ToList());
            Chart AccountReceivableVsCashflow = AccountReceivableVsCashflowBarChart(finance_Entity.AccountReceivableVsCashflowList.OrderBy(e => e.SequenceNo).ToList());
            Chart CapitalExpenditureVsOperationalExpenses = CapitalExpenditureVsOperationalExpensesBarChart(finance_Entity.CapitalExpenditureVsOperationalExpensesList.OrderBy(e => e.SequenceNo).ToList());
            Chart AccountsPayable = AccountsPayablePieChart(finance_Entity.AccountsPayableList);
            Chart AccountsReceivable = AccountsReceivablePieChart(finance_Entity.AccountsReceivableList);
            Chart YearlyTurnOver = YearlyTurnOverPieChart(finance_Entity.YearlyTurnOverList);
            Chart TotalAssetsvsTotalLiabilities = TotalAssetsvsTotalLiabilitiesBarChart(finance_Entity.TotalAssetsvsTotalLiabilitiesList.ToList());
            Chart TotalEquityvsDebt = TotalEquityvsDebtBarChart(finance_Entity.TotalEquityvsDebtList.ToList());
            Chart ExpensevsRevenue = ExpensevsRevenueBarChart(finance_Entity.ExpensevsRevenueList.ToList());
            Chart GrossProfitvsNetProfit = GrossProfitvsNetProfitBarChart(finance_Entity.GrossProfitvsNetProfitList.ToList());
            Chart ReceivablevsPayable = ReceivablevsPayableBarChart(finance_Entity.ReceivablevsPayableList.ToList());
            Chart UtilityWiseGrossProfit = UtilityWiseGrossProfitBarChart(finance_Entity.UtilityWiseGrossProfitList.ToList());
            Chart UtilityWiseNetProfit = UtilityWiseNetProfitBarChart(finance_Entity.UtilityWiseNetProfitList.ToList());
            Chart UtilityWiseTurnover = UtilityWiseTurnoverBarChart(finance_Entity.UtilityWiseTurnoverList.ToList());
            Chart UtilityWiseCashAndCashEquivalent = UtilityWiseCashAndCashEquivalentBarChart(finance_Entity.UtilityWiseCashAndCashEquivalentList.ToList());
            Chart UtilityWiseCurrentRatio = UtilityWiseCurrentRatioBarChart(finance_Entity.UtilityWiseCurrentRatioList.ToList());
            Chart UtilityWiseQuickRatio = UtilityWiseQuickRatioBarChart(finance_Entity.UtilityWiseQuickRatioList.ToList());
            Chart UtilityWiseDebtRatio = UtilityWiseDebtRatioBarChart(finance_Entity.UtilityWiseDebtRatioList.ToList());
            

            ViewData["RevenueVsExpense"] = RevenueVsExpense;
            ViewData["NetProfitVsGrossRevenue"] = NetProfitVsGrossRevenue;
            ViewData["AccountReceivableVsCashflow"] = AccountReceivableVsCashflow;
            ViewData["CapitalExpenditureVsOperationalExpenses"] = CapitalExpenditureVsOperationalExpenses;
            ViewData["AccountsPayable"] = AccountsPayable;
            ViewData["AccountsReceivable"] = AccountsReceivable;
            ViewData["YearlyTurnOver"] = YearlyTurnOver;
            ViewData["TotalAssetsvsTotalLiabilities"] = TotalAssetsvsTotalLiabilities;
            ViewData["TotalEquityvsDebt"] = TotalEquityvsDebt;
            ViewData["ExpensevsRevenue"] = ExpensevsRevenue;
            ViewData["GrossProfitvsNetProfit"] = GrossProfitvsNetProfit;
            ViewData["ReceivablevsPayable"] = ReceivablevsPayable;
            ViewData["FiscalYearlyTurnover"] = UtilityWiseGrossProfit;
            ViewData["UtilityWiseGrossProfit"] = UtilityWiseGrossProfit;
            ViewData["UtilityWiseNetProfit"] = UtilityWiseNetProfit;
            ViewData["UtilityWiseTurnover"] = UtilityWiseTurnover;
            ViewData["UtilityWiseCashAndCashEquivalent"] = UtilityWiseCashAndCashEquivalent;
            ViewData["UtilityWiseCurrentRatio"] = UtilityWiseCurrentRatio;
            ViewData["UtilityWiseQuickRatio"] = UtilityWiseQuickRatio;
            ViewData["UtilityWiseDebtRatio"] = UtilityWiseDebtRatio;

            return View();
        }
        private Chart RevenueVsExpenseBarChart(List<RevenueVsExpense> RevenueVsExpense)
        {
            List<double?> Expense = RevenueVsExpense.Select(e => Convert.ToDouble(e.Expense)).Cast<double?>().ToList();
            List<double?> Revenue = RevenueVsExpense.Select(e => Convert.ToDouble(e.Revenue)).Cast<double?>().ToList();
            List<string> Lables = RevenueVsExpense.Select(e => e.OfficeName).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Expense",
                Data = Expense,
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

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Revenue",
                Data = Revenue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, GetXaxisLable(), "Amount", dataset1, dataset2);
        }
        private Chart NetProfitVsGrossRevenueBarChart(List<NetProfitVsGrossRevenue> NetProfitVsGrossRevenue)
        {
            List<double?> NetProfit = NetProfitVsGrossRevenue.Select(e => Convert.ToDouble(e.NetProfit)).Cast<double?>().ToList();
            List<double?> GrossRevenue = NetProfitVsGrossRevenue.Select(e => Convert.ToDouble(e.GrossRevenue)).Cast<double?>().ToList();
            List<string> Lables = NetProfitVsGrossRevenue.Select(e => e.OfficeName).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Net Profit",
                Data = NetProfit,
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
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Gross Revenue",
                Data = GrossRevenue,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            return ChartHelper.GenerateBarChart(Lables, GetXaxisLable(), "Amount", dataset1, dataset2);
        }
        private Chart AccountReceivableVsCashflowBarChart(List<AccountReceivableVsCashflow> AccountReceivableVsCashflow)
        {
            List<double?> Receivable = AccountReceivableVsCashflow.Select(e => Convert.ToDouble(e.Receivable)).Cast<double?>().ToList();
            List<double?> Cashflow = AccountReceivableVsCashflow.Select(e => Convert.ToDouble(e.Cashflow)).Cast<double?>().ToList();
            List<string> Lables = AccountReceivableVsCashflow.Select(e => e.OfficeName).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Receivable",
                Data = Receivable,
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
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Cashflow",
                Data = Cashflow,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            return ChartHelper.GenerateBarChart(Lables, GetXaxisLable(), "Amount", dataset1, dataset2);
        }
        private Chart CapitalExpenditureVsOperationalExpensesBarChart(List<CapitalExpenditureVsOperationalExpenses> CapitalExpenditureVsOperationalExpenses)
        {
            List<double?> CapEx = CapitalExpenditureVsOperationalExpenses.Select(e => Convert.ToDouble(e.CapEx)).Cast<double?>().ToList();
            List<double?> OpEx = CapitalExpenditureVsOperationalExpenses.Select(e => Convert.ToDouble(e.OpEx)).Cast<double?>().ToList();
            List<string> Lables = CapitalExpenditureVsOperationalExpenses.Select(e => e.OfficeName).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Capital expenditures",
                Data = CapEx,
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

            BarDataset dataset2 = new BarDataset()
            {
                Label = "Operating expenses",
                Data = OpEx,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };
            return ChartHelper.GenerateBarChart(Lables, GetXaxisLable(), "Amount", dataset1, dataset2);
        }
        private Chart AccountsPayablePieChart(List<AccountsPayable> AccountsPayable)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> Amount = AccountsPayable.Select(e => Convert.ToDouble(e.Amount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(Amount.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = AccountsPayable.Select(e => e.OfficeName).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Amount",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = Amount
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart AccountsReceivablePieChart(List<AccountsReceivable> AccountsReceivable)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> Amount = AccountsReceivable.Select(e => Convert.ToDouble(e.Amount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(Amount.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = AccountsReceivable.Select(e => e.OfficeName).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Amount",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = Amount
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart YearlyTurnOverPieChart(List<YearlyTurnOver> YearlyTurnOver)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> Amount = YearlyTurnOver.Select(e => Convert.ToDouble(e.Amount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(Amount.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = YearlyTurnOver.Select(e => e.OfficeName).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Amount",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = Amount
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart TotalAssetsvsTotalLiabilitiesBarChart(List<TotalAssetsvsTotalLiabilities> totalAssetsvsTotalLiabilities)
        {
            List<double?> TotalAssets = totalAssetsvsTotalLiabilities.Select(e => Convert.ToDouble(e.TotalAssets).ConvertCrores()).Cast<double?>().ToList();
            List<double?> TotalLiabilities = totalAssetsvsTotalLiabilities.Select(e => Convert.ToDouble(e.TotalLiabilities).ConvertCrores()).Cast<double?>().ToList();
            List<string> Lables = totalAssetsvsTotalLiabilities.Select(e => e.FiscalYear).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Total Assets",
                Data = TotalAssets,
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
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Total Liabilities",
                Data = TotalLiabilities,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Fiscal Years", "Amount in Crore Taka", dataset1, dataset2);
        }
        private Chart TotalEquityvsDebtBarChart(List<TotalEquityvsDebt> totalEquityvsDebt)
        {
            List<double?> TotalEquity = totalEquityvsDebt.Select(e => Convert.ToDouble(e.TotalEquity).ConvertCrores()).Cast<double?>().ToList();
            List<double?> TotalDebt = totalEquityvsDebt.Select(e => Convert.ToDouble(e.TotalDebt).ConvertCrores()).Cast<double?>().ToList();
            List<string> Lables = totalEquityvsDebt.Select(e => e.FiscalYear).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Total Equity",
                Data = TotalEquity,
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
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Total Debt",
                Data = TotalDebt,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Fiscal Years", "Amount in Crore Taka", dataset1, dataset2);
        }
        private Chart ExpensevsRevenueBarChart(List<ExpensevsRevenue> expensevsRevenue)
        {
            List<double?> Revenue = expensevsRevenue.Select(e => Convert.ToDouble(e.Revenue).ConvertCrores()).Cast<double?>().ToList();
            List<double?> Expense = expensevsRevenue.Select(e => Convert.ToDouble(e.Expense).ConvertCrores()).Cast<double?>().ToList();
            List<string> Lables = expensevsRevenue.Select(e => e.FiscalYear).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Revenue",
                Data = Revenue,
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
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Expenditure",
                Data = Expense,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Fiscal Years", "Amount in Crore Taka", dataset1, dataset2);
        }
        private Chart GrossProfitvsNetProfitBarChart(List<GrossProfitvsNetProfit> grossProfitvsNetProfit)
        {
            List<double?> GrossProfit = grossProfitvsNetProfit.Select(e => Convert.ToDouble(e.GrossProfit).ConvertCrores()).Cast<double?>().ToList();
            List<double?> NetProfit = grossProfitvsNetProfit.Select(e => Convert.ToDouble(e.NetProfit).ConvertCrores()).Cast<double?>().ToList();
            List<string> Lables = grossProfitvsNetProfit.Select(e => e.FiscalYear).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Gross Profit",
                Data = GrossProfit,
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
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Net Profit",
                Data = NetProfit,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Fiscal Years", "Amount in Crore Taka", dataset1, dataset2);
        }
        private Chart ReceivablevsPayableBarChart(List<ReceivablevsPayable> receivablevsPayable)
        {
            List<double?> AccountReceivable = receivablevsPayable.Select(e => Convert.ToDouble(e.AccountReceivable).ConvertCrores()).Cast<double?>().ToList();
            List<double?> AccountPayable = receivablevsPayable.Select(e => Convert.ToDouble(e.AccountPayable).ConvertCrores()).Cast<double?>().ToList();
            List<string> Lables = receivablevsPayable.Select(e => e.FiscalYear).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Account Receivable",
                Data = AccountReceivable,
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
            BarDataset dataset2 = new BarDataset()
            {
                Label = "Account Payable",
                Data = AccountPayable,
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromHexString("#FE9666"),
                },
                BorderColor = new List<ChartColor>
                {
                   ChartColor.FromHexString("#FE9666"),
                },
                BorderWidth = new List<int>() { 1 }
            };

            return ChartHelper.GenerateBarChart(Lables, "Fiscal Years", "Amount in Crore Taka", dataset1, dataset2);
        }
        private Chart UtilityWiseGrossProfitBarChart(List<UtilityWiseGrossProfit> utilityWiseGrossProfit)
        {
            List<double?> GrossProfit = utilityWiseGrossProfit.Select(e => Convert.ToDouble(e.GrossProfit).ConvertCrores()).Cast<double?>().ToList();
            List<string> Lables = utilityWiseGrossProfit.Select(e => e.Organization).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Gross Profit",
                Data = GrossProfit,
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


            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Amount in Crore Taka", dataset1);
        }
        private Chart UtilityWiseNetProfitBarChart(List<UtilityWiseNetProfit> utilityWiseNetProfit)
        {
            List<double?> NetProfit = utilityWiseNetProfit.Select(e => Convert.ToDouble(e.NetProfit).ConvertCrores()).Cast<double?>().ToList();
            List<string> Lables = utilityWiseNetProfit.Select(e => e.Organization).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Net Profit",
                Data = NetProfit,
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


            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Amount in Crore Taka", dataset1);
        }
        private Chart UtilityWiseTurnoverBarChart(List<UtilityWiseTurnover> utilityWiseTurnover)
        {
            List<double?> Turnover = utilityWiseTurnover.Select(e => Convert.ToDouble(e.Turnover).ConvertCrores()).Cast<double?>().ToList();
            List<string> Lables = utilityWiseTurnover.Select(e => e.Organization).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Turnover",
                Data = Turnover,
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


            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Amount in Crore Taka", dataset1);
        }
        private Chart UtilityWiseCashAndCashEquivalentBarChart(List<UtilityWiseCashAndCashEquivalent> utilityWiseCashAndCashEquivalent)
        {
            List<double?> CashAndCashEquivalent = utilityWiseCashAndCashEquivalent.Select(e => Convert.ToDouble(e.CashAndCashEquivalent).ConvertCrores()).Cast<double?>().ToList();
            List<string> Lables = utilityWiseCashAndCashEquivalent.Select(e => e.Organization).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Cash And Cash Equivalent",
                Data = CashAndCashEquivalent,
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


            return ChartHelper.GenerateBarChart(Lables, "Utilities", "Amount in Crore Taka", dataset1);
        }
        private Chart UtilityWiseCurrentRatioBarChart(List<UtilityWiseCurrentRatio> utilityWiseCurrentRatio)
        {
            List<double?> CurrentRatio = utilityWiseCurrentRatio.Select(e => Convert.ToDouble(e.CurrentRatio)).Cast<double?>().ToList();
            List<string> Lables = utilityWiseCurrentRatio.Select(e => e.Organization).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Current Ratio",
                Data = CurrentRatio,
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


            return ChartHelper.GenerateBarChart(Lables, "Name of Utilities", "Ratio Value", dataset1);
        }
        private Chart UtilityWiseQuickRatioBarChart(List<UtilityWiseQuickRatio> utilityWiseQuickRatio)
        {
            List<double?> QuickRatio = utilityWiseQuickRatio.Select(e => Convert.ToDouble(e.QuickRatio)).Cast<double?>().ToList();
            List<string> Lables = utilityWiseQuickRatio.Select(e => e.Organization).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Quick Ratio",
                Data = QuickRatio,
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


            return ChartHelper.GenerateBarChart(Lables, "Name of Utilities", "Ratio Value", dataset1);
        }
        private Chart UtilityWiseDebtRatioBarChart(List<UtilityWiseDebtRatio> utilityWiseDebtRatio)
        {
            List<double?> DebtRatio = utilityWiseDebtRatio.Select(e => Convert.ToDouble(e.DebtRatio)).Cast<double?>().ToList();
            List<string> Lables = utilityWiseDebtRatio.Select(e => e.Organization).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Debt Ratio",
                Data = DebtRatio,
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


            return ChartHelper.GenerateBarChart(Lables, "Name of Utilities", "Ratio Value", dataset1);
        }
        #endregion

        #region  Finence_Executive_Dashboard
        public async Task<IActionResult> Finence_Executive_Dashboard()
        {
            var Organization = HttpContext.User.FindFirstValue("Organization");

            Finence_Executive_Entity finence_Executive_Entity = await _repositoryFinence_Executive.GetAllReports(Organization);
            Chart FinanceETotalAssets = FinanceETotalAssetsBarChart(finence_Executive_Entity.FinanceETotalAssetsList.OrderBy(e => e.SequenceNo).ToList());
            Chart FinanceETotalLiabilities = FinanceETotalLiabilitiesBarChart(finence_Executive_Entity.FinanceETotalLiabilitiesList.OrderBy(e => e.SequenceNo).ToList());
            Chart FinanceETotalEquity = FinanceETotalEquityBarChart(finence_Executive_Entity.FinanceETotalEquityList.OrderBy(e => e.SequenceNo).ToList());
            Chart FinanceETotalDebt = FinanceETotalDebtBarChart(finence_Executive_Entity.FinanceETotalDebtList.OrderBy(e => e.SequenceNo).ToList());
            


            ViewData["FinanceETotalAssets"] = FinanceETotalAssets;
            ViewData["FinanceETotalLiabilities"] = FinanceETotalLiabilities;
            ViewData["FinanceETotalEquity"] = FinanceETotalEquity;
            ViewData["FinanceETotalDebt"] = FinanceETotalDebt;
            


            return View();
        }
        private Chart FinanceETotalAssetsBarChart(List<FinanceETotalAssets> FinanceETotalAssets)
        {
            List<double?> Amount = FinanceETotalAssets.Select(e => Convert.ToDouble(e.Amount).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = FinanceETotalAssets.Select(e => e.Year).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Total Assets",
                Data = Amount,
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

            return ChartHelper.GenerateBarChart(Lables, "Financial Year", "Amount", dataset1).AddMillionWithYaxes();
        }
        private Chart FinanceETotalLiabilitiesBarChart(List<FinanceETotalLiabilities> FinanceETotalLiabilities)
        {
            List<double?> Amount = FinanceETotalLiabilities.Select(e => Convert.ToDouble(e.Amount).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = FinanceETotalLiabilities.Select(e => e.Year).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Total Liabilities",
                Data = Amount,
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

            return ChartHelper.GenerateBarChart(Lables, "Financial Year", "Amount", dataset1).AddMillionWithYaxes();
        }
        private Chart FinanceETotalEquityBarChart(List<FinanceETotalEquity> FinanceETotalEquity)
        {
            List<double?> Amount = FinanceETotalEquity.Select(e => Convert.ToDouble(e.Amount).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = FinanceETotalEquity.Select(e => e.Year).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Total Equity",
                Data = Amount,
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

            return ChartHelper.GenerateBarChart(Lables, "Financial Year", "Amount", dataset1).AddMillionWithYaxes();
        }
        private Chart FinanceETotalDebtBarChart(List<FinanceETotalDebt> FinanceETotalDebt)
        {
            List<double?> Amount = FinanceETotalDebt.Select(e => Convert.ToDouble(e.Amount).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = FinanceETotalDebt.Select(e => e.Year).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Total Debt",
                Data = Amount,
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

            return ChartHelper.GenerateBarChart(Lables, "Financial Year", "Amount", dataset1).AddMillionWithYaxes();
        }
        
        #endregion

        #region  Finence_Executive_Dashboard2
        public async Task<IActionResult> Finence_Executive_Dashboard2()
        {
            var Organization = HttpContext.User.FindFirstValue("Organization");

            Finence_Executive_Entity finence_Executive_Entity = await _repositoryFinence_Executive.GetAllReports(Organization);
            Chart FinanceENetMargin = FinanceENetMarginBarChart(finence_Executive_Entity.FinanceENetMarginList.OrderBy(e => e.SequenceNo).ToList());
            Chart FinanceETotalTax = FinanceETotalTaxBarChart(finence_Executive_Entity.FinanceETotalTaxList.OrderBy(e => e.SequenceNo).ToList());
            Chart FinanceEProfitablyRatio = FinanceEProfitablyRatioPieChart(finence_Executive_Entity.FinanceEProfitablyRatioList);
            Chart FinanceECurrentRatio = FinanceECurrentRatioPieChart(finence_Executive_Entity.FinanceECurrentRatioList);
            Chart FinanceEQuickRatio = FinanceEQuickRatioPieChart(finence_Executive_Entity.FinanceEQuickRatioList);


            ViewData["FinanceENetMargin"] = FinanceENetMargin;
            ViewData["FinanceETotalTax"] = FinanceETotalTax;
            ViewData["FinanceEProfitablyRatio"] = FinanceEProfitablyRatio;
            ViewData["FinanceECurrentRatio"] = FinanceECurrentRatio;
            ViewData["FinanceEQuickRatio"] = FinanceEQuickRatio;


            return View();
        }
        private Chart FinanceENetMarginBarChart(List<FinanceENetMargin> FinanceENetMargin)
        {
            List<double?> Amount = FinanceENetMargin.Select(e => Convert.ToDouble(e.Amount).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = FinanceENetMargin.Select(e => e.Year).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Net Margin",
                Data = Amount,
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

            return ChartHelper.GenerateBarChart(Lables, "Financial Year", "Amount", dataset1).AddMillionWithYaxes();
        }
        private Chart FinanceETotalTaxBarChart(List<FinanceETotalTax> FinanceETotalTax)
        {
            List<double?> Amount = FinanceETotalTax.Select(e => Convert.ToDouble(e.Amount).ConvertMillions()).Cast<double?>().ToList();
            List<string> Lables = FinanceETotalTax.Select(e => e.Year).ToList();

            BarDataset dataset1 = new BarDataset()
            {
                Label = "Total Tax",
                Data = Amount,
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

            return ChartHelper.GenerateBarChart(Lables, "Financial Year", "Amount", dataset1).AddMillionWithYaxes();
        }
        private Chart FinanceEProfitablyRatioPieChart(List<FinanceEProfitablyRatio> FinanceEProfitablyRatio)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> Amount = FinanceEProfitablyRatio.Select(e => Convert.ToDouble(e.Amount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(Amount.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = FinanceEProfitablyRatio.Select(e => e.Year).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Amount",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = Amount
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart FinanceECurrentRatioPieChart(List<FinanceECurrentRatio> FinanceECurrentRatio)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> Amount = FinanceECurrentRatio.Select(e => Convert.ToDouble(e.Amount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(Amount.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = FinanceECurrentRatio.Select(e => e.Year).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Amount",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = Amount
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        private Chart FinanceEQuickRatioPieChart(List<FinanceEQuickRatio> FinanceEQuickRatio)
        {
            string[] colorList = ChartHelper.GetColorList();
            List<double?> Amount = FinanceEQuickRatio.Select(e => Convert.ToDouble(e.Amount)).Cast<double?>().ToList();
            List<ChartColor> backgroundColorList = new List<ChartColor>();

            foreach (var item in colorList.Take(Amount.Count()))
            {
                backgroundColorList.Add(ChartColor.FromHexString(item));
            }

            List<string> Lables = FinanceEQuickRatio.Select(e => e.Year).ToList();
            PieDataset dataset = new PieDataset()
            {
                Label = "Amount",
                BackgroundColor = backgroundColorList,
                HoverBackgroundColor = backgroundColorList,
                Data = Amount
            };
            return ChartHelper.GeneratePieChart(Lables, dataset);
        }
        #endregion

        #region Js Graph
        //HR
        public async Task<JsonResult> GetCategoryWiseEmployeeData(string org)
        {
            HRManagement_Entity hRManagement_Entity = await _repositoryHRManagement.GetAllReports(org);
            var result = hRManagement_Entity.EmployeeJobStatusList;
            return Json(result);
        }
        public async Task<JsonResult> GetOrgWiseOfficerStaffEmpData(string org)
        {
            //HRManagement_Entity hRManagement_Entity = await _repositoryHRManagement.GetAllReports(org);
            //var result = hRManagement_Entity.OrgPostWiseEmpList;
            var postWiseEmploymentStatus = await _repositoryHRManagement.GetPostWiseEmploymentStatus();
            var result = postWiseEmploymentStatus.Where(s => s.Organization == org).ToList();
            return Json(result);
        }
        public async Task<JsonResult> GetOrgWiseEmploymentStatusData(string postType)
        {
            var postWiseEmploymentStatus = await _repositoryHRManagement.GetPostWiseEmploymentStatus();
            var result = postWiseEmploymentStatus.Where(s => s.PostType == postType).ToList();
            return Json(result);
        }
        public async Task<JsonResult> GetOrgPostWiseUpcommingRetirmentData(string org)
        {
            HRManagement_Entity hRManagement_Entity = await _repositoryHRManagement.GetAllReports(org);
            var result = hRManagement_Entity.UpcommingRetirementList;
            return Json(result);
        }
        public async Task<JsonResult> GetDesignationWiseEmpCount(string org, string postType)
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var designationWiseEmpCounts = await _repositoryHRManagement.GetDesignationWiseEmployeeCount(org, postType, searchValue, skip, pageSize);
                recordsTotal = designationWiseEmpCounts.TotalCount;
                var data = designationWiseEmpCounts.Items;
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Json(jsonData);

            }
            catch (Exception ex)
            {
                throw;
            }            
        }
        public async Task<JsonResult> GetForeignTourOfficialData(string org)
        {
            HRManagement_Entity hRManagement_Entity = await _repositoryHRManagement.GetAllReports(org);
            var result = hRManagement_Entity.ForeignTourPurposeWiseOfficialList;
            return Json(result);
        }
        public async Task<JsonResult> GetNetSalaryByMonthData(string salaryDate)
        {
            List<OrgWiseNetSalaryByMonth> orgWiseNetSalaryByMonth = await _repositoryHRFinance.GetOrgWiseNetSalaryByMonth(salaryDate);
            //var result = hRFinance_Entity.OrgWiseNetSalaryByMonthList;
            return Json(orgWiseNetSalaryByMonth);
        }
        public async Task<JsonResult> GetOrgWiseEmpByJobStatusData(string jobStatus)
        {
            List<OrgWiseEmpByJobStatus> orgWiseEmpByJobStatus = await _repositoryHRManagement.GetOrgWiseEmpByJobStatus(jobStatus);
            return Json(orgWiseEmpByJobStatus);
        }
        public async Task<JsonResult> GetOrgWiseEmpByQualificationData(string qualificaion)
        {
            List<OrgWiseEmpByQualification> orgWiseEmpByQualification = await _repositoryHRManagement.GetOrgWiseEmpByQualification(qualificaion);
            return Json(orgWiseEmpByQualification);
        }
        public async Task<JsonResult> GetOrgWiseRetirementvsNewEmployeeData(string org)
        {
            List<OrgWiseRetirementvsNewEmployee> orgWiseRetirementvsNewEmployee = await _repositoryHRManagement.GetOrgWiseRetirementvsNewEmployee(org);
            return Json(orgWiseRetirementvsNewEmployee);
        }
        public async Task<JsonResult> GetDesignationWiseEmpByJobTypeAndOrgData()
        {            
            try
            {
                var organization = Request.Form["organization"].FirstOrDefault();
                var jobStatus = Request.Form["jobStatus"].FirstOrDefault();

                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var dataList = await _repositoryHRManagement.GetDesignationWiseEmpByJobTypeAndOrg(organization, jobStatus);
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                if (!string.IsNullOrEmpty(searchValue))
                {
                    dataList = dataList.Where(m => m.Designation.ToLower().Contains(searchValue)).ToList();
                }
                recordsTotal = dataList.Count();
                var data = dataList.Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Json(jsonData);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<JsonResult> GetDesignationWiseEmpByQualificationAndOrgData()
        {
            //List<DesignationWiseEmpByQualificationAndOrg> designationWiseEmpByQualificationAndOrg = await _repositoryHRManagement.GetDesignationWiseEmpByQualificationAndOrg(org,qualification);
            //return Json(designationWiseEmpByQualificationAndOrg);
            try
            {
                var organization = Request.Form["organization"].FirstOrDefault();
                var qualification = Request.Form["qualification"].FirstOrDefault();

                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var dataList = await _repositoryHRManagement.GetDesignationWiseEmpByQualificationAndOrg(organization, qualification);
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                if (!string.IsNullOrEmpty(searchValue))
                {
                    dataList = dataList.Where(m => m.Designation.ToLower().Contains(searchValue)).ToList();
                }
                recordsTotal = dataList.Count();
                var data = dataList.Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Json(jsonData);

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //FA
        public async Task<JsonResult> GetUsagesWiseLandByOrgData(string org)
        {
            List<UsagesWiseLandByOrg> usagesWiseLandByOrg = await _repositoryFAManagement.GetUsagesWiseLandByOrg(org);
            return Json(usagesWiseLandByOrg);
        }
        public async Task<JsonResult> GetOrgWiseLandByUsagesData(string usages)
        {
            List<OrgWiseLandByUsages> orgWiseLandByUsages = await _repositoryFAManagement.GetOrgWiseLandByUsages(usages);
            return Json(orgWiseLandByUsages);
        }
        public async Task<JsonResult> GetFuleWiswPPByOrgData(string usages)
        {
            List<FuleWiswPPByOrg> fuleWiswPPByOrg = await _repositoryFAManagement.GetFuleWiswPPByOrg(usages);
            return Json(fuleWiswPPByOrg);
        }
        #endregion

        private string GetXaxisLable()
        { 
            var organizationName = HttpContext.User.FindFirstValue("Organization");
            var xaxisLable = "Office Name";
            if (organizationName == "IDTP")
            {
                xaxisLable = "Company Name";
            }
            return xaxisLable;
        }

        #region  IDTPDashboard1
        public async Task<IActionResult> IDTPDashboard1()
        {
            var Organization = HttpContext.User.FindFirstValue("Organization");

            HRManagement_Entity hRManagement_Entity = await _repositoryHRManagement.GetAllReports(Organization);
            Chart attendanceInfo = AttendanceInfoBarChart(hRManagement_Entity.EmployeeAttendanceList);
            Chart retirementvsNewEmployee = RetirementvsNewEmployeeBarChart(hRManagement_Entity.RetirementvsNewEmployeeList);
            Chart foreignTourOrganizationWise = ForeignTourOrganizationWiseBarChart(hRManagement_Entity.ForeignTourOrganizationWiseList);
            Chart employeeOnLeave = EmployeeOnLeaveBarChart(hRManagement_Entity.EmployeeOnLeaveList);
            Chart filledPostVacantPosts = FilledPostVacantPostBarChart(hRManagement_Entity.FilledPostVacantPostList);
            Chart filledPostVacantPostUtilityWise = FilledPostVacantPostUtilityWiseBarChart(hRManagement_Entity.FilledPostVacantPostUtilityWiseList);
            Chart upcommingRetirement = UpcommingRetirementBarChart(hRManagement_Entity.UpcommingRetirementCompanyWiseList);
            Chart totalEmployeeUtilityWise = TotalEmployeeUtilityWiseBarChart(hRManagement_Entity.TotalEmployeeUtilityWiseList);
            Chart utilitywiseLastFiscalYearSalary = UtilitywiseLastFiscalYearSalaryBarChart(hRManagement_Entity.UtilitywiseLastFiscalYearSalaryList);
            Chart employeePerformancePieChart = EmployeePerformancePieChart(hRManagement_Entity.EmployeePerformanceList);
            Chart employeeJobStatusPieChart = EmployeeJobStatusPieChart(hRManagement_Entity.EmployeeJobStatusList);
            Chart employeeQualifcationPieChart = EmployeeQualifcationPieChart(hRManagement_Entity.EmployeeQualifcationList);
            Chart foreignTourCategoryWisePieChart = ForeignTourCategoryWisePieChart(hRManagement_Entity.ForeignTourCategoryWiseList);
            Chart foreignTourPurposeWiseOfficialPieChart = ForeignTourPurposeWiseOfficialPieChart(hRManagement_Entity.ForeignTourPurposeWiseOfficialList);
            Chart foreignTourPurposeWisePersonalPieChart = ForeignTourPurposeWisePersonalPieChart(hRManagement_Entity.ForeignTourPurposeWisePersonalList);

            //HRE
            HRExecutive_Entity hRExecutive_Entity = await _repositoryHRExecutive.GetAllReports(Organization);
            Chart EmployeeAgeRange = EmployeeAgeRangeBarChart(hRExecutive_Entity.EmployeeAgeRangeList.ToList());
            Chart EmployeeAgeRangeGenderWise = EmployeeAgeRangeGenderWiseBarChart(hRExecutive_Entity.EmployeeAgeRangeGenderWiseList.ToList());
            Chart EmployeeYearsofService = EmployeeYearsofServiceBarChart(hRExecutive_Entity.EmployeeYearsofServiceList.ToList());
            Chart YearlyTurnover = YearlyTurnoverBarChart(hRExecutive_Entity.YearlyTurnoverList.OrderBy(e => e.Order).ToList());
            Chart YearlyRecruitment = YearlyRecruitmentBarChart(hRExecutive_Entity.YearlyRecruitmentList.OrderBy(e => e.Order).ToList());
            Chart YearlyTermination = YearlyTerminationBarChart(hRExecutive_Entity.YearlyTerminationList.OrderBy(e => e.Order).ToList());
            Chart YearlyPromotion = YearlyPromotionBarChart(hRExecutive_Entity.YearlyPromotionList.OrderBy(e => e.Order).ToList());
            Chart EmployeebyCategory = EmployeebyCategoryPieChart(hRExecutive_Entity.EmployeebyCategoryList);
            Chart MaleFemaleRatioBoth = MaleFemaleRatioPieChart(hRExecutive_Entity.MaleFemaleRatioBothList);
            Chart MaleFemaleRatioOfficer = MaleFemaleRatioPieChart(hRExecutive_Entity.MaleFemaleRatioOfficerList);
            Chart MaleFemaleRatioStaff = MaleFemaleRatioPieChart(hRExecutive_Entity.MaleFemaleRatioStaffList);
            Chart RetirementvsTerminatedOverall = RetirementvsTerminatedOverallPieChart(hRExecutive_Entity.RetirementvsTerminatedOverallList);
            Chart TechnicalNonTechnicalCadrewiseinformation = TechnicalNonTechnicalCadrewiseinformationBarChart(hRExecutive_Entity.TechnicalNonTechnicalCadrewiseinformationList.ToList());

            //HRF
            HRFinance_Entity hRFinance_Entity = await _repositoryHRFinance.GetAllReports(Organization);
            Chart salaryByEmployeeCategory = SalaryByEmployeeCategoryStackedBarChart(hRFinance_Entity.SalaryByEmployeeCategoryList);
            Chart netSalaryByMonth = NetSalaryByMonthBarChart(hRFinance_Entity.NetSalaryByMonthList);
            Chart allowanceDeductionByMonth = AllowanceDeductionByMonthStackedBarChart(hRFinance_Entity.AllowanceDeductionByMonthList);
            Chart salaryByOffices = SalaryByOfficesBarChart(hRFinance_Entity.SalaryByOfficesList);
            Chart grossSalaryExpenditurePieChart = GrossSalaryExpenditurePieChart(hRFinance_Entity.GrossSalaryExpenditureList);
            Chart festivalBonusPieChart = FestivalBonusPieChart(hRFinance_Entity.FestivalBonusList);
            Chart cPFContributionPieChart = CPFContributionPieChart(hRFinance_Entity.CPFContributionList);

            long TotalEmployee = hRManagement_Entity.TotalEmployeeList.FirstOrDefault().totalemployee;
            ViewData["totalemployee"] = Convert.ToDecimal(TotalEmployee).ToString("#,##0");
            ViewData["attendanceInfo"] = attendanceInfo;
            //ViewData["retirementvsNewEmployee"] = retirementvsNewEmployee;
            //ViewData["foreignTourOrganizationWise"] = foreignTourOrganizationWise;
            ViewData["employeeOnLeave"] = employeeOnLeave;
            ViewData["filledPostVacantPosts"] = filledPostVacantPosts;
            ViewData["filledPostVacantPostUtilityWise"] = filledPostVacantPostUtilityWise;
            ViewData["upcommingRetirement"] = upcommingRetirement;
            ViewData["totalEmployeeUtilityWise"] = totalEmployeeUtilityWise;
            ViewData["utilitywiseLastFiscalYearSalary"] = utilitywiseLastFiscalYearSalary;
            ViewData["employeePerformancePieChart"] = employeePerformancePieChart;
            //ViewData["employeeJobStatusPieChart"] = employeeJobStatusPieChart;
            //ViewData["employeeQualifcationPieChart"] = employeeQualifcationPieChart;
            ViewData["foreignTourCategoryWisePieChart"] = foreignTourCategoryWisePieChart;
            ViewData["foreignTourPurposeWiseOfficialPieChart"] = foreignTourPurposeWiseOfficialPieChart;
            ViewData["foreignTourPurposeWisePersonalPieChart"] = foreignTourPurposeWisePersonalPieChart;

            //HRE
            ViewData["EmployeeAgeRange"] = EmployeeAgeRange;
            ViewData["EmployeeYearsofService"] = EmployeeYearsofService;
            ViewData["YearlyTurnover"] = YearlyTurnover;
            ViewData["YearlyRecruitment"] = YearlyRecruitment;
            ViewData["YearlyTermination"] = YearlyTermination;
            ViewData["YearlyPromotion"] = YearlyPromotion;
            ViewData["EmployeebyCategory"] = EmployeebyCategory;
            ViewData["MaleFemaleRatioBoth"] = MaleFemaleRatioBoth;
            ViewData["MaleFemaleRatioOfficer"] = MaleFemaleRatioOfficer;
            ViewData["MaleFemaleRatioStaff"] = MaleFemaleRatioStaff;
            ViewData["EmployeeAgeRangeGenderWise"] = EmployeeAgeRangeGenderWise;
            ViewData["RetirementvsTerminatedOverall"] = RetirementvsTerminatedOverall;
            ViewData["TechnicalNonTechnicalCadrewiseinformation"] = TechnicalNonTechnicalCadrewiseinformation;

            //HEF
            ViewData["salaryByEmployeeCategory"] = salaryByEmployeeCategory;
            //ViewData["netSalaryByMonth"] = netSalaryByMonth;
            ViewData["allowanceDeductionByMonth"] = allowanceDeductionByMonth;
            ViewData["salaryByOffices"] = salaryByOffices;
            ViewData["grossSalaryExpenditurePieChart"] = grossSalaryExpenditurePieChart;
            ViewData["festivalBonusPieChart"] = festivalBonusPieChart;
            ViewData["cPFContributionPieChart"] = cPFContributionPieChart;
            //JS Chartjs
            ViewData["totalEmpUtilityWise"] = hRManagement_Entity.TotalEmployeeUtilityWiseList;
            ViewData["filledPostVacantPosts"] = hRManagement_Entity.FilledPostVacantPostList;
            ViewData["upcommingRetirement"] = hRManagement_Entity.UpcommingRetirementCompanyWiseList;
            ViewData["retirementvsNewEmployee"] = hRManagement_Entity.RetirementvsNewEmployeeList;
            ViewData["foreignTourOrganizationWise"] = hRManagement_Entity.ForeignTourOrganizationWiseList;
            ViewData["netSalaryByMonth"] = hRFinance_Entity.NetSalaryByMonthList;
            ViewData["employeeJobStatusPieChart"] = hRManagement_Entity.EmployeeJobStatusList;
            ViewData["employeeQualifcationPieChart"] = hRManagement_Entity.EmployeeQualifcationList;
            return View();
        }
        #endregion
    }
}
