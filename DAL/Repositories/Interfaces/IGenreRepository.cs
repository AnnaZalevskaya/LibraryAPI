using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<Genre> GetByNameAsync(string name);
    }
}
