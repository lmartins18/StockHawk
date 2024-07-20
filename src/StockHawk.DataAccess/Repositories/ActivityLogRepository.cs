using StockHawk.Model;

namespace StockHawk.DataAccess.Repositories;
public class ActivityLogRepository : BaseRepository<ActivityLog>
{
    public ActivityLogRepository(StockHawkDbContext context) : base(context) { }
    // TODO maybe expand this to get the data for the relationships (user etc...)
}
