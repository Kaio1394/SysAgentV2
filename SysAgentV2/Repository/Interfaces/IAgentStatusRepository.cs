using SysAgentV2.Models;

namespace SysAgentV2.Repository.Interfaces
{
    public interface IAgentStatusRepository
    {
        Task Update(Models.AgentStatus agent);
        Task<Models.AgentStatus?> GetByIdAsync(int id = 1) ;
        Task<bool> SaveChanges();
    }
}
