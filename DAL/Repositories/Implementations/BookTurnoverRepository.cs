using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class BookTurnoverRepository : BaseRepository<BookTurnover>, IBookTurnoverRepository
    {
        public BookTurnoverRepository(AppDBContext context) : base(context)
        {

        }

        public new async Task<IEnumerable<BookTurnover>> GetAllAsync()
        {
            return await _context.BookTurnovers!
                    .Include(bt => bt.Book)
                        .ThenInclude(b => b!.Author)
                    .Include(bt => bt.Book)
                        .ThenInclude(b => b!.Genre)
                    .ToListAsync();
        }

        public new async Task<BookTurnover> GetByIdAsync(int id)
        {
            var bt = await _context.BookTurnovers!
                    .Include(bt => bt.Book)
                        .ThenInclude(b => b!.Author)
                    .Include(bt => bt.Book)
                        .ThenInclude(b => b!.Genre)
                    .FirstOrDefaultAsync(b => b.Id == id);

            return bt!;
        }

        public new async Task AddAsync(BookTurnover item)
        {
            item.TakenTime = DateTime.UtcNow;
            item.ReturnedTime = DateTime.UtcNow.AddDays(21);

            await _context.AddAsync(item);
        }
    }
}
