namespace PersonStatisticsAPI.Models;

public class Notification : BaseModel
{
    public int UserId { get; set; }
    public string Text { get; set; }
    public string LinkObjectUrl { get; set; }
    public DateTime NotificationDate { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
}
