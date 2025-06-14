using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entitties;
using OnlineShop.Domain.Entitties.Identity;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories
{
    public class AdminPanelRepository : IAdminPanelRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AdminPanelRepository(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<ApplicationUser>> ListOfUsersAsync()
        {
            var users= await _userManager.Users.ToListAsync();
            return users;
        }
        public async Task<List<ApplicationRole>?> GetRolesAsync(ApplicationUser user)
        { 

            var roleNames = await _userManager.GetRolesAsync(user);
            if (roleNames == null || !roleNames.Any())
            {
                return null;
            }

            var listOfRoles= new List<ApplicationRole>();
            foreach (var roleName in roleNames)
            {
                var role=await _roleManager.FindByNameAsync(roleName);
                if(role != null)
                {
                    listOfRoles.Add(role);
                }
            }
            return listOfRoles;

        }
    }
}
