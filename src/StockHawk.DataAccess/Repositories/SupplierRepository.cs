using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;
public class SupplierRepository : BaseRepository<Supplier>
{
    public SupplierRepository(StockHawkDbContext context) : base(context) { }
}
