using Microsoft.EntityFrameworkCore;
using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;
public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(StockHawkDbContext context) : base(context)
    {

    }
    public override async Task<Customer?> GetByIdAsync(int id)
    {
        return await Context.Set<Customer>()
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }


    public override async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await Context.Set<Customer>()
            .Where(p => !p.IsDeleted)
            .ToListAsync();
    }

}