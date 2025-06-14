using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.IRepositories;

public interface IUserRepository
{

    Task <bool> IsExistUserByMobile(string mobile);
    Task<ApplicationUser> FindByPhoneNumberAsync(string phoneNumber);
    //void AddUser(User user);
    //void SaveChange();

}
