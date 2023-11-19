using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        IBookTurnoverRepository BookTurnovers { get; }
        IAuthorRepository Authors { get; }
        IGenreRepository Genres { get; }

        Task SaveChangesAsync();
    }
}
