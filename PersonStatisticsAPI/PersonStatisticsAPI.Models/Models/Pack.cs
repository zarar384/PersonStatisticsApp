using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonStatisticsAPI.Models
{
    public class Pack: BaseModel
    {       

        [Required]
        [MaxLength]
        public string Description { get; set; }
        [NotMapped]
        public List<int> Tags { get; set; }
        public DateTime Dc { get; set; } = DateTime.Now;// date of creation
        public int User { get; set; }
    }
}
