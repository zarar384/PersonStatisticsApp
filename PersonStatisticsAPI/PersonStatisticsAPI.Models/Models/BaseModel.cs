using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.Models;
public class BaseModel
{
    [Key]
    public int Id { get; set; }

}
