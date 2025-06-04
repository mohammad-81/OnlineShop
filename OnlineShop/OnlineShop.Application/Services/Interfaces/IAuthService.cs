
using OnlineShop.Application.DTOs.SiteSide.AuthDto;

namespace OnlineShop.Application.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(AuthRegisterDto model);
    Task<AuthResponseDto> LoginAsync(AuthLoginDto model);
    Task LogoutAsync();
}
