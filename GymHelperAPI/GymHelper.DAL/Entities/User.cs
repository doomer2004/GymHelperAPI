namespace GymHelper.DAL.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Login { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public List<UserSubscription> UserSubscriptions { get; set; }
}