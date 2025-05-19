using Microsoft.EntityFrameworkCore;
using SysAgentV2.Models;

namespace SysAgentV2.Data
{
    public class SysDbContext: DbContext
    {
        public SysDbContext(DbContextOptions<SysDbContext> options): base(options) { }
        public DbSet<CollectMetrics> CollectMetrics { get; set; }
        public DbSet<AgentStatus> AgentStatus { get; set; }

        // To input data to database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AgentStatus>().HasData(
                new AgentStatus
                {
                    Id = 1,
                    Status = "STOPPED",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
