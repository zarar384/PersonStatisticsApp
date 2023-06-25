using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.DataModels
{
    public class RaceDto:BaseDto
    {
        public string Description { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

    }
}
