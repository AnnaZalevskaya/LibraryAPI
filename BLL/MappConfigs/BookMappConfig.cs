using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    public class BookMappConfig : Profile
    {
        public BookMappConfig()
        {
            CreateMap<Book, BookDTOModel>().ReverseMap();
            CreateMap<Author, AuthorDTOModel>().ReverseMap();
            CreateMap<Genre, GenreDTOModel>().ReverseMap();
            
        }
    }
}
