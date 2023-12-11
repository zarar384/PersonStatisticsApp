namespace PersonStatisticsAPI.Models;

public class BoxRecipient : BaseModel
{
    public int BoxId { get; set; }
    public int RecipientId { get; set; }

    public Box Box { get; set; }
    public User Recipient { get; set; }
}
