using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.DataModels
{
    public class RoleplayerDto: BaseDto
    {
        public int PersonId { get; set; }
        public PersonDto Person { get; set; }
        public int RaceId { get; set; }
        public RaceDto Race { get; set; }
    }
}