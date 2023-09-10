using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using GymAPI.BLL.Services.Interfaces;
using GymAPI.Common.DTO;
using GymAPI.Common.Models;
using GymHelper.DAL.Entities;
using GymHelper.DAL.Repositories;
using GymHelper.DAL.Repositories.Base;
using GymHelper.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GymAPI.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordHasher _hasher;
    private readonly JwtSettings _settings;

    public AuthService(IUserRepository repository, IPasswordHasher hasher,  IOptions<JwtSettings> settings)
    {
        _repository = repository;
        _hasher = hasher;
        _settings = settings.Value;
    }

    public async Task<AuthSuccessDTO> LoginAsync(LoginUserDTO user)
    {
        
        var existingUser = await _repository.FindByLoginAsync(user.Login);
        var hashedPassword = _hasher.HashPassword(user.Password, existingUser.Salt);
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
        var hashedPassword = _hasher.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt(12));
        var existingUser = await _repository.FindByLoginAsync(user.Login);

        if (existingUser != null)
        {
            throw new InvalidOperationException(user.Login);
        }

        var newUser = new User()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
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