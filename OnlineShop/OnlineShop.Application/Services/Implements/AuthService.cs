using Microsoft.AspNetCore.Identity;
using OnlineShop.Application.DTOs.SiteSide.AuthDto;
using OnlineShop.Application.Services.Interfaces;
using OnlineShop.Domain.Entitties;
using OnlineShop.Domain.Entitties.Identity;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser>_userManeger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public AuthService(IUserRepository userRepository , UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userRepository = userRepository;
            _userManeger = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<AuthResponseDto> RegisterAsync(AuthRegisterDto model)
        {
            var phoneExist =  await _userRepository.IsExistUserByMobile(model.Mobile);
            if (phoneExist)
            {
                return new AuthResponseDto
                {
                    Succeeded = false,
                    Message = "این شماره موبایل قبلا ثبت شده است .",
                    Errors = new List<string> { "این شماره موبایل قبلا ثبت شده است ." }
                };
            }

            var user = new ApplicationUser()
            {
                PhoneNumber = model.Mobile,
                UserName = model.Mobile,
                CreatedDate = DateTime.Now
            };
            var result =  await _userManeger.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                await _userManeger.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user,isPersistent: false);
                return new AuthResponseDto
                {
                    Succeeded= true,
                    Message=".با موفقیت ثبت نام  شدید ",
                };
            }

            return new AuthResponseDto
            {
                Succeeded = false,                
                Errors = result.Errors.Select(e => e.Description).ToList(),
                Message = "عملیات ثبت نام با خطا مواجه شد ."
            };

        }
        public async Task<AuthResponseDto> LoginAsync(AuthLoginDto model)
        {
            var user = await _userManeger.FindByNameAsync(model.Mobile);
            if (user == null)
            {
                return new AuthResponseDto
                {
                    Succeeded = false,
                    Message = "این شماره همراه وجود ندارد",
                    Errors = new List<string> { "این شماره همراه وجود ندارد" }

                };
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return new AuthResponseDto
                {
                    Succeeded = true,
                    Message = "با موفقیت وارد شدید",

                };
            }
            else
            {
                return new AuthResponseDto
                {
                    Succeeded = false,
                    Message = "رمز عبور یا شماره تلفن صحیح نیست",
                    Errors = new List<string> { "نام کاربری یا رمز عبور اشتباه است." }

                };
            }
            
        }


        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
