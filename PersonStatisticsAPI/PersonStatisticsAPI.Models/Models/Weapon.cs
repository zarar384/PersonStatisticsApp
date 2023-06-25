using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.Models
{
    public class Weapon : BaseModel
    {
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public int Damage { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
    }
}