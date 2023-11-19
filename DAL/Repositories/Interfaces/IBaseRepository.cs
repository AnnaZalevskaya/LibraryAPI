namespace DAL.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity item);
        Task UpdateAsync(int id, TEntity item);
        Task DeleteAsync(int id);
    }
}