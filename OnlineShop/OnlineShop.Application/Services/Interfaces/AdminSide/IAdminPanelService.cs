using OnlineShop.Application.DTOs.AdminSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Interfaces.AdminSide
{
    public interface IAdminPanelService
    {
        Task<IEnumerable<UserListDto>> GetUserListAsync();
    }
}
