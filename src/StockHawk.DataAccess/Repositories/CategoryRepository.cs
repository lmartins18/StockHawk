using Microsoft.EntityFrameworkCore;
using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(StockHawkDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await Context.Set<Category>()
            .Where(p => !p.IsDeleted)
            .ToListAsync();
    }
    public override Task<Category?> GetByIdAsync(int id)
        => Context.Set<Category>()
            .Include(s => s.Products)
            .FirstOrDefaultAsync(s => s.Id == id);

}