using AutoMapper;
using LightAbp.Maps.Dtos;
using LightAbp.Models;

namespace LightAbp.Maps
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<Book, BookDto>();//出口
            CreateMap<CreateUpdateBookDto, Book>();//入口

        }
    }
}
