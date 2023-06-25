using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.Models
{
    public class Roleplayer : BaseModel
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
    }
}