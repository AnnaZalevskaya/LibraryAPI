using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<Book> GetByISBNAsync(string ISBN);
    }
}
