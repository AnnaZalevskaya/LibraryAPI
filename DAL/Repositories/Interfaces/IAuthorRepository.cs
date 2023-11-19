using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<Author> GetByFullNameAsync(string name);
    }
}
