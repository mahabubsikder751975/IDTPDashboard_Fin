
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
    public class HRManagement_Repository : IHRManagement_Repository
    {
        private readonly string _connectionString;
        public HRManagement_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }

        public async Task<HRManagement_Entity> GetAllReports(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("IDTP_Dashboard_Part1", sql))
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
                                filledPostVacantPostData.Add(FilledPostVacantPostMapToValue(reader));
                            }                          

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                employeeJobStatusData.Add(EmployeeJobStatusMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                employeeQualifcationData.Add(EmployeeQualifcationMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                retirementvsNewEmployeeData.Add(RetirementvsNewEmployeeMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                upcommingRetirementCompanyWiseData.Add(UpcommingRetirementCompanyWiseMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                foreignTourOrganizationWiseData.Add(ForeignTourOrganizationWiseMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalEmployeeData.Add(TotalEmployeeMapToValue(reader));
                            }          

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalEmployeeUtilityWiseData.Add(TotalEmployeeUtilityWiseMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                netSalaryByMonthData.Add(NetSalaryByMonthMapToValue(reader));
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

        private NetSalaryByMonth NetSalaryByMonthMapToValue(SqlDataReader reader)
        {
            return new NetSalaryByMonth()
            {
                SalaryDate = reader["SalaryDate"].ToString(),
                TotalSalary = Convert.ToDouble(reader["TotalSalary"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString()),

            };
        }

        // private EmployeeAttendance EmployeeAttendanceMapToValue(SqlDataReader reader)
        // {
        //     return new EmployeeAttendance()
        //     {
        //         PostType = reader["Post Type"].ToString(),
        //         Present = Convert.ToInt32(reader["Present"].ToString()),
        //         Absent = Convert.ToInt32(reader["Absent"].ToString()),
        //         SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
        //     };
        // }

        // private EmployeeOnLeave EmployeeOnLeaveMapToValue(SqlDataReader reader)
        // {
        //     return new EmployeeOnLeave()
        //     {
        //         OfficersOnLeave = Convert.ToInt32(reader["OfficersOnLeave"].ToString()),
        //         StaffOnLeave = Convert.ToInt32(reader["StaffOnLeave"].ToString()),
        //         PBSName = reader["PBSName"].ToString(),
        //         OfficeName = reader["OfficeName"].ToString(),
        //         SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
        //     };
        // }

        private FilledPostVacantPost FilledPostVacantPostMapToValue(SqlDataReader reader)
        {
            return new FilledPostVacantPost()
            {
                PostType = reader["Post Type"].ToString(),
                SanctionPosts = Convert.ToInt32(reader["Sanction Posts"].ToString()),
                FilledPosts = Convert.ToInt32(reader["Filled Posts"].ToString()),
                VacantPosts = Convert.ToInt32(reader["Vacant Posts"].ToString())
            };
        }
        // private UpcommingRetirement UpcommingRetirementMapToValue(SqlDataReader reader)
        // {
        //     return new UpcommingRetirement()
        //     {
        //         MonthName = reader["MonthName"].ToString(),
        //         Count = Convert.ToInt32(reader["Count_"].ToString()),
        //         SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
        //     };
        // }

        // private EmployeePerformance EmployeePerformanceMapToValue(SqlDataReader reader)
        // {
        //     return new EmployeePerformance()
        //     {
        //         ScoreRange = reader["Score Range"].ToString(),
        //         NoOfOfficers = Convert.ToInt32(reader["No. of Officers"].ToString()),
        //         SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
        //     };
        // }

        private EmployeeJobStatus EmployeeJobStatusMapToValue(SqlDataReader reader)
        {
            return new EmployeeJobStatus()
            {
                JobStatus    = reader["Employee_Job_Status_Code"].ToString(),
                TotalEmployee = Convert.ToInt32(reader["Sum_Total_Employee"].ToString())
            };
        }

        private EmployeeQualifcation EmployeeQualifcationMapToValue(SqlDataReader reader)
        {
            return new EmployeeQualifcation()
            {
                Qualification = reader["Qualification"].ToString(),
                Total = Convert.ToInt32(reader["Total"].ToString())
            };
        }

        private RetirementvsNewEmployee RetirementvsNewEmployeeMapToValue(SqlDataReader reader)
        {
            return new RetirementvsNewEmployee()
            {
                Organization = reader["Organization"].ToString(),
                Retirement = Convert.ToInt64(reader["retirement"].ToString()),
                NewEmployee = Convert.ToInt64(reader["newemployee"].ToString())
            };
        }

        private UpcommingRetirementCompanyWise UpcommingRetirementCompanyWiseMapToValue(SqlDataReader reader)
        {
            return new UpcommingRetirementCompanyWise()
            {
                Organization = reader["Organization"].ToString(),
                Employee = Convert.ToInt64(reader["Count_"].ToString())
            };
        }

        private ForeignTourOrganizationWise ForeignTourOrganizationWiseMapToValue(SqlDataReader reader)
        {
            return new ForeignTourOrganizationWise()
            {
                Organization = reader["Organization"].ToString(),
                TourCount = Convert.ToInt64(reader["TotalTour"].ToString())
            };
        }

        // private FilledPostVacantPostUtilityWise FilledPostVacantPostUtilityWiseMapToValue(SqlDataReader reader)
        // {
        //     return new FilledPostVacantPostUtilityWise()
        //     {
        //         Organization = reader["Organization"].ToString(),
        //         SanctionPosts = Convert.ToInt32(reader["Sanction Posts"].ToString()),
        //         FilledPosts = Convert.ToInt32(reader["Filled Posts"].ToString()),
        //         VacantPosts = Convert.ToInt32(reader["Vacant Posts"].ToString())
        //     };
        // }

        private TotalEmployee TotalEmployeeMapToValue(SqlDataReader reader)
        {
            return new TotalEmployee()
            {
                totalemployee = Convert.ToInt64(reader["totalemployee"].ToString())
            };
        }

        // private ForeignTourCategoryWise ForeignTourCategoryWiseMapToValue(SqlDataReader reader)
        // {
        //     return new ForeignTourCategoryWise()
        //     {
        //         TourCategory = reader["TourCategory"].ToString(),
        //         TotalTour = Convert.ToInt32(reader["TotalTour"].ToString())
        //     };
        // }

        // private ForeignTourPurposeWiseOfficial ForeignTourPurposeWiseOfficialMapToValue(SqlDataReader reader)
        // {
        //     return new ForeignTourPurposeWiseOfficial()
        //     {
        //         TourPurpose = reader["TourPurpose"].ToString(),
        //         TotalTour = Convert.ToInt32(reader["TotalTour"].ToString())
        //     };
        // }

        // private ForeignTourPurposeWisePersonal ForeignTourPurposeWisePersonalMapToValue(SqlDataReader reader)
        // {
        //     return new ForeignTourPurposeWisePersonal()
        //     {
        //         TourPurpose = reader["TourPurpose"].ToString(),
        //         TotalTour = Convert.ToInt32(reader["TotalTour"].ToString())
        //     };
        // }

        private TotalEmployeeUtilityWise TotalEmployeeUtilityWiseMapToValue(SqlDataReader reader)
        {
            return new TotalEmployeeUtilityWise()
            {
                Organization = reader["Organization"].ToString(),
                totalemployee = Convert.ToInt64(reader["totalemployee"].ToString())
            };
        }

        // private UtilitywiseLastFiscalYearSalary UtilitywiseLastFiscalYearSalaryMapToValue(SqlDataReader reader)
        // {
        //     return new UtilitywiseLastFiscalYearSalary()
        //     {
        //         Organization = reader["Organization"].ToString(),
        //         TotalSalary = Convert.ToInt64(reader["TotalSalary"].ToString())
        //     };
        // }

        // private OrgPostWiseUpcommingRetirment OrgPostWiseUpcommingRetirmentMapToValue(SqlDataReader reader)
        // {
        //     return new OrgPostWiseUpcommingRetirment()
        //     {
        //         PostType = reader["PostType"].ToString(),
        //         EmpQuantity = Convert.ToInt32(reader["EmpQuantity"].ToString())
        //     };
        // }

        // //Other SP 
        
        // public async Task<PagedList<DesignationWiseEmpCount>> GetDesignationWiseEmployeeCount(string org, string postType, string filter, int offset, int pageSize)
        // {
        //     using (SqlConnection sql = new SqlConnection(_connectionString))
        //     {
        //         int totalRecord;
        //         using (SqlCommand cmd = new SqlCommand("usp_GetDesignationWiseEmpCount", sql))
        //         {
        //             cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //             cmd.Parameters.Add(new SqlParameter("@organization", org));
        //             cmd.Parameters.Add(new SqlParameter("@postType", postType));
        //             cmd.Parameters.Add(new SqlParameter("@offset", offset));
        //             cmd.Parameters.Add(new SqlParameter("@pageSize", pageSize));
        //             cmd.Parameters.Add(new SqlParameter("@sort", "Designation"));
        //             cmd.Parameters.Add(new SqlParameter("@filter", filter));
        //             SqlParameter outputParam = cmd.Parameters.Add("@totalrow", SqlDbType.Int);
        //             outputParam.Direction = ParameterDirection.Output;

        //             var designationWiseEmpCountData = new List<DesignationWiseEmpCount>();

        //             await sql.OpenAsync();

        //             try
        //             {
        //                 using (var reader = await cmd.ExecuteReaderAsync())
        //                 {
        //                     while (await reader.ReadAsync())
        //                     {
        //                         designationWiseEmpCountData.Add(DesignationWiseEmpCountMapToValue(reader));
        //                     }

        //                 }
        //                 totalRecord = Convert.ToInt32(outputParam.Value);

        //             }
        //             catch (Exception ex)
        //             {

        //                 throw;
        //             }

        //             return new PagedList<DesignationWiseEmpCount>(designationWiseEmpCountData, totalRecord, offset, pageSize);
        //         }
        //     }
        // }

        // private DesignationWiseEmpCount DesignationWiseEmpCountMapToValue(SqlDataReader reader)
        // {
        //     return new DesignationWiseEmpCount()
        //     {
        //         Organization = reader["Organization"].ToString(),
        //         Designation = reader["Designation"].ToString(),
        //         PostType = reader["PostType"].ToString(),
        //         EmpQuantity = Convert.ToInt32(reader["EmpQuantity"].ToString())
        //     };
        // }

        // //Other SP
        // public async Task<List<OrgPostWiseEmp>> GetPostWiseEmploymentStatus()
        // {
        //     using (SqlConnection sql = new SqlConnection(_connectionString))
        //     {
        //         using (SqlCommand cmd = new SqlCommand("usp_GetDesisgnationWiseEmploymentStatus", sql))
        //         {
        //             cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //             var orgPostWiseEmpData = new List<OrgPostWiseEmp>();

        //             await sql.OpenAsync();

        //             try
        //             {
        //                 using (var reader = await cmd.ExecuteReaderAsync())
        //                 {
        //                     while (await reader.ReadAsync())
        //                     {
        //                         orgPostWiseEmpData.Add(OrgPostWiseEmpMapToValue(reader));
        //                     }

        //                 }

        //             }
        //             catch (Exception ex)
        //             {

        //                 throw;
        //             }

        //             return orgPostWiseEmpData;
        //         }
        //     }
        // }

        // private OrgPostWiseEmp OrgPostWiseEmpMapToValue(SqlDataReader reader)
        // {
        //     return new OrgPostWiseEmp()
        //     {
        //         Organization = reader["Organization"].ToString(),
        //         PostType = reader["PostType"].ToString(),
        //         SanctionPost = Convert.ToInt32(reader["SanctionPost"].ToString()),
        //         FilledPost = Convert.ToInt32(reader["FilledPost"].ToString()),
        //         VacantPost = Convert.ToInt32(reader["VacantPost"].ToString())
        //     };
        // }

        // //Other SP
        // public async Task<List<OrgWiseEmpByJobStatus>> GetOrgWiseEmpByJobStatus(string jobStatus)
        // {
        //     using (SqlConnection sql = new SqlConnection(_connectionString))
        //     {
        //         using (SqlCommand cmd = new SqlCommand("usp_GetOrgWiseEmpByJobStatus", sql))
        //         {
        //             cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //             cmd.Parameters.Add(new SqlParameter("@jobStatus", jobStatus));

        //             var orgWiseEmpByJobStatusData = new List<OrgWiseEmpByJobStatus>();

        //             await sql.OpenAsync();

        //             try
        //             {
        //                 using (var reader = await cmd.ExecuteReaderAsync())
        //                 {
        //                     while (await reader.ReadAsync())
        //                     {
        //                         orgWiseEmpByJobStatusData.Add(OrgWiseEmpByJobStatusMapToValue(reader));
        //                     }

        //                 }

        //             }
        //             catch (Exception ex)
        //             {

        //                 throw;
        //             }

        //             return orgWiseEmpByJobStatusData;
        //         }
        //     }
        // }

        // private OrgWiseEmpByJobStatus OrgWiseEmpByJobStatusMapToValue(SqlDataReader reader)
        // {
        //     return new OrgWiseEmpByJobStatus()
        //     {
        //         Organization = reader["Organization"].ToString(),
        //         TotalEmp = Convert.ToInt32(reader["Sum_Total_Employee"].ToString())
        //     };
        // }

        // //Other SP
        // public async Task<List<OrgWiseEmpByQualification>> GetOrgWiseEmpByQualification(string qualificaion)
        // {
        //     using (SqlConnection sql = new SqlConnection(_connectionString))
        //     {
        //         using (SqlCommand cmd = new SqlCommand("usp_GetOrgWiseEmpByQualification", sql))
        //         {
        //             cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //             cmd.Parameters.Add(new SqlParameter("@qualification", qualificaion));

        //             var orgWiseEmpByQualificationData = new List<OrgWiseEmpByQualification>();

        //             await sql.OpenAsync();

        //             try
        //             {
        //                 using (var reader = await cmd.ExecuteReaderAsync())
        //                 {
        //                     while (await reader.ReadAsync())
        //                     {
        //                         orgWiseEmpByQualificationData.Add(OrgWiseEmpByQualificationMapToValue(reader));
        //                     }

        //                 }

        //             }
        //             catch (Exception ex)
        //             {

        //                 throw;
        //             }

        //             return orgWiseEmpByQualificationData;
        //         }
        //     }
        // }

        // private OrgWiseEmpByQualification OrgWiseEmpByQualificationMapToValue(SqlDataReader reader)
        // {
        //     return new OrgWiseEmpByQualification()
        //     {
        //         Organization = reader["Organization"].ToString(),
        //         Total = Convert.ToInt32(reader["Total"].ToString())
        //     };
        // }

        // //Other SP
        // public async Task<List<OrgWiseRetirementvsNewEmployee>> GetOrgWiseRetirementvsNewEmployee(string organization)
        // {
        //     using (SqlConnection sql = new SqlConnection(_connectionString))
        //     {
        //         using (SqlCommand cmd = new SqlCommand("usp_GetOrgWiseRetirementvsNewEmployee", sql))
        //         {
        //             cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //             cmd.Parameters.Add(new SqlParameter("@organization", organization));

        //             var orgWiseRetirementvsNewEmployeeData = new List<OrgWiseRetirementvsNewEmployee>();

        //             await sql.OpenAsync();

        //             try
        //             {
        //                 using (var reader = await cmd.ExecuteReaderAsync())
        //                 {
        //                     while (await reader.ReadAsync())
        //                     {
        //                         orgWiseRetirementvsNewEmployeeData.Add(OrgWiseRetirementvsNewEmployeeMapToValue(reader));
        //                     }

        //                 }

        //             }
        //             catch (Exception ex)
        //             {

        //                 throw;
        //             }

        //             return orgWiseRetirementvsNewEmployeeData;
        //         }
        //     }
        // }

        // private OrgWiseRetirementvsNewEmployee OrgWiseRetirementvsNewEmployeeMapToValue(SqlDataReader reader)
        // {
        //     return new OrgWiseRetirementvsNewEmployee()
        //     {
        //         PostType = reader["PostType"].ToString(),
        //         NewEmployee = Convert.ToInt32(reader["NewEmployee"].ToString()),
        //         Retirement = Convert.ToInt32(reader["Retirement"].ToString())

        //     };
        // }

        // //Other SP
        // public async Task<List<DesignationWiseEmpByJobTypeAndOrg>> GetDesignationWiseEmpByJobTypeAndOrg(string org,string jobStatus)
        // {
        //     using (SqlConnection sql = new SqlConnection(_connectionString))
        //     {
        //         using (SqlCommand cmd = new SqlCommand("usp_GetDesignationWiseEmpByJobTypeAndOrg", sql))
        //         {
        //             cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //             cmd.Parameters.Add(new SqlParameter("@org", org));
        //             cmd.Parameters.Add(new SqlParameter("@jobStatus", jobStatus));

        //             var designationWiseEmpByJobTypeAndOrgData = new List<DesignationWiseEmpByJobTypeAndOrg>();

        //             await sql.OpenAsync();

        //             try
        //             {
        //                 using (var reader = await cmd.ExecuteReaderAsync())
        //                 {
        //                     while (await reader.ReadAsync())
        //                     {
        //                         designationWiseEmpByJobTypeAndOrgData.Add(DesignationWiseEmpByJobTypeAndOrgMapToValue(reader));
        //                     }

        //                 }

        //             }
        //             catch (Exception ex)
        //             {

        //                 throw;
        //             }

        //             return designationWiseEmpByJobTypeAndOrgData;
        //         }
        //     }
        // }

        // private DesignationWiseEmpByJobTypeAndOrg DesignationWiseEmpByJobTypeAndOrgMapToValue(SqlDataReader reader)
        // {
        //     return new DesignationWiseEmpByJobTypeAndOrg()
        //     {
        //         Designation = reader["Designation"].ToString(),
        //         DesignationOrder = Convert.ToInt32(reader["DesignationOrder"].ToString()),
        //         TotalEmp = Convert.ToInt32(reader["Sum_Total_Employee"].ToString())
        //     };
        // }

        // //Other SP
        // public async Task<List<DesignationWiseEmpByQualificationAndOrg>> GetDesignationWiseEmpByQualificationAndOrg(string org, string qualification)
        // {
        //     using (SqlConnection sql = new SqlConnection(_connectionString))
        //     {
        //         using (SqlCommand cmd = new SqlCommand("usp_GetDesignationWiseEmpByQualificationAndOrg", sql))
        //         {
        //             cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //             cmd.Parameters.Add(new SqlParameter("@org", org));
        //             cmd.Parameters.Add(new SqlParameter("@qualification", qualification));

        //             var designationWiseEmpByQualificationAndOrgData = new List<DesignationWiseEmpByQualificationAndOrg>();

        //             await sql.OpenAsync();

        //             try
        //             {
        //                 using (var reader = await cmd.ExecuteReaderAsync())
        //                 {
        //                     while (await reader.ReadAsync())
        //                     {
        //                         designationWiseEmpByQualificationAndOrgData.Add(DesignationWiseEmpByQualificationAndOrgMapToValue(reader));
        //                     }

        //                 }

        //             }
        //             catch (Exception ex)
        //             {

        //                 throw;
        //             }

        //             return designationWiseEmpByQualificationAndOrgData;
        //         }
        //     }
        // }

        // private DesignationWiseEmpByQualificationAndOrg DesignationWiseEmpByQualificationAndOrgMapToValue(SqlDataReader reader)
        // {
        //     return new DesignationWiseEmpByQualificationAndOrg()
        //     {
        //         Designation = reader["Designation"].ToString(),
        //         DesignationOrder = Convert.ToInt32(reader["DesignationOrder"].ToString()),
        //         TotalEmp = Convert.ToInt64(reader["Total"].ToString())
        //     };
        // }
    }
}
