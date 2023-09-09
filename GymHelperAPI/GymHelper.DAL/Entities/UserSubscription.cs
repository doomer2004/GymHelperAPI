using System.ComponentModel.DataAnnotations.Schema;

namespace GymHelper.DAL.Entities;

public class UserSubscription : BaseEntity<Guid>
{
    public DateTimeOffset SubscriptionStart { get; set; }
    public DateTimeOffset SubscriptionEnd { get; set; }
    
    public Guid UserId { get; set; }
    public Guid SubscriptionId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    
    [ForeignKey(nameof(SubscriptionId))]
    public Subscription Subscription { get; set; }
}