using AutoMapper;
using PersonStatisticsAPI.DataModels;
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
                config.CreateMap<Person, PersonDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
