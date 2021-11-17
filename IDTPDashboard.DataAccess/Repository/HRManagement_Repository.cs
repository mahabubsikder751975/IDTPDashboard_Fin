
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
                    var filledPostVacantPostData = new List<FilledPostVacantPost>();
                    var employeeJobStatusData = new List<EmployeeJobStatus>();
                    var employeeQualifcationData = new List<EmployeeQualifcation>();
                    var retirementvsNewEmployeeData = new List<RetirementvsNewEmployee>();
                    var upcommingRetirementCompanyWiseData = new List<UpcommingRetirementCompanyWise>();
                    var foreignTourOrganizationWiseData = new List<ForeignTourOrganizationWise>();
                    var totalEmployeeData = new List<TotalEmployee>();
                    var totalEmployeeUtilityWiseData = new List<TotalEmployeeUtilityWise>();
                    var netSalaryByMonthData = new List<NetSalaryByMonth>();                    

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                filledPostVacantPostData.Add(RTPStatusByFIDataPurser(reader));
                            }                          

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                employeeJobStatusData.Add(TransactionsSettledUnsettledDataPurser(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                employeeQualifcationData.Add(TransactionCountByTypeDataPurser(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                retirementvsNewEmployeeData.Add(NetDebitCapPositionByFIDataPurser(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                upcommingRetirementCompanyWiseData.Add(RegisteredUsersByFIDataPurser(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                foreignTourOrganizationWiseData.Add(TransactionsAmountTodayByFIDataPurser(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalEmployeeData.Add(TotalNumberOfUsersDataPurser(reader));
                            }          

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalEmployeeUtilityWiseData.Add(TransactionsCountTodayByFIDataPurser(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                netSalaryByMonthData.Add(TransactionAmountBySettlementCycleIdDataPurser(reader));
                            }

                            response.FilledPostVacantPostList = filledPostVacantPostData;
                            response.EmployeeJobStatusList = employeeJobStatusData;
                            response.EmployeeQualifcationList = employeeQualifcationData;
                            response.RetirementvsNewEmployeeList = retirementvsNewEmployeeData;
                            response.UpcommingRetirementCompanyWiseList = upcommingRetirementCompanyWiseData;
                            response.ForeignTourOrganizationWiseList = foreignTourOrganizationWiseData;
                            response.TotalEmployeeList = totalEmployeeData;
                            response.TotalEmployeeUtilityWiseList = totalEmployeeUtilityWiseData;
                            response.NetSalaryByMonthList = netSalaryByMonthData;
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

        private NetSalaryByMonth TransactionAmountBySettlementCycleIdDataPurser(SqlDataReader reader)
        {
            return new NetSalaryByMonth()
            {
                SalaryDate = reader["SettleCycleId"].ToString(),
                TotalSalary = Convert.ToDouble(reader["TotalTransactionAmount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),

            };
        }       

        private FilledPostVacantPost RTPStatusByFIDataPurser(SqlDataReader reader)
        {
            return new FilledPostVacantPost()
            {
                PostType = reader["FIVID"].ToString(),
                SanctionPosts = Convert.ToInt32(reader["Accepted"].ToString()),
                FilledPosts = Convert.ToInt32(reader["Rejected"].ToString()),
                VacantPosts = Convert.ToInt32(reader["Pending"].ToString())
            };
        }

        private EmployeeJobStatus TransactionsSettledUnsettledDataPurser(SqlDataReader reader)
        {
            return new EmployeeJobStatus()
            {
                JobStatus    = reader["Transaction_Status_Code"].ToString(),
                TotalEmployee = Convert.ToInt32(reader["Total_Count"].ToString())
            };
        }

        private EmployeeQualifcation TransactionCountByTypeDataPurser(SqlDataReader reader)
        {
            return new EmployeeQualifcation()
            {
                Qualification = reader["TransactionType"].ToString(),
                Total = Convert.ToInt32(reader["Total_Count"].ToString())
            };
        }

        private RetirementvsNewEmployee NetDebitCapPositionByFIDataPurser(SqlDataReader reader)
        {
            return new RetirementvsNewEmployee()
            {
                Organization = reader["FIVID"].ToString(),
                Retirement = Convert.ToInt64(reader["NetDebitPosition"].ToString()),
                NewEmployee = Convert.ToInt64(reader["NetDebitCap"].ToString())
            };
        }

        private UpcommingRetirementCompanyWise RegisteredUsersByFIDataPurser(SqlDataReader reader)
        {
            return new UpcommingRetirementCompanyWise()
            {
                Organization = reader["FIVID"].ToString(),
                Employee = Convert.ToInt64(reader["User_Count"].ToString())
            };
        }

        private ForeignTourOrganizationWise TransactionsAmountTodayByFIDataPurser(SqlDataReader reader)
        {
            return new ForeignTourOrganizationWise()
            {
                Organization = reader["FIVID"].ToString(),
                TourCount = Convert.ToInt64(reader["TotalAmount"].ToString())
            };
        }


        private TotalEmployee TotalNumberOfUsersDataPurser(SqlDataReader reader)
        {
            return new TotalEmployee()
            {
                totalemployee = Convert.ToInt64(reader["totaluser"].ToString())
            };
        }


        private TotalEmployeeUtilityWise TransactionsCountTodayByFIDataPurser(SqlDataReader reader)
        {
            return new TotalEmployeeUtilityWise()
            {
                Organization = reader["FIVID"].ToString(),
                totalemployee = Convert.ToInt64(reader["TransactionCount"].ToString())
            };
        }

    }
}
