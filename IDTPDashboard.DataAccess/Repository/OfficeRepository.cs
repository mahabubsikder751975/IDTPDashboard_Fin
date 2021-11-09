using IDTPDashboard.DataAccess.Interface;
using IDTPDashboard.DomainModel.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Repository
{
    public class OfficeRepository: IOfficeRepository
    {
        private readonly string _connectionString;
        public OfficeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }

        public async Task<OfficeList_Entity> GetAllData(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("OfficeList", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@organization", Organization));

                    var response = new OfficeList_Entity();
                    var officeData = new List<Office>();

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            officeData.Add(MapToValue(reader));
                        }
                        response.officeList = officeData;
                    }

                    return response;
                }
            }

        }
       
        private Office MapToValue(SqlDataReader reader)
        {
            return new Office()
            {
                id = Convert.ToInt32(reader["id"].ToString()),
                OfficeCode = reader["OfficeCode"].ToString(),
                OfficeName= reader["OfficeName"].ToString(),
                Organization = reader["Organization"].ToString(),
            };
        }
    }

   
}
