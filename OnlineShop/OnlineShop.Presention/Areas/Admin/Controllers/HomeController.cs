using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Presention.Areas.Admin.Controllers;


public class HomeController : AdminBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
