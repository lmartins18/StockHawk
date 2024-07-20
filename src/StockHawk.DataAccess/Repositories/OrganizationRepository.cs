using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;
public class OrganizationRepository : BaseRepository<Organization>
{
    public OrganizationRepository(StockHawkDbContext context) : base(context) { }
}