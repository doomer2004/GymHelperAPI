using AutoMapper;
using GymAPI.BLL.Services.Interfaces;
using GymAPI.Common.DTO;
using GymHelper.DAL.Entities;
using GymHelper.DAL.Repositories;

namespace GymAPI.BLL.Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly SubscriptionRepository _repository;
    private readonly IMapper _mapper;

    public SubscriptionService(SubscriptionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<SubscriptionDTO> AddSubscription(Subscription subscription)
    {
        var entity = _mapper.Map<Subscription>(subscription);
        if (await _repository.Table.FindAsync(entity.Type) != null) 
            throw new InvalidOperationException("Entity with such key already exists in database");
        await _repository.AddAsync(entity);
        return _mapper.Map<SubscriptionDTO>(entity);
    }

    public async Task<SubscriptionDTO> UpdateSubscription(string type, SubscriptionDTO subscription)
    {
        var entity = await _repository.FindAsync(type);

        if (entity == null)
        {
            throw new KeyNotFoundException($"Unable to find entity with such key {type}");
        }

        _mapper.Map(subscription, entity);

        await _repository.UpdateAsync(entity);
        return _mapper.Map<SubscriptionDTO>(entity);
    }

    public async Task<bool> DeleteSubscription(string type)
    {
        var subscription = await _repository.FindAsync(type);

        if (subscription == null) return false;
        var deleted = await _repository.DeleteAsync(subscription);
        return deleted;
    }

    public async Task<SubscriptionDTO?> GetSubscriptionByType(string type)
    {
        var subscription = await _repository.FindAsync(type);
        return subscription != null ? _mapper.Map<SubscriptionDTO>(subscription) : null;
    }

    public List<SubscriptionDTO> GetAllSubscription()
    {
        return _mapper.Map<IEnumerable<SubscriptionDTO>>(_repository.GetAll()).ToList();
    }
}