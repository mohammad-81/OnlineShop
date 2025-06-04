using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.SiteSide;
using OnlineShop.Application.DTOs.SiteSide.AuthDto;
using OnlineShop.Application.Services.Interfaces;

namespace OnlineShop.Presention.Controllers;

public class AccountController : Controller
{
    #region ctor
    private readonly IAuthService _authService ;
    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }

    #endregion


    [HttpGet]
    public IActionResult Register()
    {
        return View(new AuthRegisterDto());
    }

    [HttpPost]
    
    [ValidateAntiForgeryToken] // حتماً برای فرم‌های POST اضافه کنید
    public async Task<IActionResult> Register(AuthRegisterDto model)
    {
        if (ModelState.IsValid)
        {
            var result = await _authService.RegisterAsync(model);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Registration successful! Please log in.";
                return RedirectToAction("Index","Home");
            }

            foreach (var error in result.Errors!) // Errors ممکن است null باشد
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }
        return View(model);
    }
   

}
