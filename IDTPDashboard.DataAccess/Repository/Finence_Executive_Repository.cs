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
    public class Finence_Executive_Repository : IFinence_Executive_Repository
    {
        private readonly string _connectionString;
        public Finence_Executive_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }
        public async Task<Finence_Executive_Entity> GetAllReports(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Finence_Executive_Dashboard", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Organization", Organization));

                    var response = new Finence_Executive_Entity();
                    var FinanceETotalAssetsData = new List<FinanceETotalAssets>();
                    var FinanceETotalLiabilitiesData = new List<FinanceETotalLiabilities>();
                    var FinanceETotalEquityData = new List<FinanceETotalEquity>();
                    var FinanceETotalDebtData = new List<FinanceETotalDebt>();
                    var FinanceENetMarginData = new List<FinanceENetMargin>();
                    var FinanceETotalTaxData = new List<FinanceETotalTax>();
                    var FinanceEProfitablyRatioData = new List<FinanceEProfitablyRatio>();
                    var FinanceECurrentRatioData = new List<FinanceECurrentRatio>();
                    var FinanceEQuickRatioData = new List<FinanceEQuickRatio>();

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                FinanceETotalAssetsData.Add(FinanceETotalAssetsMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                FinanceETotalLiabilitiesData.Add(FinanceETotalLiabilitiesMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                FinanceETotalEquityData.Add(FinanceETotalEquityMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                FinanceETotalDebtData.Add(FinanceETotalDebtMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                FinanceENetMarginData.Add(FinanceENetMarginMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                FinanceETotalTaxData.Add(FinanceETotalTaxMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                FinanceEProfitablyRatioData.Add(FinanceEProfitablyRatioMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                FinanceECurrentRatioData.Add(FinanceECurrentRatioMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                FinanceEQuickRatioData.Add(FinanceEQuickRatioMapToValue(reader));
                            }

                            response.FinanceETotalAssetsList = FinanceETotalAssetsData;
                            response.FinanceETotalLiabilitiesList = FinanceETotalLiabilitiesData;
                            response.FinanceETotalEquityList = FinanceETotalEquityData;
                            response.FinanceETotalDebtList = FinanceETotalDebtData;
                            response.FinanceENetMarginList = FinanceENetMarginData;
                            response.FinanceETotalTaxList = FinanceETotalTaxData;
                            response.FinanceEProfitablyRatioList = FinanceEProfitablyRatioData;
                            response.FinanceECurrentRatioList = FinanceECurrentRatioData;
                            response.FinanceEQuickRatioList = FinanceEQuickRatioData;
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
        private FinanceETotalAssets FinanceETotalAssetsMapToValue(SqlDataReader reader)
        {
            return new FinanceETotalAssets()
            {
                Year = reader["Year"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),
                Organization = reader["Organization"].ToString()
            };
        }
        private FinanceETotalLiabilities FinanceETotalLiabilitiesMapToValue(SqlDataReader reader)
        {
            return new FinanceETotalLiabilities()
            {
                Year = reader["Year"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),
                Organization = reader["Organization"].ToString()
            };
        }
        private FinanceETotalEquity FinanceETotalEquityMapToValue(SqlDataReader reader)
        {
            return new FinanceETotalEquity()
            {
                Year = reader["Year"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),
                Organization = reader["Organization"].ToString()
            };
        }
        private FinanceETotalDebt FinanceETotalDebtMapToValue(SqlDataReader reader)
        {
            return new FinanceETotalDebt()
            {
                Year = reader["Year"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),
                Organization = reader["Organization"].ToString()
            };
        }
        private FinanceENetMargin FinanceENetMarginMapToValue(SqlDataReader reader)
        {
            return new FinanceENetMargin()
            {
                Year = reader["Year"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),
                Organization = reader["Organization"].ToString()
            };
        }
        private FinanceETotalTax FinanceETotalTaxMapToValue(SqlDataReader reader)
        {
            return new FinanceETotalTax()
            {
                Year = reader["Year"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),
                Organization = reader["Organization"].ToString()
            };
        }
        private FinanceEProfitablyRatio FinanceEProfitablyRatioMapToValue(SqlDataReader reader)
        {
            return new FinanceEProfitablyRatio()
            {
                Year = reader["Year"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),
                Organization = reader["Organization"].ToString()
            };
        }
        private FinanceECurrentRatio FinanceECurrentRatioMapToValue(SqlDataReader reader)
        {
            return new FinanceECurrentRatio()
            {
                Year = reader["Year"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),
                Organization = reader["Organization"].ToString()
            };
        }
        private FinanceEQuickRatio FinanceEQuickRatioMapToValue(SqlDataReader reader)
        {
            return new FinanceEQuickRatio()
            {
                Year = reader["Year"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),
                Organization = reader["Organization"].ToString()
            };
        }
    }
}
