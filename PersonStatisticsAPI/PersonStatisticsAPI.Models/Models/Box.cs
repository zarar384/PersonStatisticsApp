
namespace PersonStatisticsAPI.Models
{
    public class Box : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public User Owner { get; set; }
        public Category Category { get; set; }
        public ICollection<BoxRecipient> Recipients { get; set; }
    }
}
