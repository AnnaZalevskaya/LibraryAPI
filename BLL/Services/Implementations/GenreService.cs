using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
        }

        public async Task<List<GenreDTOModel>> GetAllAsync()
        {
            var genres = await _unitOfWork.Genres.GetAllAsync();
            var genresDTOList = new List<GenreDTOModel>();

            foreach (var genre in genres)
            {
                GenreDTOModel dto = _mapper.Map<GenreDTOModel>(genre);
                genresDTOList.Add(dto);
            }

            return genresDTOList;
        }

        public async Task<GenreDTOModel> GetByIdAsync(int id)
        {
            var genre = await _unitOfWork.Genres.GetByIdAsync(id);

            if (genre == null)
            {
                throw new EntityNotFoundException("Genre not found");
            }

            var genreDTO = _mapper.Map<GenreDTOModel>(genre);

            return genreDTO;
        }

        public async Task<Genre> GetByNameAsync(string name)
        {
            var genre = await _unitOfWork.Genres.GetByNameAsync(name);

            if (genre == null)
            {
                throw new EntityNotFoundException("Genre not found");
            }

            return genre;
        }
    }
}
