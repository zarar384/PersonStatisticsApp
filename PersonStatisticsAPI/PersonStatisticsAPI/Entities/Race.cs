using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.Entities
{
    public class Race
    {
        [Key]
        public int Id { get; set; }
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
