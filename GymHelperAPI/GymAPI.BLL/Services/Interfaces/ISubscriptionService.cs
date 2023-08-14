using GymAPI.Common.DTO;

namespace GymAPI.BLL.Services.Interfaces;

public interface ISubscriptionService
{
    Task<SubscriptionDTO> UpdateSubscription(string type, SubscriptionDTO subscription);
    Task<SubscriptionDTO> DeleteSubscription(string type);
    Task<SubscriptionDTO> GetSubscriptionByType(string type);
    Task<SubscriptionDTO> GetAllSubscription();
}