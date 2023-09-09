using GymHelper.DAL.EF;
using GymHelper.DAL.Entities;
using GymHelper.DAL.Repositories.Base;
using GymHelper.DAL.Repositories.Interfaces;

namespace GymHelper.DAL.Repositories;

public class SubscriptionRepository : RepositoryBase<Subscription, string>, ISubscriptionRepository
{
    public SubscriptionRepository(Context context) : base(context)
    {
    }
}