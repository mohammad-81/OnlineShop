using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.AppDbContext;
using OnlineShop.Domain.Entitties;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories;

public class UserRepository : IUserRepository
{
    #region ctor
    private readonly UserManager<ApplicationUser> _userManager;
    public UserRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    #endregion

    #region General Methods
    public async Task<bool> IsExistUserByMobile(string mobile)
    {
        var result = _userManager.Users.Any(x => x.PhoneNumber == mobile);
        return result;
    }

    public async Task<ApplicationUser> FindByPhoneNumberAsync(string phoneNumber)
    {
        return await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
    }
    #endregion
}