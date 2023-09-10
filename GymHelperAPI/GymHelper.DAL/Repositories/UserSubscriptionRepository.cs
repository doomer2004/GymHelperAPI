using GymHelper.DAL.EF;
using GymHelper.DAL.Entities;
using GymHelper.DAL.Repositories.Base;
using GymHelper.DAL.Repositories.Interfaces;

namespace GymHelper.DAL.Repositories;

public class UserSubscriptionRepository : RepositoryBase<UserSubscription, int>, IUserSubscriptionRepository
{
    public UserSubscriptionRepository(Context context) : base(context)
    {
        
    }
}