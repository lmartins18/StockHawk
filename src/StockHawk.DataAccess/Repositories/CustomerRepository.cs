using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;
public class CustomerRepository : BaseRepository<Customer>
{
    public CustomerRepository(StockHawkDbContext context) : base(context) { }
}