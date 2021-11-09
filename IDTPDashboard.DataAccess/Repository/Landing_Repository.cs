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
    public class Landing_Repository : ILanding_Repository
    {
        private readonly string _connectionString;
        public Landing_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }
        public async Task<Landing_Entity> GetAllReports()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Landing_Dashboard", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@Organization", Organization));

                    var response = new Landing_Entity();
                    var totalPowerPlants = new List<TotalPowerPlant>();
                    var totalInstalledCapacityMWs = new List<TotalInstalledCapacityMW>();
                    var totalEmployeeByStatus = new List<TotalEmployeeByStatus>();
                    var totalExpenseRevenue = new List<TotalExpenceRevenue>();
                    var appUtilizedUnutilized = new List<APPUtilizedUnutilized>();
                    var accReceivableAndPayable = new List<AccReceivableAndPayable>();
                    var financialPosition = new List<FinancialPosition>();

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                totalPowerPlants.Add(TotalPowerPlantMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalInstalledCapacityMWs.Add(TotalInstalledCapacityMWMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalEmployeeByStatus.Add(TotalEmployeeByStatusMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalExpenseRevenue.Add(TotalExpenceRevenueMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                appUtilizedUnutilized.Add(APPUtilizedUnutilizedMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                accReceivableAndPayable.Add(AccReceivableAndPayableMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                financialPosition.Add(FinancialPositionMapToValue(reader));
                            }

                            response.TotalPowerPlantList = totalPowerPlants;
                            response.TotalInstalledCapacityMWList = totalInstalledCapacityMWs;
                            response.appUtilizedUnutilizedList = appUtilizedUnutilized;
                            response.TotalEmployeeByStatusesList = totalEmployeeByStatus;
                            response.TotalExpenceRevenuesList = totalExpenseRevenue;
                            response.AccReceivableAndPayableList = accReceivableAndPayable;
                            response.FinancialPositionList = financialPosition;
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
        private TotalPowerPlant TotalPowerPlantMapToValue(SqlDataReader reader)
        {
            return new TotalPowerPlant()
            {
                Type = reader["Type"].ToString(),
                Number = Convert.ToInt32(reader["Number"].ToString())
            };
        }
        private TotalInstalledCapacityMW TotalInstalledCapacityMWMapToValue(SqlDataReader reader)
        {
            return new TotalInstalledCapacityMW()
            {
                Type = reader["Type"].ToString(),
                InstalledCapacityMW = Convert.ToInt64(reader["InstalledCapacityMW"].ToString()),                
            };
        }
        private TotalEmployeeByStatus TotalEmployeeByStatusMapToValue(SqlDataReader reader)
        {
            return new TotalEmployeeByStatus()
            {
                Type = reader["Type"].ToString(),
                EmployeeCount = Convert.ToInt64(reader["EmployeeCount"].ToString()),
            };
        }
        private TotalExpenceRevenue TotalExpenceRevenueMapToValue(SqlDataReader reader)
        {
            return new TotalExpenceRevenue()
            {
                Type = reader["Type"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
            };
        }
        private APPUtilizedUnutilized APPUtilizedUnutilizedMapToValue(SqlDataReader reader)
        {
            return new APPUtilizedUnutilized()
            {
                Type = reader["Type"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
            };
        }
        private AccReceivableAndPayable AccReceivableAndPayableMapToValue(SqlDataReader reader)
        {
            return new AccReceivableAndPayable()
            {
                Type = reader["Type"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
            };
        }
        private FinancialPosition FinancialPositionMapToValue(SqlDataReader reader)
        {
            return new FinancialPosition()
            {
                AccountCategory = reader["AccountCategory"].ToString(),
                Value = Convert.ToInt64(reader["Value"].ToString()),
            };
        }
    }
}
