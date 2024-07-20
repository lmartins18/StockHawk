using Microsoft.EntityFrameworkCore;

namespace StockHawk.DataAccess.Repositories;
public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly StockHawkDbContext Context;

    protected BaseRepository(StockHawkDbContext context)
    {
        this.Context = context;
    }

    public virtual IEnumerable<T> GetAll()
    {
        return Context.Set<T>();
    }

    public virtual T? GetById(int id)
    {
        return Context.Set<T>().Find(id);
    }

    public virtual void Add(T entity)
    {
        Context.Set<T>().Add(entity);
    }

    public virtual void Update(T entity)
    {
        Context.Set<T>().Update(entity);
    }

    public virtual void Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
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
    }

    public virtual async Task UpdateAsync(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        Context.Set<T>().Remove(entity);
        await SaveChangesAsync();
    }

    private async Task<int> SaveChangesAsync()
    => await Context.SaveChangesAsync();
}