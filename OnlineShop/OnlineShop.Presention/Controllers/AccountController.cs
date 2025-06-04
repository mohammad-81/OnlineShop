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

    #region Register
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
    #endregion

    #region Login 
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string? returnUrl) 
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View(new AuthLoginDto());
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task <IActionResult> Login(AuthLoginDto model,string? returnUrl=null)
    {
        ViewData["ReturnUrl"]= returnUrl;
        if (ModelState.IsValid) 
        {
            var result = await _authService.LoginAsync(model);
            if (result.Succeeded)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    Redirect(returnUrl);
                }
                RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors!) { 
                ModelState.AddModelError(string.Empty, error); 
            }

            if (result.Errors == null || !result.Errors.Any())
            {
                ModelState.AddModelError(string.Empty, result.Message ?? "ورود ناموفق بود.");
            }
        }
        return View(model);

    }
    #endregion

    #region LockOut
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogOut()
    {
        await _authService.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }

    #endregion
}
