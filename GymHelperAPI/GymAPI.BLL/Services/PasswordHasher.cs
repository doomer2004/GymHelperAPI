namespace GymAPI.BLL.Services;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password, string salt)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }
}