using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementations
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(AppDBContext context) : base(context)
        {

        }

        public async Task<Genre> GetByNameAsync(string name)
        {
            var genre = _context.Genres!.FirstOrDefault(x => x.Name == name);

            return await _context.FindAsync<Genre>(genre.Id);
        }
    }
}
