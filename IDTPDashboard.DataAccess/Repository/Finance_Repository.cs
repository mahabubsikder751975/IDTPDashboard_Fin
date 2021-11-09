using IDTPDashboard.DataAccess.Interface;
using IDTPDashboard.DomainModel.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Repository
{

    public class Finance_Repository : IFinance_Repository
    {
        private readonly string _connectionString;
        public Finance_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }
        public async Task<Finance_Entity> GetAllReports(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Finance_Dashboard", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Organization", Organization));

                    var response = new Finance_Entity();
                    var RevenueVsExpenseData = new List<RevenueVsExpense>();
                    var NetProfitVsGrossRevenueData = new List<NetProfitVsGrossRevenue>();
                    var AccountReceivableVsCashflowData = new List<AccountReceivableVsCashflow>();
                    var CapitalExpenditureVsOperationalExpensesData = new List<CapitalExpenditureVsOperationalExpenses>();
                    var AccountsPayableData = new List<AccountsPayable>();
                    var AccountsReceivableData = new List<AccountsReceivable>();
                    var YearlyTurnOverData = new List<YearlyTurnOver>();
                    var TotalAssetsvsTotalLiabilitiesData = new List<TotalAssetsvsTotalLiabilities>();
                    var TotalEquityvsDebtData = new List<TotalEquityvsDebt>();
                    var ExpensevsRevenueData = new List<ExpensevsRevenue>();
                    var GrossProfitvsNetProfitData = new List<GrossProfitvsNetProfit>();
                    var ReceivablevsPayableData = new List<ReceivablevsPayable>();
                    var FiscalYearlyTurnoverData = new List<FiscalYearlyTurnover>();
                    var CurrentRatioFiscalYearWiseData = new List<CurrentRatioFiscalYearWise>();
                    var QuickRatioFiscalYearWiseData = new List<QuickRatioFiscalYearWise>();
                    var DebtRatioFiscalYearWiseData = new List<DebtRatioFiscalYearWise>();
                    var UtilityWiseGrossProfitData = new List<UtilityWiseGrossProfit>();
                    var UtilityWiseNetProfitData = new List<UtilityWiseNetProfit>();
                    var UtilityWiseTurnoverData = new List<UtilityWiseTurnover>();
                    var UtilityWiseCashAndCashEquivalentData = new List<UtilityWiseCashAndCashEquivalent>();
                    var UtilityWiseCurrentRatioData = new List<UtilityWiseCurrentRatio>();
                    var UtilityWiseQuickRatioData = new List<UtilityWiseQuickRatio>();
                    var UtilityWiseDebtRatioData = new List<UtilityWiseDebtRatio>();


                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                RevenueVsExpenseData.Add(RevenueVsExpenseMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                NetProfitVsGrossRevenueData.Add(NetProfitVsGrossRevenueMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                AccountReceivableVsCashflowData.Add(AccountReceivableVsCashflowMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                CapitalExpenditureVsOperationalExpensesData.Add(CapitalExpenditureVsOperationalExpensesMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                AccountsPayableData.Add(AccountsPayableMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                AccountsReceivableData.Add(AccountsReceivableMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                YearlyTurnOverData.Add(YearlyTurnOverMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                TotalAssetsvsTotalLiabilitiesData.Add(TotalAssetsvsTotalLiabilitiesMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                TotalEquityvsDebtData.Add(TotalEquityvsDebtMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                               ExpensevsRevenueData.Add(ExpensevsRevenueMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                GrossProfitvsNetProfitData.Add(GrossProfitvsNetProfitMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                ReceivablevsPayableData.Add(ReceivablevsPayableMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                FiscalYearlyTurnoverData.Add(FiscalYearlyTurnoverMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                CurrentRatioFiscalYearWiseData.Add(CurrentRatioFiscalYearWiseMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                QuickRatioFiscalYearWiseData.Add(QuickRatioFiscalYearWiseMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                DebtRatioFiscalYearWiseData.Add(DebtRatioFiscalYearWiseMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                UtilityWiseGrossProfitData.Add(UtilityWiseGrossProfitMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                UtilityWiseNetProfitData.Add(UtilityWiseNetProfitMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                UtilityWiseTurnoverData.Add(UtilityWiseTurnoverMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                UtilityWiseCashAndCashEquivalentData.Add(UtilityWiseCashAndCashEquivalentMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                UtilityWiseCurrentRatioData.Add(UtilityWiseCurrentRatioMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                UtilityWiseQuickRatioData.Add(UtilityWiseQuickRatioMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                UtilityWiseDebtRatioData.Add(UtilityWiseDebtRatioMapToValue(reader));
                            }

                            response.RevenueVsExpenseList = RevenueVsExpenseData;
                            response.NetProfitVsGrossRevenueList = NetProfitVsGrossRevenueData;
                            response.AccountReceivableVsCashflowList = AccountReceivableVsCashflowData;
                            response.CapitalExpenditureVsOperationalExpensesList = CapitalExpenditureVsOperationalExpensesData;
                            response.AccountsPayableList = AccountsPayableData;
                            response.AccountsReceivableList = AccountsReceivableData;
                            response.YearlyTurnOverList = YearlyTurnOverData;
                            response.TotalAssetsvsTotalLiabilitiesList = TotalAssetsvsTotalLiabilitiesData;
                            response.TotalEquityvsDebtList = TotalEquityvsDebtData;
                            response.ExpensevsRevenueList = ExpensevsRevenueData;
                            response.GrossProfitvsNetProfitList = GrossProfitvsNetProfitData;
                            response.ReceivablevsPayableList = ReceivablevsPayableData;
                            response.FiscalYearlyTurnoverList = FiscalYearlyTurnoverData;
                            response.CurrentRatioFiscalYearWiseList = CurrentRatioFiscalYearWiseData;
                            response.QuickRatioFiscalYearWiseList = QuickRatioFiscalYearWiseData;
                            response.DebtRatioFiscalYearWiseList = DebtRatioFiscalYearWiseData;
                            response.UtilityWiseGrossProfitList = UtilityWiseGrossProfitData;
                            response.UtilityWiseNetProfitList = UtilityWiseNetProfitData;
                            response.UtilityWiseTurnoverList = UtilityWiseTurnoverData;
                            response.UtilityWiseCashAndCashEquivalentList = UtilityWiseCashAndCashEquivalentData;
                            response.UtilityWiseCurrentRatioList = UtilityWiseCurrentRatioData;
                            response.UtilityWiseQuickRatioList = UtilityWiseQuickRatioData;
                            response.UtilityWiseDebtRatioList = UtilityWiseDebtRatioData;
                        }

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                    return response;
                }
            }
        }
        private RevenueVsExpense RevenueVsExpenseMapToValue(SqlDataReader reader)
        {
            return new RevenueVsExpense()
            {
                Organization = reader["Organization"].ToString(),
                OfficeName = reader["OfficeName"].ToString(),
                Expense = Convert.ToInt32(reader["Expense"].ToString()),
                Revenue = Convert.ToInt32(reader["Revenue"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private NetProfitVsGrossRevenue NetProfitVsGrossRevenueMapToValue(SqlDataReader reader)
        {
            return new NetProfitVsGrossRevenue()
            {
                Organization = reader["Organization"].ToString(),
                OfficeName = reader["OfficeName"].ToString(),
                NetProfit = Convert.ToInt32(reader["NetProfit"].ToString()),
                GrossRevenue = Convert.ToInt32(reader["GrossRevenue"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private AccountReceivableVsCashflow AccountReceivableVsCashflowMapToValue(SqlDataReader reader)
        {
            return new AccountReceivableVsCashflow()
            {
                Organization = reader["Organization"].ToString(),
                OfficeName = reader["OfficeName"].ToString(),
                YearConcern = reader["YearConcern"].ToString(),
                Receivable = Convert.ToInt32(reader["Receivable"].ToString()),
                Cashflow = Convert.ToInt32(reader["Cashflow"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private CapitalExpenditureVsOperationalExpenses CapitalExpenditureVsOperationalExpensesMapToValue(SqlDataReader reader)
        {
            return new CapitalExpenditureVsOperationalExpenses()
            {
                Organization = reader["Organization"].ToString(),
                OfficeName = reader["OfficeName"].ToString(),
                CapEx = Convert.ToInt32(reader["CapEx"].ToString()),
                OpEx = Convert.ToInt32(reader["OpEx"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private AccountsPayable AccountsPayableMapToValue(SqlDataReader reader)
        {
            return new AccountsPayable()
            {
                Organization = reader["Organization"].ToString(),
                OfficeName = reader["OfficeName"].ToString(),
                Amount = Convert.ToInt32(reader["AccountsPayable"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private AccountsReceivable AccountsReceivableMapToValue(SqlDataReader reader)
        {
            return new AccountsReceivable()
            {
                Organization = reader["Organization"].ToString(),
                OfficeName = reader["OfficeName"].ToString(),
                Amount = Convert.ToInt32(reader["ROI"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private YearlyTurnOver YearlyTurnOverMapToValue(SqlDataReader reader)
        {
            return new YearlyTurnOver()
            {
                Organization = reader["Organization"].ToString(),
                OfficeName = reader["OfficeName"].ToString(),
                Amount = Convert.ToInt32(reader["AccountsPayable"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private TotalAssetsvsTotalLiabilities TotalAssetsvsTotalLiabilitiesMapToValue(SqlDataReader reader)
        {
            return new TotalAssetsvsTotalLiabilities()
            {
                FiscalYear = reader["FiscalYear"].ToString(),
                TotalAssets = Convert.ToInt64(reader["TotalAssets"].ToString()),
                TotalLiabilities = Convert.ToInt64(reader["TotalLiabilities"].ToString())
            };
        }
        private TotalEquityvsDebt TotalEquityvsDebtMapToValue(SqlDataReader reader)
        {
            return new TotalEquityvsDebt()
            {
                FiscalYear = reader["FiscalYear"].ToString(),
                TotalEquity = Convert.ToInt64(reader["TotalEquity"].ToString()),
                TotalDebt = Convert.ToInt64(reader["TotalDebt"].ToString())
            };
        }
        private ExpensevsRevenue ExpensevsRevenueMapToValue(SqlDataReader reader)
        {
            return new ExpensevsRevenue()
            {
                FiscalYear = reader["FiscalYear"].ToString(),
                Revenue = Convert.ToInt64(reader["Revenue"].ToString()),
                Expense = Convert.ToInt64(reader["Expense"].ToString())
            };
        }
        private GrossProfitvsNetProfit GrossProfitvsNetProfitMapToValue(SqlDataReader reader)
        {
            return new GrossProfitvsNetProfit()
            {
                FiscalYear = reader["FiscalYear"].ToString(),
                GrossProfit = Convert.ToInt64(reader["GrossProfit"].ToString()),
                NetProfit = Convert.ToInt64(reader["NetProfit"].ToString())
            };
        }
        private ReceivablevsPayable ReceivablevsPayableMapToValue(SqlDataReader reader)
        {
            return new ReceivablevsPayable()
            {
                FiscalYear = reader["FiscalYear"].ToString(),
                AccountReceivable = Convert.ToInt64(reader["AccountReceivable"].ToString()),
                AccountPayable = Convert.ToInt64(reader["AccountPayable"].ToString())
            };
        }
        private FiscalYearlyTurnover FiscalYearlyTurnoverMapToValue(SqlDataReader reader)
        {
            return new FiscalYearlyTurnover()
            {
                FiscalYear = reader["FiscalYear"].ToString(),
                Turnover = Convert.ToInt64(reader["Turnover"].ToString())
            };
        }
        private CurrentRatioFiscalYearWise CurrentRatioFiscalYearWiseMapToValue(SqlDataReader reader)
        {
            try
            {
                return new CurrentRatioFiscalYearWise()
                {
                    FiscalYear = reader["FiscalYear"].ToString(),
                    CurrentRatio = Convert.ToDouble(reader["CurrentRatio"].ToString())
                };
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        private QuickRatioFiscalYearWise QuickRatioFiscalYearWiseMapToValue(SqlDataReader reader)
        {
            return new QuickRatioFiscalYearWise()
            {
                FiscalYear = reader["FiscalYear"].ToString(),
                QuickRatio = Convert.ToDouble(reader["QuickRatio"].ToString())
            };
        }
        private DebtRatioFiscalYearWise DebtRatioFiscalYearWiseMapToValue(SqlDataReader reader)
        {
            return new DebtRatioFiscalYearWise()
            {
                FiscalYear = reader["FiscalYear"].ToString(),
                DebtRatio = Convert.ToDouble(reader["DebtRatio"].ToString())
            };
        }
        private UtilityWiseGrossProfit UtilityWiseGrossProfitMapToValue(SqlDataReader reader)
        {
            return new UtilityWiseGrossProfit()
            {
                Organization = reader["Organization"].ToString(),
                GrossProfit = Convert.ToInt64(reader["GrossProfit"].ToString())
            };
        }
        private UtilityWiseNetProfit UtilityWiseNetProfitMapToValue(SqlDataReader reader)
        {
            return new UtilityWiseNetProfit()
            {
                Organization = reader["Organization"].ToString(),
                NetProfit = Convert.ToInt64(reader["NetProfit"].ToString())
            };
        }
        private UtilityWiseTurnover UtilityWiseTurnoverMapToValue(SqlDataReader reader)
        {
            return new UtilityWiseTurnover()
            {
                Organization = reader["Organization"].ToString(),
                Turnover = Convert.ToInt64(reader["Turnover"].ToString())
            };
        }
        private UtilityWiseCashAndCashEquivalent UtilityWiseCashAndCashEquivalentMapToValue(SqlDataReader reader)
        {
            return new UtilityWiseCashAndCashEquivalent()
            {
                Organization = reader["Organization"].ToString(),
                CashAndCashEquivalent = Convert.ToInt64(reader["CashAndCashEquivalent"].ToString())
            };
        }
        private UtilityWiseCurrentRatio UtilityWiseCurrentRatioMapToValue(SqlDataReader reader)
        {
            return new UtilityWiseCurrentRatio()
            {
                Organization = reader["Organization"].ToString(),
                CurrentRatio = Convert.ToDouble(reader["CurrentRatio"].ToString())
            };
        }
        private UtilityWiseQuickRatio UtilityWiseQuickRatioMapToValue(SqlDataReader reader)
        {
            return new UtilityWiseQuickRatio()
            {
                Organization = reader["Organization"].ToString(),
                QuickRatio = Convert.ToDouble(reader["QuickRatio"].ToString())
            };
        }
        private UtilityWiseDebtRatio UtilityWiseDebtRatioMapToValue(SqlDataReader reader)
        {
            return new UtilityWiseDebtRatio()
            {
                Organization = reader["Organization"].ToString(),
                DebtRatio = Convert.ToDouble(reader["DebtRatio"].ToString())
            };
        }
    }
}
