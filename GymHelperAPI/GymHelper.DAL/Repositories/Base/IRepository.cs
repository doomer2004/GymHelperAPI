﻿using Microsoft.EntityFrameworkCore;

namespace GymHelper.DAL.Repositories.Base;

public interface IRepository<TEntity> where TEntity : class
{
    DbSet<TEntity> Table { get; }

    int Add(TEntity entity, bool persist = true);
    Task<bool> AddAsync(TEntity entity, bool persist = true);
    Task<TEntity?> FindAsync(int id);
    Task<bool> AddRangeAsync(IEnumerable<TEntity> entities, bool persist = true);
    Task<bool> UpdateAsync(TEntity entity, bool persist = true);
    Task<bool> DeleteAsync(TEntity entity, bool persist = true);
    
    int SaveChanges();
    Task<int> SaveChangesAsync();
}
    
    
    