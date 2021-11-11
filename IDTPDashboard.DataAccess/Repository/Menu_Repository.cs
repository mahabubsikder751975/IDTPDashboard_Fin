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
    public class Menu_Repository : IMenu_Repository
    {
        private readonly string _connectionString;
        public Menu_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }
        public async Task<List<Menu_Entity>> GetAllMenu(string organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetMenuList", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@organization", organization));

                    var response = new List<Menu_Entity>();
                    await sql.OpenAsync();

                    // using (var reader = await cmd.ExecuteReaderAsync())
                    // {
                    //     while (await reader.ReadAsync())
                    //     {
                    //         response.Add(MenuMapToValue(reader));
                    //     }
                    // }

                    return response;
                }
            }
        }

        private Menu_Entity MenuMapToValue(SqlDataReader reader)
        {
            return new Menu_Entity()
            {
                Organization = reader["Organization"].ToString(),
                MenuName = reader["MenuName"].ToString(),
                Controller = reader["Controller"].ToString(),
                Action = reader["Action"].ToString(),
                MenuOrder = Convert.ToInt32(reader["MenuOrder"].ToString()),
                Status = Convert.ToBoolean(reader["Status"].ToString())
            };
        }
    }
}
