using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IBookTurnoverService
    {
        Task AddAsync(BookTurnoverUserDTOModel addDTO);
        Task DeleteAsync(int id);
        Task<List<BookTurnoverDTOModel>> GetAllAsync();
        Task<BookTurnoverDTOModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, BookTurnoverUserDTOModel updateDTO);
    }
}
