namespace GymAPI.BLL.Services;

public interface IPasswordHasher
{
    string HashPassword(string password, string salt);
}