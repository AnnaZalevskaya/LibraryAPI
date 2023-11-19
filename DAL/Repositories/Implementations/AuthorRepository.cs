using DAL.Entities;
using DAL.Repositories.Interfaces;
namespace DAL.Repositories.Implementations
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDBContext context) : base(context)
        {

        }

        public async Task<Author> GetByFullNameAsync(string name)
        {
            var author = _context.Authors!.FirstOrDefault(x => x.FullName == name);

            return await _context.FindAsync<Author>(author.Id);
        }
    }
}
