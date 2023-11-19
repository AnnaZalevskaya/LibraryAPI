using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AuthorDTOModel>> GetAllAsync()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();
            var authorsDTOList = new List<AuthorDTOModel>();

            foreach (var author in authors)
            {
                AuthorDTOModel dto = _mapper.Map<AuthorDTOModel>(author);
                authorsDTOList.Add(dto);
            }

            return authorsDTOList;
        }

        public async Task<AuthorDTOModel> GetByIdAsync(int id)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(id);

            if (author == null)
            {
                throw new EntityNotFoundException("Author not found");
            }

            var authorDTO = _mapper.Map<AuthorDTOModel>(author);

            return authorDTO;
        }

        public async Task<Author> GetByFullNameAsync(string name)
        {
            var author = await _unitOfWork.Authors.GetByFullNameAsync(name);

            if (author == null)
            {
                throw new EntityNotFoundException("Author not found");
            }

            return author;
        }
    }
}
