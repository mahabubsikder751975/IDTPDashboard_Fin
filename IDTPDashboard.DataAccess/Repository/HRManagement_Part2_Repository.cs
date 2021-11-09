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
    public class HRManagement_Part2_Repository: IHRManagement_Part2_Repository
    {
        private readonly string _connectionString;
        public HRManagement_Part2_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }

        public async Task<HRManagement_Part2_Entity> GetAllReports(string companyName, string PBSName)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("HRM_Dashboard_Part2", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CompanyName", companyName));
                    cmd.Parameters.Add(new SqlParameter("@pbsName", PBSName));

                    var response = new HRManagement_Part2_Entity();
                    var sanctionedPostVacantPostData = new List<SanctionedPostVacantPost>();
                    var maleFemaleEmployeeData = new List<MaleFemaleEmployee>();
                    var backgroundWisePostData = new List<BackgroundWisePost>();
                    var zoneWiseOfficeData = new List<ZoneWiseOffice>();

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                sanctionedPostVacantPostData.Add(SanctionedPostVacantPostMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                maleFemaleEmployeeData.Add(MaleFemaleEmployeeMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                backgroundWisePostData.Add(BackgroundWisePostMapToValue(reader));
                            }

                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                zoneWiseOfficeData.Add(ZoneWiseOfficeMapToValue(reader));
                            }


                            response.SanctionedPostVacantPostList = sanctionedPostVacantPostData;
                            response.MaleFemaleEmployeeList = maleFemaleEmployeeData;
                            response.BackgroundWisePostList = backgroundWisePostData;
                            response.ZoneWiseOfficeList = zoneWiseOfficeData;
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

        private SanctionedPostVacantPost SanctionedPostVacantPostMapToValue(SqlDataReader reader)
        {
            return new SanctionedPostVacantPost()
            {
                Post = reader["Post"].ToString(),
                SanctionedPosts = Convert.ToInt32(reader["Sanctioned Posts"].ToString()),
                VacantPosts = Convert.ToInt32(reader["Vacant Posts"].ToString()),
                Order = Convert.ToInt32(reader["OrderNo"].ToString())
            };
        }

        private MaleFemaleEmployee MaleFemaleEmployeeMapToValue(SqlDataReader reader)
        {
            return new MaleFemaleEmployee()
            {
                Post = reader["Post"].ToString(),
                MaleEmployee = Convert.ToInt32(reader["Male Employee"].ToString()),
                FemaleEmployee = Convert.ToInt32(reader["Female Employee"].ToString()),
                Order = Convert.ToInt32(reader["Order"].ToString())
            };
        }

        private BackgroundWisePost BackgroundWisePostMapToValue(SqlDataReader reader)
        {
            return new BackgroundWisePost()
            {
                PostType = reader["Post Type"].ToString(),
                Engineering = Convert.ToInt32(reader["Engineering"].ToString()),
                Admin_HR = Convert.ToInt32(reader["Admin/HR"].ToString()),
                Finance = Convert.ToInt32(reader["Finance"].ToString()),
                IT = Convert.ToInt32(reader["IT"].ToString()),
                Order = Convert.ToInt32(reader["Order"].ToString())
            };
        }
        private ZoneWiseOffice ZoneWiseOfficeMapToValue(SqlDataReader reader)
        {
            return new ZoneWiseOffice()
            {
                Zone = reader["Zone"].ToString(),
                NoOfOffices = Convert.ToInt32(reader["No of Offices"].ToString()),
                Order = Convert.ToInt32(reader["Order"].ToString())
            };
        }

    }
}
