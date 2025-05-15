using Microsoft.EntityFrameworkCore;
using SysAgentV2.Models;

namespace SysAgentV2.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<CollectMetrics> CollectMetrics { get; set; }
    }
}
