using AutoMapper;
using FreeSqlDemo.Models;

namespace FreeSqlDemo
{
    public class MyProfile:Profile
    {
        public MyProfile()
        {
            CreateMap<Blog, BlogDto>();
            CreateMap<BlogUpdateDto, Blog>();
            CreateMap<BlogCreateDto, Blog>();
        }
    }
}
