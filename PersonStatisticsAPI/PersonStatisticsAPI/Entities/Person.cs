using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [Required]
        [StringLength(32)]
        public string Mail { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone{ get; set; }
        [Required]
        [StringLength(15)]
        public string Sex { get; set; }
        public DateTime Dr { get; set; } // date registration
    }
}
