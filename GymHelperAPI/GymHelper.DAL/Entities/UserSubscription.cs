using System.ComponentModel.DataAnnotations.Schema;

namespace GymHelper.DAL.Entities;

public class UserSubscription : BaseEntity
{
    public DateTime SubscriptionStart { get; set; }
    public DateTime SubscriptionEnd { get; set; }
    
    public int UserId { get; set; }
    public int SubscriptionId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    
    [ForeignKey(nameof(SubscriptionId))]
    public Subscription Subscription { get; set; }
}