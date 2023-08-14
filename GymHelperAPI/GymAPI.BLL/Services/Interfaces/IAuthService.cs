

using GymAPI.Common.DTO;

namespace GymAPI.BLL.Services.Interfaces;
public interface IAuthService
{
    Task<AuthSuccessDTO> LoginAsync(LoginUserDTO user);
    Task<AuthSuccessDTO> RegisterAsync(RegisterUserDTO user);
}