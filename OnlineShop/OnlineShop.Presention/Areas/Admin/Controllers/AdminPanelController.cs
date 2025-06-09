using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.AdminSide;
using OnlineShop.Application.Services.Implements.AdminSide;
using OnlineShop.Application.Services.Interfaces.AdminSide;

namespace OnlineShop.Presention.Areas.Admin.Controllers;

public class AdminPanelController:AdminBaseController
{
    private readonly IAdminPanelService _panelService;
    
    public AdminPanelController(IAdminPanelService panelService)
    {
        _panelService = panelService;
    }

    [HttpGet]
    public async Task<IActionResult>Users()
    {
        var Users =  await _panelService.GetUserListAsync();

        return View (Users);

    }

}
