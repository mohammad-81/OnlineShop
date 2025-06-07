using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Presention.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdminBaseController:Controller
{

}
