using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Entitties;

namespace OnlineShop.Application.Services.Implements;

public class SuperAdminAutorizationHandlerService : AuthorizationHandler<IAuthorizationRequirement>
{
    private readonly UserManager<ApplicationUser> _userManager;
    public SuperAdminAutorizationHandlerService( UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IAuthorizationRequirement requirement)
    {
        if (!context.User.Identity?.IsAuthenticated == true) 
        {
            return;
        }
        var currentUser = await _userManager.GetUserAsync(context.User);

        if (currentUser != null && currentUser.IsSuperAdmin)
        {
            context.Succeed(requirement);
        }
    }
}
