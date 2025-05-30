using Microsoft.EntityFrameworkCore;
using SysAgentV2.Models;
using SysAgentV2.Models.Schedulling;
using SysAgentV2.Models.Scripts;

namespace SysAgentV2.Data
{
    public class SysDbContext: DbContext
    {
        public SysDbContext(DbContextOptions<SysDbContext> options): base(options) { }
        public DbSet<CollectMetrics> CollectMetrics { get; set; }
        public DbSet<AgentExecutionStatus> AgentStatus { get; set; }
        public DbSet<ScriptCmd> ScriptCmd { get; set; }
        public DbSet<ScripFile> ScripFile { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ScheduleScripts> ScheduleScripts { get; set; }
        public DbSet<AgentHealthStatus> AgentHealthStatus { get; set; }

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
                    HealthStatus = Enum.HealthStatus.DISABLED.ToString(),
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
