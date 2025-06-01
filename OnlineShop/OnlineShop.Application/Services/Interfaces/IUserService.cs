using OnlineShop.Application.DTOs.SiteSide;
using OnlineShop.Domain.Entitties.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Interfaces
{
    public interface IUserService
    {
        bool IsExistsMobile(string mobile);
        User FillRegisterEntity(UserRegisterDTO registerDTO);
        void AddUser(User user);
        bool RegisterUser(UserRegisterDTO registerDTO);


    }
}
