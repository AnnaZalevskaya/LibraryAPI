using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    public class GenreMappConfig : Profile
    {
        public GenreMappConfig()
        {
            CreateMap<Genre, GenreDTOModel>().ReverseMap();
        }
    }
}
