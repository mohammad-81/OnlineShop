using OnlineShop.Application.DTOs.SiteSide;
using OnlineShop.Application.Services.Interfaces;
using OnlineShop.Domain.Entitties.User;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Application.Utillities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Implements;

public class UserService: IUserService
{
    #region ctor
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    #endregion

    #region General Methods

    public bool IsExistsMobile(string mobile)
    {
        var result=_userRepository.IsExistUserByMobile(mobile.Trim());
        return result;
    }

    public User? FillRegisterEntity(UserRegisterDTO registerDTO)
    {
        User user = new User
        {
            UserName=registerDTO.Mobile.Trim(),
            Mobile=registerDTO.Mobile,
            Password = PasswordHelper.EncodePasswordMd5(registerDTO.Password),
            CreatedDate = DateTime.Now
        };
        return user;
    }

    public void AddUser(User user)
    {
        _userRepository.AddUser(user);
        
    }

    public bool RegisterUser( UserRegisterDTO registerDTO)
    {
        if (IsExistsMobile(registerDTO.Mobile) == true)
        {

            return false;
        }

        var user= FillRegisterEntity(registerDTO);
        AddUser(user);

        return true;
    }
    #endregion
}
