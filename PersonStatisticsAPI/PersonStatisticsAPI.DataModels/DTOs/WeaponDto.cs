using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.DataModels
{
    public class WeaponDto: BaseDto
    {
        public string Description { get; set; }
        public int Damage { get; set; }
        public int RaceId { get; set; }
        public RaceDto Race { get; set; }
    }
}