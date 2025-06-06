using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    [ValidateAntiForgeryToken] 
    public async Task<IActionResult> Register(AuthRegisterDto model)
    {
        if (ModelState.IsValid)
        {
            var result = await _authService.RegisterAsync(model);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "عملیات ثبت نام با موفقیت انجام شد .";
                return RedirectToAction("Index","Home");
            }
            else
            ModelState.AddModelError(string.Empty, "عملیات ثبت نام با شکست مواجه شد.");

        }
        return View(model);
    }
    #endregion

    #region Login 
    [HttpGet]
    [AllowAnonymous]
    public async Task <IActionResult> Login(string? returnUrl) 
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
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }

            else
            {
                if (result.Errors != null && result.Errors.Any())
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }
                else if (!string.IsNullOrEmpty(result.Message))
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "ورود ناموفق بود. مشکلی پیش آمده است.");
                }
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
