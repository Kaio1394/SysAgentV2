using SysAgentV2.Models;

namespace SysAgentV2.Repository.Interfaces
{
    public interface IAgentExecutionStatusRepository
    {
        Task Update(Models.AgentExecutionStatus agent);
        Task<Models.AgentExecutionStatus?> GetByIdAsync(int id = 1);
        Task<bool> SaveChanges();
    }
}
