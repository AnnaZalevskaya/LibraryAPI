using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    public class BookTurnoverMappConfig : Profile
    {
        public BookTurnoverMappConfig()
        {
            CreateMap<BookTurnover, BookTurnoverDTOModel>().ReverseMap();
            CreateMap<Book, BookDTOModel>().ReverseMap();
            CreateMap<Author, AuthorDTOModel>().ReverseMap();
            CreateMap<Genre, GenreDTOModel>().ReverseMap();
        }
    }
}
