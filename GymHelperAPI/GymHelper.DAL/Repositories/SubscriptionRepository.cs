using GymHelper.DAL.EF;
using GymHelper.DAL.Entities;
using GymHelper.DAL.Repositories.Base;

namespace GymHelper.DAL.Repositories;

public class SubscriptionRepository : RepositoryBase<Subscription>
{
    public SubscriptionRepository(Context context) : base(context)
    {
    }
}