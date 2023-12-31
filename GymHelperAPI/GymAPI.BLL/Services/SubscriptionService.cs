﻿using AutoMapper;
using GymAPI.BLL.Services.Interfaces;
using GymAPI.Common.DTO;
using GymHelper.DAL.Entities;
using GymHelper.DAL.Repositories;
using GymHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymAPI.BLL.Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionRepository _repository;
    private readonly IMapper _mapper;

    public SubscriptionService(ISubscriptionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<SubscriptionDTO> AddSubscription(SubscriptionDTO subscription)
    {
        var entity = _mapper.Map<Subscription>(subscription);
        if (await _repository.Table.AnyAsync(s => s.Type == entity.Type))
        {
            throw new InvalidOperationException($"Subscription with type {entity.Type} already exists");
        }
        await _repository.AddAsync(entity);
        return _mapper.Map<SubscriptionDTO>(entity);
    }

    public async Task<SubscriptionDTO> UpdateSubscription(string type, UpdateSubscriptionDTO subscription)
    {
        var entity = await _repository.Table.FirstOrDefaultAsync(s => s.Type == type);

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
        var subscription = await _repository.Table.FirstOrDefaultAsync(s => s.Type == type);

        if (subscription == null) 
            return false;
        
        return await _repository.DeleteAsync(subscription);
    }

    public async Task<SubscriptionDTO?> GetSubscriptionByType(string type)
    {
        Subscription? subscription = await _repository.Table.FirstOrDefaultAsync(s => s.Type == type);
        return subscription != null ? _mapper.Map<SubscriptionDTO>(subscription) : null;
    }

    public List<SubscriptionDTO> GetAllSubscription()
    {
        return _mapper.Map<IEnumerable<SubscriptionDTO>>(_repository.GetAll()).ToList();
    }
}