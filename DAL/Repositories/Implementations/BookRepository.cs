using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(AppDBContext context) : base(context)
        {

        }

        public async Task<Book> GetByISBNAsync(string ISBN)
        {
            var book = await _context.Books!
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.ISBN == ISBN);

            return book!;
        }

        public new async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books!
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();  
        }
        
        public new async Task<Book> GetByIdAsync(int id)
        {
            var book = await _context.Books!
                            .Include(b => b.Author)
                            .Include(b => b.Genre)
                            .FirstOrDefaultAsync(b => b.Id == id);
            return book!;
        }


    }
}
