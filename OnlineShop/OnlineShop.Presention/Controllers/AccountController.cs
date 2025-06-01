using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.SiteSide;
using OnlineShop.Application.Services.Interfaces;

namespace OnlineShop.Presention.Controllers
{
    public class AccountController : Controller
    {
        #region ctor
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                _userService.RegisterUser(registerDTO);
                return RedirectToAction("Index","Home");
            }
            return View(registerDTO);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Login(UserLoginDTO loginDTO)
        {

        }
        #endregion

        #region logOut
        #endregion
    }
}
