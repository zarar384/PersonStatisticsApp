using AutoMapper;
using PersonStatisticsAPI.DataModels;
using PersonStatisticsAPI.DataModels.DTOs;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Helpers
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<BaseModel, BaseDto>().ReverseMap();
                config.CreateMap<Box, BoxDto>().ForMember(dest => dest.OwnerUsername, opt => opt.MapFrom(src => src.Owner.UserName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
                config.CreateMap<BoxDto, Box>();
                config.CreateMap<RegisterDto, User>();
                config.CreateMap<User, UserDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
