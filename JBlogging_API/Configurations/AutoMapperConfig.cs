using AutoMapper;
using JBlogging_API.DTOs.Category;
using JBlogging_API.Models;

namespace JBlogging_API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();

        }
    }
}
