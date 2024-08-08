using Microsoft.EntityFrameworkCore;
using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;

public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
{
    public SupplierRepository(StockHawkDbContext context) : base(context)
    {
    }

    public override Task<Supplier?> GetByIdAsync(int id)
    {
        return Context.Set<Supplier>()
            .Include(s => s.Products.Where(p => !p.IsDeleted))
            .FirstOrDefaultAsync(s => s.Id == id);
    }

}