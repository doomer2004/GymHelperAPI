namespace GymHelper.DAL.Entities;

public class Subscription : BaseEntity<Guid>
{
    public string Type { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    
    public List<UserSubscription> UserSubscriptions { get; set; }
}