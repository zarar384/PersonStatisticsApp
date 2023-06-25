using AutoMapper;
using PersonStatisticsAPI.DataModels;
using PersonStatisticsAPI.Models;

namespace PersonStatisticsAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Person, PersonDto>()
                .ForMember("UId", s=>s.Ignore())
                .AfterMap((model,dto)=>model.Id = dto.UId);
            CreateMap<Ability, AbilityDto>();
            CreateMap<Armor, ArmorDto>();
            CreateMap<Race, RaceDto>();
            CreateMap<Roleplayer, RoleplayerDto>();
            CreateMap<Weapon, WeaponDto>();
        }
    }
}
