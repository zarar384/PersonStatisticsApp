using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.Models
{
    public class Race : BaseModel
    {
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        public int Strength { get; set; }
        [Required]
        public int Dexterity { get; set; }
        [Required]
        public int Intelligence { get; set; }

    }
}
