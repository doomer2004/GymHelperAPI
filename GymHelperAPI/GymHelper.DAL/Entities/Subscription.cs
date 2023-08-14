namespace GymHelper.DAL.Entities;

public class Subscription : BaseEntity
{
    public string Type { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    
    public List<UserSubscription> UserSubscriptions { get; set; }
}