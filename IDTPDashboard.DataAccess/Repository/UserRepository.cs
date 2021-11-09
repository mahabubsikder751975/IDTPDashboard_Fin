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
    public class UserRepository:IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }
        //private List<User> users = new List<User> {
        //new User{ Id=1,Name="ahasan",Password="123456",Role="Admin"},
        // new User{ Id=2,Name="alamin",Password="123456",Role="Manager"}
        //};
        public async Task<User>  GetByUsernameAndPassword(string username, string password)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAuthenticatedUser", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@password", password));

                    var response = new List<User>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response.FirstOrDefault();
                }
            }

            //var user = users.SingleOrDefault(u => u.Name == username && u.Password == password);
            //return user;
        }
       
        private User MapToValue(SqlDataReader reader)
        {
            return new User()
            {                
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString(),
                UserName= reader["UserName"].ToString(),
                Email = reader["Email"].ToString(),
                Organization = reader["Organization"].ToString(),
                OfficeCode = reader["OfficeCode"].ToString(),
                OfficeName = reader["OfficeName"].ToString(),
                PbsName = reader["PbsName"].ToString(),
                Role = reader["Role"].ToString(),
            };
        }
    }

   
}
