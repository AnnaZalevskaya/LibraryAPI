using BLL.Models;
using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDTOModel>> GetAllAsync();
        Task<AuthorDTOModel> GetByIdAsync(int id);
        Task<Author> GetByFullNameAsync(string fullname);
    }
}
