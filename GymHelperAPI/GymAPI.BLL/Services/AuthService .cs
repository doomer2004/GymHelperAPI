using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using GymAPI.BLL.Services.Interfaces;
using GymAPI.Common.DTO;
using GymAPI.Common.Models;
using GymHelper.DAL.Entities;
using GymHelper.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace GymAPI.BLL.Services;

public class UserService : IAuthService
{
    private readonly UserRepository _repository;
    private readonly IPasswordHasher _hasher;
    private readonly JwtSettings _settings;
    
    
    public async Task<AuthSuccessDTO> LoginAsync(LoginUserDTO user)
    {
        string hashedPassword = _hasher.HashPassword(user.Password);
        var existingUser = await _repository.FindByLoginAsync(user.Login);

        if (existingUser == null)
        {
            throw new KeyNotFoundException(user.Login);
        }
        if (existingUser.PasswordHash != hashedPassword)
        {
            throw new UnauthorizedAccessException(user.Login);
        }

        return new AuthSuccessDTO(GenerateJwtToken(existingUser));

    }

    public async Task<AuthSuccessDTO> RegisterAsync(RegisterUserDTO user)
    {
        string hashedPassword = _hasher.HashPassword(user.Password);
        var existingUser = await _repository.FindByLoginAsync(user.Login);

        if (existingUser != null)
        {
            throw new InvalidOperationException(user.Login);
        }

        var newUser = new User()
        {
            Login = user.Login,
            PasswordHash = hashedPassword,
        };
        _repository.Add(newUser);

        return new AuthSuccessDTO(GenerateJwtToken(newUser));
    }

    private string GenerateJwtToken(User user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim("id", user.Id.ToString()),
                new Claim("login", user.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
            Issuer = _settings.Issuer,
            Audience = _settings.Audience
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);
        return jwtToken;
    }
}