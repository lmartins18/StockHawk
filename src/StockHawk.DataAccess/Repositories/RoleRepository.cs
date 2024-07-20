using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;

public class RoleRepository : BaseRepository<Role>
{
    public RoleRepository(StockHawkDbContext context) : base(context) { }

}