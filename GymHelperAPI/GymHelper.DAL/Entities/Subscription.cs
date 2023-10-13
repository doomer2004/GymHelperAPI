namespace GymHelper.DAL.Entities;

public class Subscription : BaseEntity<Guid>
{
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    
    public List<UserSubscription> UserSubscriptions { get; set; }
}