using OnlineShop.Domain.Entitties;
using OnlineShop.Domain.Entitties.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.IRepositories
{
     public interface IAdminPanelRepository
    {
        Task<List<ApplicationUser>> ListOfUsersAsync();
        Task<List<ApplicationRole>?> GetRolesAsync(ApplicationUser user);
    }
}
