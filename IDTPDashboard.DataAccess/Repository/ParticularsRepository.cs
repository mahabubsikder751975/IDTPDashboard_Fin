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
    public class ParticularsRepository : IParticularsRepository
    {
        private readonly string _connectionString;
        public ParticularsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }
       
        public async Task<List<Particular>> GetParticulars(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetParticulars", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Organization", Organization));

                    var response = new List<Particular>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }
       
        private Particular MapToValue(SqlDataReader reader)
        {
            return new Particular()
            {                
                Id = Convert.ToInt32(reader["Id"]),
                ParticularName = reader["ParticularName"].ToString(),
                CurrentStatus= reader["CurrentStatus"].ToString(),
                LastUpdatedDate = Convert.ToDateTime(reader["LastUpdatedDate"])
            };
        }
        public async Task InsertParticular(Particular particular)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertParticular", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ParticularName", particular.ParticularName));
                    cmd.Parameters.Add(new SqlParameter("@CurrentStatus", particular.CurrentStatus));
                    //cmd.Parameters.Add(new SqlParameter("@OrderNo", particular.ParticularName));
                    //cmd.Parameters.Add(new SqlParameter("@UploadDate", particular.ParticularName));
                    //cmd.Parameters.Add(new SqlParameter("@Organization", particular.ParticularName));

                    
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await sql.CloseAsync();
                }
            }
        }
    }

   
}
