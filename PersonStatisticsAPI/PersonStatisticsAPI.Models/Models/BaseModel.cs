using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.Models;
public class BaseModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(32)]
    public string Name { get; set; }
}
