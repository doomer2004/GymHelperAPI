using AutoMapper;
using GymAPI.Common.DTO;
using GymHelper.DAL.Entities;

namespace GymAPI.BLL.Profiles;

public class SubscriptionProfile : Profile
{
    public SubscriptionProfile()
    {
        CreateMap<Subscription, SubscriptionDTO>().ReverseMap();
        CreateMap<Subscription, UpdateSubscriptionDTO>().ReverseMap();
    }
}