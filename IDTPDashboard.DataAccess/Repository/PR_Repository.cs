
using IDTPDashboard.DataAccess.Interface;
using IDTPDashboard.DomainModel.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Repositoty 
{
    public class PR_Repository : IPR_Repository
    {
        private readonly string _connectionString;
        public PR_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }

        public async Task<PR_Entity> GetAllReports(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PR_Dashboard", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Organization", Organization));

                    var response = new PR_Entity();
                    var procurementTrendData = new List<ProcurementTrend>();
                    var topProcuredItemsbyOfficeData = new List<TopProcuredItemsbyOffice>();
                    var procurementValuebyOfficeData = new List<ProcurementValuebyOffice>();
                    var procurementTypebyOfficeData = new List<ProcurementTypebyOffice>();
                    var procurementStatusData = new List<ProcurementStatus>();
                    var appUtilizationData = new List<AppUtilization>();
                    var requisitionStatusData = new List<RequisitionStatus>();

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                procurementTrendData.Add(ProcurementTrendMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                topProcuredItemsbyOfficeData.Add(TopProcuredItemsbyOfficeMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                procurementValuebyOfficeData.Add(ProcurementValuebyOfficeMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                procurementTypebyOfficeData.Add(ProcurementTypebyOfficeMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                procurementStatusData.Add(ProcurementStatusMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                appUtilizationData.Add(AppUtilizationMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                requisitionStatusData.Add(RequisitionStatusMapToValue(reader));
                            }

                            

                            response.ProcurementTrendList = procurementTrendData;
                            response.TopProcuredItemsbyOfficeList = topProcuredItemsbyOfficeData;
                            response.ProcurementValuebyOfficeList = procurementValuebyOfficeData;
                            response.ProcurementTypebyOfficeList = procurementTypebyOfficeData;
                            response.ProcurementStatusList = procurementStatusData;
                            response.AppUtilizationList = appUtilizationData;
                            response.RequisitionStatusList = requisitionStatusData;

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

        private ProcurementTrend ProcurementTrendMapToValue(SqlDataReader reader)
        {
            return new ProcurementTrend()
            {
                Organization = reader["Organization"].ToString(),
                Year = reader["Year"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private TopProcuredItemsbyOffice TopProcuredItemsbyOfficeMapToValue(SqlDataReader reader)
        {
            return new TopProcuredItemsbyOffice()
            {
                Organization = reader["Organization"].ToString(),
                OfficeName = reader["OfficeName"].ToString(),
                CopperCable11KV = Convert.ToInt64(reader["11 KV 3-core 300sq mm XLPE U/G Copper Cable"].ToString()),
                CopperCable33KV = Convert.ToInt64(reader["33 KV 1-core 500sq.mm XLPE U/G Copper Cable"].ToString()),
                MeterSeal = Convert.ToInt64(reader["Twist-tight Meter Seal"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private ProcurementValuebyOffice ProcurementValuebyOfficeMapToValue(SqlDataReader reader)
        {
            return new ProcurementValuebyOffice()
            {
                Organization = reader["Organization"].ToString(),
                OfficeName = reader["OfficeName"].ToString(),
                Amount = Convert.ToInt64(reader["Amount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private ProcurementTypebyOffice ProcurementTypebyOfficeMapToValue(SqlDataReader reader)
        {
            return new ProcurementTypebyOffice()
            {
                Organization = reader["Organization"].ToString(),
                OfficeName = reader["OfficeName"].ToString(),
                eGP = Convert.ToInt64(reader["e-GP"].ToString()),
                OTM = Convert.ToInt64(reader["OTM/LTM/RFG"].ToString()),
                DPM = Convert.ToInt64(reader["DPM"].ToString()),
                SpotQuotation = Convert.ToInt64(reader["Spot Quotation"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private ProcurementStatus ProcurementStatusMapToValue(SqlDataReader reader)
        {
            return new ProcurementStatus()
            {
                Organization = reader["Organization"].ToString(),
                Completed = Convert.ToInt64(reader["Completed"].ToString()),
                OnGoing = Convert.ToInt64(reader["On-Going(In Progress)"].ToString()),
                NotInitiated = Convert.ToInt64(reader["Not Initiated"].ToString()),
            };
        }
        private AppUtilization AppUtilizationMapToValue(SqlDataReader reader)
        {
            return new AppUtilization()
            {
                Organization = reader["Organization"].ToString(),
                Unutilized = Convert.ToInt64(reader["Unutilized"].ToString()),
                Utilized = Convert.ToInt64(reader["Utilized"].ToString())
            };
        }
        private RequisitionStatus RequisitionStatusMapToValue(SqlDataReader reader)
        {
            return new RequisitionStatus()
            {
                Organization = reader["Organization"].ToString(),
                POIssued = Convert.ToInt64(reader["PO Issued"].ToString()),
                POPending = Convert.ToInt64(reader["PO Pending"].ToString())
            };
        }
        
    }
}
