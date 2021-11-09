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
    public class GraphRepository : IGraphRepository
    {
        private readonly string _connectionString;
        public GraphRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }
       
        public async Task<List<GraphSetup>> GetGraphSetupList(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetGraphSetup", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Organization", Organization));

                    var response = new List<GraphSetup>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(await MapToValueAsync(reader));
                        }
                    }

                    return response;
                }
            }
        }
       
        private async Task<GraphSetup> MapToValueAsync(SqlDataReader reader)
        {
            return new GraphSetup()
            {
                Id = Convert.ToInt32(reader["Id"]),
                GraphName = reader["GraphName"].ToString(),
                ChartType = reader["ChartType"].ToString(),
                GraphDataList =await GetGraphDataList(Convert.ToInt32(reader["Id"]))
            };
        }

        public async Task<List<GraphData>> GetGraphDataList(int id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetGraphData", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    var response = new List<GraphData>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(GraphDataMapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private GraphData GraphDataMapToValue(SqlDataReader reader)
        {
            return new GraphData()
            {                
                ParticularName = reader["ParticularName"].ToString(),
                ParticularValue = Convert.ToInt64(reader["ParticularValue"]),                
            };
        }

        public async Task<List<GraphItem>> GetGraphItemList(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetGraphItems", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Organization", Organization));

                    var response = new List<GraphItem>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(GraphItemMapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private GraphItem GraphItemMapToValue(SqlDataReader reader)
        {
            return new GraphItem()
            {                 
                ParticularName = reader["ParticularName"].ToString(),
                Category = reader["Category"].ToString(), 
                TableName= reader["TableName"].ToString(),
            };
        }

        public async Task InsertGraphSetup(string organization,GraphSetup graphSetup,string dataQuery)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertGraphSetup", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@graphname", graphSetup.GraphName));
                    cmd.Parameters.Add(new SqlParameter("@dataquery", dataQuery));
                    cmd.Parameters.Add(new SqlParameter("@charttype", graphSetup.ChartType));
                    cmd.Parameters.Add(new SqlParameter("@organization", organization));
                    cmd.Parameters.Add(new SqlParameter("@xaxistitle", graphSetup.XAxisTitle));
                    cmd.Parameters.Add(new SqlParameter("@yaxistitle", graphSetup.YAxisTitle));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await sql.CloseAsync();
                }
            }
        }

        public async Task<GraphItem> GetGraphItemByParticularName(string particularName)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetTableNameByParticularName", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ParticularName", particularName));

                    var response = new List<GraphItem>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(GraphItemByParticularMapToValue(reader));
                        }
                    }

                    return response.FirstOrDefault();
                }
            }
        }

        private GraphItem GraphItemByParticularMapToValue(SqlDataReader reader)
        {
            return new GraphItem()
            {
                ParticularName = reader["ParticularName"].ToString(),
                Category = reader["Category"].ToString(),
                TableName = reader["TableName"].ToString(),
            };
        }
    }

   
}
