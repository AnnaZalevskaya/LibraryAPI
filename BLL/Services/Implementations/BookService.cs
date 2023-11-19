using Abp.Domain.Entities;
using AutoMapper;
using BLL.MappConfigs;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private GenreService genreService;
        private AuthorService authorService;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            genreService = new GenreService(unitOfWork, mapper);
            authorService = new AuthorService(unitOfWork, mapper);
        }

        public async Task AddAsync(BookDTOModel bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);

            book.Genre = await genreService.GetByNameAsync(bookDTO.Genre!.Name!);
            book.Author = await authorService.GetByFullNameAsync(bookDTO.Author!.FullName!);

            await _unitOfWork.Books.AddAsync(book);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Books.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<BookDTOModel>> GetAllAsync()
        {
            var books = await _unitOfWork.Books.GetAllAsync();
            var booksDTOList = new List<BookDTOModel>();

            foreach (var book in books)
            {
                var config = new MapperConfiguration(cfg => cfg.AddProfile<BookMappConfig>());
                var mapper = new Mapper(config);
                BookDTOModel dto = mapper.Map<BookDTOModel>(book);
                booksDTOList.Add(dto);
                Console.WriteLine(dto.Author);
            }

            return booksDTOList;
        }

        public async Task<BookDTOModel> GetByIdAsync(int id)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);

            if (book == null)
            {
                throw new EntityNotFoundException("Book not found");
            }

            var bookDTO = _mapper.Map<BookDTOModel>(book);

            return bookDTO;
        }

        public async Task<BookDTOModel> GetByISBNAsync(string ISBN)
        {
            var book = await _unitOfWork.Books.GetByISBNAsync(ISBN);

            if (book == null)
            {
                throw new EntityNotFoundException("Guide not found");
            }

            var bookDTO = _mapper.Map<BookDTOModel>(book);

            return bookDTO;
        }

        public async Task UpdateAsync(int id, BookDTOModel updateBookDTO)
        {
            var book = _mapper.Map<Book>(updateBookDTO);

            book.Genre = await genreService.GetByNameAsync(updateBookDTO.Genre!.Name!);
            book.Author = await authorService.GetByFullNameAsync(updateBookDTO.Author!.FullName!);

            await _unitOfWork.Books.UpdateAsync(id, book);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
