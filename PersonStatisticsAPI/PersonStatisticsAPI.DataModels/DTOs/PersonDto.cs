using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.DataModels
{
    public class PersonDto:BaseDto
    {
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public DateTime Dr { get; set; } // date registration
    }
}
