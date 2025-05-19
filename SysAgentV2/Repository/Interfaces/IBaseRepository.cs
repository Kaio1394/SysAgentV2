namespace SysAgentV2.Repository.Interfaces
{
    public interface IBaseRepository
    {
        public Task Add<T>(T entity) where T : class;
        public Task Update<T>(T entity) where T : class;
        public Task Delete<T>(T entity) where T : class;
        Task<bool> SaveChanges();
    }
}
