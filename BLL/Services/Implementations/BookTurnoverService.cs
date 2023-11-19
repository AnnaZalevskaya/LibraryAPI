using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Implementations
{
    public class BookTurnoverService : IBookTurnoverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookTurnoverService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(BookTurnoverUserDTOModel addDTO)
        {
            var turnover = _mapper.Map<BookTurnover>(addDTO);
            await _unitOfWork.BookTurnovers.AddAsync(turnover);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.BookTurnovers.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<BookTurnoverDTOModel>> GetAllAsync()
        {
            var turnover = await _unitOfWork.BookTurnovers.GetAllAsync();
            var turnoverList = new List<BookTurnoverDTOModel>();

            foreach (var book in turnover)
            {
                turnoverList.Add(_mapper.Map<BookTurnoverDTOModel>(book));
            }

            return turnoverList;
        }

        public async Task<BookTurnoverDTOModel> GetByIdAsync(int id)
        {
            var turnover = await _unitOfWork.BookTurnovers.GetByIdAsync(id);

            if (turnover == null)
            {
                throw new EntityNotFoundException("Turnover not found");
            }

            var bookTurnoverDTO = _mapper.Map<BookTurnoverDTOModel>(turnover);

            return bookTurnoverDTO;
        }

        public async Task UpdateAsync(int id, BookTurnoverUserDTOModel updateDTO)
        {
            var turnover = _mapper.Map<BookTurnover>(updateDTO);
            await _unitOfWork.BookTurnovers.UpdateAsync(id, turnover);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
