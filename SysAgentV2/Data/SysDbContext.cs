using Microsoft.EntityFrameworkCore;
using SysAgentV2.Models;

namespace SysAgentV2.Data
{
    public class SysDbContext: DbContext
    {
        public SysDbContext(DbContextOptions<SysDbContext> options): base(options) { }
        public DbSet<CollectMetrics> CollectMetrics { get; set; }
        public DbSet<AgentExecutionStatus> AgentStatus { get; set; }
        public DbSet<AgentScriptCmd> AgentScriptCmd { get; set; }
        public DbSet<AgentScripFile> AgentScripFile { get; set; }

        // To input data to database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AgentExecutionStatus>().HasData(
                new AgentExecutionStatus
                {
                    Id = 1,
                    Status = Enum.ExecutionStatus.STOPPED.ToString(),
                    CreatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<AgentHealthStatus>().HasData(
                new AgentHealthStatus
                {
                    Id = 1,
                    HealthStatus = Enum.AgentHealthStatus.DISABLED.ToString(),
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
