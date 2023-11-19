using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IBookService
    {
        Task AddAsync(BookDTOModel addBookDTO);
        Task DeleteAsync(int id);
        Task<List<BookDTOModel>> GetAllAsync();
        Task<BookDTOModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, BookDTOModel updateBookDTO);
        public Task<BookDTOModel> GetByISBNAsync(string ISBN);
    }
}
