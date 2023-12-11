namespace PersonStatisticsAPI.DataModels
{
    public class BoxDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public string OwnerUsername { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
