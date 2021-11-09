using IDTPDashboard.DataAccess.Repository;
using IDTPDashboard.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Interface
{
    public interface IMenu_Repository
    {
        Task<List<Menu_Entity>> GetAllMenu(string organization);
    }
}
