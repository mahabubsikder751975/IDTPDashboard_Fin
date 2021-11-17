
using IDTPDashboard.DataAccess.Interface;
using IDTPDashboard.DomainModel.Common;
using IDTPDashboard.DomainModel.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Repositoty 
{
    public class IDTPDashboard_Repository : IIDTPDashboard_Repository
    {
        private readonly string _connectionString;
        public IDTPDashboard_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }

        public async Task<HRManagement_Entity> GetAllReports(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("IDTP_Dashboard_Data", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Organization", Organization));

                    var response = new HRManagement_Entity();
                    var rtpStatusByFIData = new List<RTPStatusByFI>();
                    var transactionsSettledUnsettledData = new List<TransactionsSettledUnsettled>();
                    var transactionCountByTypeData = new List<TransactionCountByType>();
                    var netDebitCapPositionByFIData = new List<NetDebitCapPositionByFI>();
                    var registeredUsersByFIData = new List<RegisteredUsersByFI>();
                    var transactionsAmountTodayByFIData = new List<TransactionsAmountTodayByFI>();
                    var totalNumberOfUsersData = new List<TotalNumberOfUsers>();
                    var transactionsCountTodayByFIData = new List<TransactionsCountTodayByFI>();
                    var transactionAmountBySettlementCycleIdData = new List<TransactionAmountBySettlementCycleId>();                    

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                rtpStatusByFIData.Add(RTPStatusByFIDataPurser(reader));
                            }                          

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                transactionsSettledUnsettledData.Add(TransactionsSettledUnsettledDataPurser(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                transactionCountByTypeData.Add(TransactionCountByTypeDataPurser(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                netDebitCapPositionByFIData.Add(NetDebitCapPositionByFIDataPurser(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                registeredUsersByFIData.Add(RegisteredUsersByFIDataPurser(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                transactionsAmountTodayByFIData.Add(TransactionsAmountTodayByFIDataPurser(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalNumberOfUsersData.Add(TotalNumberOfUsersDataPurser(reader));
                            }          

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                transactionsCountTodayByFIData.Add(TransactionsCountTodayByFIDataPurser(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                transactionAmountBySettlementCycleIdData.Add(TransactionAmountBySettlementCycleIdDataPurser(reader));
                            }

                            response.RTPStatusByFIList = rtpStatusByFIData;
                            response.TransactionsSettledUnsettledList = transactionsSettledUnsettledData;
                            response.TransactionCountByTypeList = transactionCountByTypeData;
                            response.NetDebitCapPositionByFIList = netDebitCapPositionByFIData;
                            response.RegisteredUsersByFIList = registeredUsersByFIData;
                            response.TransactionsAmountTodayByFIList = transactionsAmountTodayByFIData;
                            response.TotalNumberOfUsersList = totalNumberOfUsersData;
                            response.TransactionsCountTodayByFIList = transactionsCountTodayByFIData;
                            response.TransactionAmountBySettlementCycleIdList = transactionAmountBySettlementCycleIdData;
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

        private TransactionAmountBySettlementCycleId TransactionAmountBySettlementCycleIdDataPurser(SqlDataReader reader)
        {
            return new TransactionAmountBySettlementCycleId()
            {
                SalaryDate = reader["SettleCycleId"].ToString(),
                TotalSalary = Convert.ToDouble(reader["TotalTransactionAmount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),

            };
        }       

        private RTPStatusByFI RTPStatusByFIDataPurser(SqlDataReader reader)
        {
            return new RTPStatusByFI()
            {
                PostType = reader["FIVID"].ToString(),
                SanctionPosts = Convert.ToInt32(reader["Accepted"].ToString()),
                FilledPosts = Convert.ToInt32(reader["Rejected"].ToString()),
                VacantPosts = Convert.ToInt32(reader["Pending"].ToString())
            };
        }

        private TransactionsSettledUnsettled TransactionsSettledUnsettledDataPurser(SqlDataReader reader)
        {
            return new TransactionsSettledUnsettled()
            {
                JobStatus    = reader["Transaction_Status_Code"].ToString(),
                TotalNumberOfUsers = Convert.ToInt32(reader["Total_Count"].ToString())
            };
        }

        private TransactionCountByType TransactionCountByTypeDataPurser(SqlDataReader reader)
        {
            return new TransactionCountByType()
            {
                Qualification = reader["TransactionType"].ToString(),
                Total = Convert.ToInt32(reader["Total_Count"].ToString())
            };
        }

        private NetDebitCapPositionByFI NetDebitCapPositionByFIDataPurser(SqlDataReader reader)
        {
            return new NetDebitCapPositionByFI()
            {
                Organization = reader["FIVID"].ToString(),
                Retirement = Convert.ToInt64(reader["NetDebitPosition"].ToString()),
                NewEmployee = Convert.ToInt64(reader["NetDebitCap"].ToString())
            };
        }

        private RegisteredUsersByFI RegisteredUsersByFIDataPurser(SqlDataReader reader)
        {
            return new RegisteredUsersByFI()
            {
                Organization = reader["FIVID"].ToString(),
                Employee = Convert.ToInt64(reader["User_Count"].ToString())
            };
        }

        private TransactionsAmountTodayByFI TransactionsAmountTodayByFIDataPurser(SqlDataReader reader)
        {
            return new TransactionsAmountTodayByFI()
            {
                Organization = reader["FIVID"].ToString(),
                TourCount = Convert.ToInt64(reader["TotalAmount"].ToString())
            };
        }


        private TotalNumberOfUsers TotalNumberOfUsersDataPurser(SqlDataReader reader)
        {
            return new TotalNumberOfUsers()
            {
                totalemployee = Convert.ToInt64(reader["totaluser"].ToString())
            };
        }


        private TransactionsCountTodayByFI TransactionsCountTodayByFIDataPurser(SqlDataReader reader)
        {
            return new TransactionsCountTodayByFI()
            {
                Organization = reader["FIVID"].ToString(),
                totalemployee = Convert.ToInt64(reader["TransactionCount"].ToString())
            };
        }

    }
}
