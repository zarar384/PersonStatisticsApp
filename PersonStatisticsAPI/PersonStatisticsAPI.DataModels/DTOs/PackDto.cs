namespace PersonStatisticsAPI.DataModels
{
    public class PackDto:BaseDto
    {
        public string Description { get; set; }
        public List<int> Tags { get; set; }
        public DateTime Dr { get; set; } // date registration
        public int  User { get; set; }
    }
}
