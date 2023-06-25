using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.DataModels
{
    public class ArmorDto: BaseDto
    {
        public string Description { get; set; }
        public int Protect { get; set; }
        public string Armor_type { get; set; }
        public int RaceId { get; set; }
        public RaceDto Race { get; set; }
    }
}