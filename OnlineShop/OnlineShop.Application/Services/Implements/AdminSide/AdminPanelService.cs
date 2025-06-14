using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.DTOs.AdminSide;
using OnlineShop.Application.Services.Interfaces.AdminSide;
using OnlineShop.Domain.Entitties;
using OnlineShop.Domain.Entitties.Identity;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Implements.AdminSide
{
    public class AdminPanelService : IAdminPanelService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IAdminPanelRepository _adminPanelRepository;

        public AdminPanelService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IAdminPanelRepository adminPanelRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _adminPanelRepository = adminPanelRepository;
        }

        public async Task<IEnumerable<UserListDto>> GetUserListAsync()
        {
            var users = await _adminPanelRepository.ListOfUsersAsync();
            var ListUsers= new List<UserListDto>();
            foreach (var user in users)
            {
                var roles = await _adminPanelRepository.GetRolesAsync(user);
                ListUsers.Add(new UserListDto
                {
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    FullName= user.FullName,
                    IsDelete= user.IsDelete,
                    CreatedDate = user.CreatedDate,
                    UserAvatar = user.UserAvatar,
                    Roles = roles?.Select(r => r.Name)
                });
                
            }
            return ListUsers;
        }
    }
}
