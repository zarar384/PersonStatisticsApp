using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.Models;
public class BaseModel
{
    [Key]
    public Guid Id { get; set; }
    [StringLength(50)]
    public string Name { get; set; }
}
