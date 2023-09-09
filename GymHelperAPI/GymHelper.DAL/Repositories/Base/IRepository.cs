using Microsoft.EntityFrameworkCore;

namespace GymHelper.DAL.Repositories.Base;

public interface IRepository<TEntity,in TKey>
    where TEntity : class
    where TKey : IEquatable<TKey> 
{
    DbSet<TEntity> Table { get; }

    int Add(TEntity entity, bool persist = true);
    Task<bool> AddAsync(TEntity entity, bool persist = true);
    Task<TEntity?> FindAsync(string name);
    Task<bool> AddRangeAsync(IEnumerable<TEntity> entities, bool persist = true);
    Task<bool> UpdateAsync(TEntity entity, bool persist = true);
    Task<bool> DeleteAsync(TEntity entity, bool persist = true);
    
    int SaveChanges();
    Task<int> SaveChangesAsync();
    IEnumerable<TEntity> GetAll();
}
    
    
    