using BLL.Models;
using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IGenreService
    {
        Task<List<GenreDTOModel>> GetAllAsync();
        Task<GenreDTOModel> GetByIdAsync(int id);
        Task<Genre> GetByNameAsync(string name);
    }
}
