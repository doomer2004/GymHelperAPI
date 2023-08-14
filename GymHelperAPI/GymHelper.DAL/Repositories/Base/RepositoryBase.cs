using GymHelper.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace GymHelper.DAL.Repositories.Base;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
{
    public Context Context { get; }
    public DbSet<TEntity> Table { get; }


    protected RepositoryBase(Context context)
    {
        Context = context ?? throw new ArgumentException(nameof(Context));
        Table = Context.Set<TEntity>();
    }
    
    public virtual int Add(TEntity entity, bool persist = true)
    {
        Table.Add(entity);
        return persist ? SaveChanges() : 0;
    }
    
    public virtual async Task<bool> AddAsync(TEntity entity, bool persist = true)
    {
        await Table.AddAsync(entity);
        return persist && await SaveChangesAsync() > 0;
    }
    
    public virtual async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities, bool persist = true)
    {
        await Table.AddRangeAsync(entities);
        return persist && await SaveChangesAsync() > 0;
    }

    public virtual async Task<TEntity?> FindAsync(string name)
    {
        return await Table.FindAsync(name);
    }
    
    public virtual async Task<bool> UpdateAsync(TEntity entity, bool persist = true)
    {
        Table.Update(entity);
        return persist && await SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> DeleteAsync(TEntity entity, bool persist = true)
    {
        Table.Remove(entity);
        return persist && await SaveChangesAsync() > 0;
    }


    public virtual async Task<int> SaveChangesAsync()
    {
        try
        {
            return await Context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred updating the database");
        }
    }

    public virtual int SaveChanges()
    {
        try
        {
            return Context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred updating the database", e);
        }
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return Table;
    }
}