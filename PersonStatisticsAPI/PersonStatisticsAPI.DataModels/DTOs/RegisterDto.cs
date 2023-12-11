namespace PersonStatisticsAPI.DataModels.DTOs
{
    public class RegisterDto : BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
