﻿using GymHelper.DAL.EF;
using GymHelper.DAL.Entities;
using GymHelper.DAL.Repositories.Base;

namespace GymHelper.DAL.Repositories;

public class UserSubscriptionRepository : RepositoryBase<UserSubscription>
{
    public UserSubscriptionRepository(Context context) : base(context)
    {
    }
}