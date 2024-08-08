using Microsoft.EntityFrameworkCore;
using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly StockHawkDbContext Context;

    protected BaseRepository(StockHawkDbContext context)
    {
        Context = context;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public virtual async Task AddAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        await SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        await Task.Run(() => Context.Set<T>().Update(entity));
        await SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        Context.Set<T>().Remove(entity);
        await SaveChangesAsync();
    }

    public virtual async Task DeactivateAsync(T entity)
    {
        var toDeactivate = await GetByIdAsync(entity.Id);
        if (toDeactivate != null)
        {
            toDeactivate.IsDeleted = true;
            await UpdateAsync(toDeactivate);
        }
    }
    public virtual async Task<int> CountAsync() => await Context.Set<T>().CountAsync(p => !p.IsDeleted);

    private async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }

}