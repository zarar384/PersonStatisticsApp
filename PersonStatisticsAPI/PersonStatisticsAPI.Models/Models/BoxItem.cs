using System.ComponentModel.DataAnnotations;

namespace PersonStatisticsAPI.Models;

public class BoxItem : BaseModel
{
    public string Name { get; set; }
    public string Information { get; set; }
    public int BoxId { get; set; }

    [Range(0, 10)]
    public double Rating { get; set; }

    public Box Box { get; set; }
    public ICollection<ItemRating> Ratings { get; set; }
}
