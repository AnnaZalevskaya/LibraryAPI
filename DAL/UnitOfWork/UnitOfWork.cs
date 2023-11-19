using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDBContext _context;

        private IBookRepository? _bookRepository;
        private IBookTurnoverRepository? _bookTurnoverRepository;
        private IGenreRepository? _genreRepository;
        private IAuthorRepository? _authorRepository;

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
        }

        public IBookRepository Books
        {

            get
            {
                _bookRepository ??= new BookRepository(_context);
                return _bookRepository;
            }
        }
        public IBookTurnoverRepository BookTurnovers
        {

            get
            {
                _bookTurnoverRepository ??= new BookTurnoverRepository(_context);
                return _bookTurnoverRepository;
            }
        }
        public IGenreRepository Genres
        {

            get
            {
                _genreRepository ??= new GenreRepository(_context);
                return _genreRepository;
            }
        }
        public IAuthorRepository Authors
        {

            get
            {
                _authorRepository ??= new AuthorRepository(_context);
                return _authorRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
