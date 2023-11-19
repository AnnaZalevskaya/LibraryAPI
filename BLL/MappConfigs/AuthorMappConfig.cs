using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    public class AuthorMappConfig : Profile
    {
        public AuthorMappConfig()
        {
            CreateMap<Author, AuthorDTOModel>().ReverseMap();
        }
    }
}
