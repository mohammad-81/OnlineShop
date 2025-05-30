using Microsoft.AspNetCore.Mvc;

namespace onlineShop.Presentation.ViewComponents;

public class SiteSideBarViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("SiteSideBar");
    }
}
