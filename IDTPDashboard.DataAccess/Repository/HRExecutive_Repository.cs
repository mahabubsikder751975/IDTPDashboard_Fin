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
    public class HRExecutive_Repository : IHRExecutive_Repository
    {
        private readonly string _connectionString;
        public HRExecutive_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }
        public async Task<HRExecutive_Entity> GetAllReports(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HRExecutive_Dashboard", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Organization", Organization));

                    var response = new HRExecutive_Entity();
                    var EmployeeAgeRangeData = new List<EmployeeAgeRange>();
                    var EmployeeYearsofServiceData = new List<EmployeeYearsofService>();
                    var YearlyTurnoverData = new List<YearlyTurnover>();
                    var YearlyRecruitmentData = new List<YearlyRecruitment>();
                    var YearlyTerminationData = new List<YearlyTermination>();
                    var YearlyPromotionData = new List<YearlyPromotion>();
                    var EmployeebyCategoryData = new List<EmployeebyCategory>();
                    var MaleFemaleRatioBothData = new List<MaleFemaleRatio>();
                    var MaleFemaleRatioOfficerData = new List<MaleFemaleRatio>();
                    var MaleFemaleRatioStaffData = new List<MaleFemaleRatio>();
                    var EmployeeAgeRangeGenderWiseData = new List<EmployeeAgeRangeGenderWise>();
                    var RetirementvsTerminatedOverallData = new List<RetirementvsTerminatedOverall>();
                    var TechnicalNonTechnicalCadrewiseinformationData = new List<TechnicalNonTechnicalCadrewiseinformation>();

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                EmployeeAgeRangeData.Add(EmployeeAgeRangeMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                EmployeeYearsofServiceData.Add(EmployeeYearsofServiceMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                YearlyTurnoverData.Add(YearlyTurnoverMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                YearlyRecruitmentData.Add(YearlyRecruitmentMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                YearlyTerminationData.Add(YearlyTerminationMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                YearlyPromotionData.Add(YearlyPromotionMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                EmployeebyCategoryData.Add(EmployeebyCategoryMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                MaleFemaleRatioBothData.Add(MaleFemaleRatioMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                MaleFemaleRatioOfficerData.Add(MaleFemaleRatioMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                MaleFemaleRatioStaffData.Add(MaleFemaleRatioMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                EmployeeAgeRangeGenderWiseData.Add(EmployeeAgeRangeGenderWiseMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                RetirementvsTerminatedOverallData.Add(RetirementvsTerminatedOverallMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                TechnicalNonTechnicalCadrewiseinformationData.Add(TechnicalNonTechnicalCadrewiseinformationMapToValue(reader));
                            }


                            response.EmployeeAgeRangeList = EmployeeAgeRangeData;
                            response.EmployeeYearsofServiceList = EmployeeYearsofServiceData;
                            response.YearlyTurnoverList = YearlyTurnoverData;
                            response.YearlyRecruitmentList = YearlyRecruitmentData;
                            response.YearlyTerminationList = YearlyTerminationData;
                            response.YearlyPromotionList = YearlyPromotionData;
                            response.EmployeebyCategoryList = EmployeebyCategoryData;
                            response.MaleFemaleRatioBothList = MaleFemaleRatioBothData;
                            response.MaleFemaleRatioOfficerList = MaleFemaleRatioOfficerData;
                            response.MaleFemaleRatioStaffList = MaleFemaleRatioStaffData;
                            response.EmployeeAgeRangeGenderWiseList = EmployeeAgeRangeGenderWiseData;
                            response.RetirementvsTerminatedOverallList = RetirementvsTerminatedOverallData;
                            response.TechnicalNonTechnicalCadrewiseinformationList = TechnicalNonTechnicalCadrewiseinformationData;

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
        private EmployeeAgeRange EmployeeAgeRangeMapToValue(SqlDataReader reader)
        {
            return new EmployeeAgeRange()
            {
                Age = reader["Age"].ToString(),
                Count = Convert.ToInt32(reader["Count"].ToString()),
            };
        }
        private EmployeeYearsofService EmployeeYearsofServiceMapToValue(SqlDataReader reader)
        {
            return new EmployeeYearsofService()
            {
                Age = reader["Age"].ToString(),
                Engineer = Convert.ToInt32(reader["Engineers"].ToString()),
                Admin = Convert.ToInt32(reader["Admin"].ToString()),
                Finance = Convert.ToInt32(reader["Finance"].ToString())
            };
        }
        private YearlyTurnover YearlyTurnoverMapToValue(SqlDataReader reader)
        {
            return new YearlyTurnover()
            {
                Month = reader["Month"].ToString(),
                Count = Convert.ToInt32(reader["Count"].ToString()),
                Order = Convert.ToInt32(reader["Order"].ToString())
            };
        }
        private YearlyRecruitment YearlyRecruitmentMapToValue(SqlDataReader reader)
        {
            return new YearlyRecruitment()
            {
                Month = reader["Month"].ToString(),
                Count = Convert.ToInt32(reader["Count"].ToString()),
                Order = Convert.ToInt32(reader["Order"].ToString())
            };
        }
        private YearlyTermination YearlyTerminationMapToValue(SqlDataReader reader)
        {
            return new YearlyTermination()
            {
                Month = reader["Month"].ToString(),
                Count = Convert.ToInt32(reader["Count"].ToString()),
                Order = Convert.ToInt32(reader["Order"].ToString())
            };
        }
        private YearlyPromotion YearlyPromotionMapToValue(SqlDataReader reader)
        {
            return new YearlyPromotion()
            {
                Month = reader["Month"].ToString(),
                Count = Convert.ToInt32(reader["Count"].ToString()),
                Order = Convert.ToInt32(reader["Order"].ToString())
            };
        }
        private EmployeebyCategory EmployeebyCategoryMapToValue(SqlDataReader reader)
        {
            return new EmployeebyCategory()
            {
                Category = reader["Category"].ToString(),
                Count = Convert.ToInt32(reader["Count"].ToString())
            };
        }
        private MaleFemaleRatio MaleFemaleRatioMapToValue(SqlDataReader reader)
        {
            return new MaleFemaleRatio()
            {
                Gender = reader["Gender"].ToString(),
                EmpCount = Convert.ToInt32(reader["EmpCount"].ToString())
            };
        }
        private EmployeeAgeRangeGenderWise EmployeeAgeRangeGenderWiseMapToValue(SqlDataReader reader)
        {
            return new EmployeeAgeRangeGenderWise()
            {
                Age = reader["Age"].ToString(),
                Male = Convert.ToInt32(reader["Male"].ToString()),
                Female = Convert.ToInt32(reader["Female"].ToString())
            };
        }
        private RetirementvsTerminatedOverall RetirementvsTerminatedOverallMapToValue(SqlDataReader reader)
        {
            return new RetirementvsTerminatedOverall()
            {
                EmpStatus = reader["EmpStatus"].ToString(),
                EmpCount = Convert.ToInt32(reader["EmpCount"].ToString())
            };
        }
        private TechnicalNonTechnicalCadrewiseinformation TechnicalNonTechnicalCadrewiseinformationMapToValue(SqlDataReader reader)
        {
            return new TechnicalNonTechnicalCadrewiseinformation()
            {
                DesignationType = reader["DesignationType"].ToString(),
                Officer = Convert.ToInt32(reader["Officer"].ToString()),
                Staff = Convert.ToInt32(reader["Staff"].ToString())
            };
        }
    }
}
