using GymAPI.Common.DTO;
using GymHelper.DAL.Entities;
namespace GymAPI.BLL.Services.Interfaces;

public interface ISubscriptionService
{
    Task<SubscriptionDTO> AddSubscription(SubscriptionDTO subscription);
    Task<SubscriptionDTO> UpdateSubscription(string type, UpdateSubscriptionDTO subscription);
    Task<bool> DeleteSubscription(string type);
    Task<SubscriptionDTO?> GetSubscriptionByType(string type);
    List<SubscriptionDTO> GetAllSubscription();
}