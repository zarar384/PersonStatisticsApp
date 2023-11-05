using AutoMapper;
using PersonStatisticsAPI.DataModels;
using PersonStatisticsAPI.DataModels.DTOs;
using PersonStatisticsAPI.Models;
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
                config.CreateMap<Box, BoxDto>().ReverseMap();
                config.CreateMap<RegisterDto, User>();
                config.CreateMap<User, UserDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
