using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    public class BookTurnoverUserMappConfig : Profile
    {
        public BookTurnoverUserMappConfig()
        {
            CreateMap<BookTurnover, BookTurnoverUserDTOModel>().ReverseMap();
        }
    }
}
