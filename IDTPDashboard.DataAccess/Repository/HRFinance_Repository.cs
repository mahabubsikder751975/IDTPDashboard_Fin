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
    public class HRFinance_Repository : IHRFinance_Repository
    {
        private readonly string _connectionString;
        public HRFinance_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }

        public async Task<HRFinance_Entity> GetAllReports(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HRF_Dashboard", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Organization", Organization));

                    var response = new HRFinance_Entity();
                    var salaryByEmployeeCategoryData = new List<SalaryByEmployeeCategory>();
                    var netSalaryByMonthData = new List<NetSalaryByMonth>();
                    var allowanceDeductionByMonthData = new List<AllowanceDeductionByMonth>();
                    var salaryByOfficesData = new List<SalaryByOffices>();
                    var grossSalaryExpenditureData = new List<GrossSalaryExpenditure>();
                    var festivalBonusData = new List<FestivalBonus>();
                    var cPFContributionData = new List<CPFContribution>();

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                salaryByEmployeeCategoryData.Add(SalaryByEmployeeCategoryMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                netSalaryByMonthData.Add(NetSalaryByMonthMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                allowanceDeductionByMonthData.Add(AllowanceDeductionByMonthMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                salaryByOfficesData.Add(SalaryByOfficesMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                grossSalaryExpenditureData.Add(GrossSalaryExpenditureMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                festivalBonusData.Add(FestivalBonusMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                cPFContributionData.Add(CPFContributionMapToValue(reader));
                            }

                            response.SalaryByEmployeeCategoryList = salaryByEmployeeCategoryData;
                            response.NetSalaryByMonthList = netSalaryByMonthData;
                            response.AllowanceDeductionByMonthList = allowanceDeductionByMonthData;
                            response.SalaryByOfficesList = salaryByOfficesData;
                            response.GrossSalaryExpenditureList = grossSalaryExpenditureData;
                            response.FestivalBonusList = festivalBonusData;
                            response.CPFContributionList = cPFContributionData;
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

        private SalaryByEmployeeCategory SalaryByEmployeeCategoryMapToValue(SqlDataReader reader)
        {
            return new SalaryByEmployeeCategory()
            {
                Technical = Convert.ToDouble(reader["ApprenticeTechnical"].ToString()),
                CasualDailyBasis = Convert.ToDouble(reader["CasualDailyBasis"].ToString()),
                Consultant = Convert.ToDouble(reader["Consultant"].ToString()),
                Contractual = Convert.ToDouble(reader["ContractualEmployees"].ToString()),
                MusterRoll = Convert.ToDouble(reader["MusterRollEmployees"].ToString()),
                Permanent = Convert.ToDouble(reader["PermanentEmployees"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),
                OfficeName = reader["OfficeName"].ToString(),
                PBSName = reader["PBSName"].ToString()
            };
        }

        private NetSalaryByMonth NetSalaryByMonthMapToValue(SqlDataReader reader)
        {
            return new NetSalaryByMonth()
            {
                SalaryDate = reader["SalaryDate"].ToString(),
                TotalSalary = Convert.ToDouble(reader["TotalSalary"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),

            };
        }
        private AllowanceDeductionByMonth AllowanceDeductionByMonthMapToValue(SqlDataReader reader)
        {
            return new AllowanceDeductionByMonth()
            {
                HouseRentAllowance = Convert.ToInt32(reader["HouseRentAllowance"].ToString()),
                TransportAllowance = Convert.ToInt32(reader["TransportAllowance"].ToString()),
                MedicalAllowance = Convert.ToInt32(reader["MedicalAllowance"].ToString()),
                CPFContribution = Convert.ToInt32(reader["CPFContribution"].ToString()),
                TDS = Convert.ToInt32(reader["TDS"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),
                OfficeName = reader["OfficeName"].ToString(),
                PBSName = reader["PBSName"].ToString()

            };
        }
        private SalaryByOffices SalaryByOfficesMapToValue(SqlDataReader reader)
        {
            return new SalaryByOffices()
            {
                TotalSalary = Convert.ToInt32(reader["TotalSalary"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),
                OfficeName = reader["OfficeName"].ToString(),
                PBSName = reader["PBSName"].ToString()

            };
        }
        private GrossSalaryExpenditure GrossSalaryExpenditureMapToValue(SqlDataReader reader)
        {
            return new GrossSalaryExpenditure()
            {
                ExpenditureType = reader["ExpenditureType"].ToString(),
                Amount = Convert.ToInt32(reader["Amount"].ToString())

            };
        }
        private FestivalBonus FestivalBonusMapToValue(SqlDataReader reader)
        {
            return new FestivalBonus()
            {
                BonusName = reader["BonusName"].ToString(),
                BonusAmount = Convert.ToDouble(reader["TotalBonusAmount"].ToString())

            };
        }
        private CPFContribution CPFContributionMapToValue(SqlDataReader reader)
        {
            return new CPFContribution()
            {
                Amount = Convert.ToDouble(reader["CPFContribution"].ToString()),
                OfficeName = reader["OfficeName"].ToString(),
                PBSName = reader["PBSName"].ToString()

            };
        }

        //Other SP
        public async Task<List<OrgWiseNetSalaryByMonth>> GetOrgWiseNetSalaryByMonth(string salaryDate)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetOrgWiseNetSalaryByMonth", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@salaryDate", salaryDate));

                    var orgWiseNetSalaryByMonthData = new List<OrgWiseNetSalaryByMonth>();

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                orgWiseNetSalaryByMonthData.Add(OrgWiseNetSalaryByMonthToValue(reader));
                            }

                        }

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                    return orgWiseNetSalaryByMonthData;
                }
            }
        }

        private OrgWiseNetSalaryByMonth OrgWiseNetSalaryByMonthToValue(SqlDataReader reader)
        {
            return new OrgWiseNetSalaryByMonth()
            {
                Organization = reader["Organization"].ToString(),
                TotalSalary = Convert.ToDouble(reader["TotalSalary"].ToString())
            };
        }
    }
}
