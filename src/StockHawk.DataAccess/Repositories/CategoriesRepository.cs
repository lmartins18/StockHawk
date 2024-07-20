using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;
public class CategoryRepository : BaseRepository<Category>
{
    public CategoryRepository(StockHawkDbContext context) : base(context) { }
}
