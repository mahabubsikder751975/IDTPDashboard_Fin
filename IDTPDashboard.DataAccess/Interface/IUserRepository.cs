using IDTPDashboard.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAndPassword(string username, string password);
    }
}
