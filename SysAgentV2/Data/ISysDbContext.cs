using Microsoft.EntityFrameworkCore;
using SysAgentV2.Models.Schedulling;
using SysAgentV2.Models.Scripts;
using SysAgentV2.Models;

namespace SysAgentV2.Data
{
    public interface ISysDbContext
    {
        DbSet<CollectMetrics> CollectMetrics { get; set; }
        DbSet<AgentExecutionStatus> AgentStatus { get; set; }
        DbSet<ScriptCmd> ScriptCmd { get; set; }
        DbSet<ScripFile> ScripFile { get; set; }
        DbSet<Schedule> Schedule { get; set; }
        DbSet<ScheduleScripts> ScheduleScripts { get; set; }
        DbSet<AgentHealthStatus> AgentHealthStatus { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
