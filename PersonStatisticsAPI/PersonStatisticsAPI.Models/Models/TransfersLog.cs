namespace PersonStatisticsAPI.Models;

public class TransfersLog : BaseModel
{
    public int SenderId { get; set; }
    public int RecipientId { get; set; }
    public DateTime TransferDate { get; set; } = DateTime.Now;
    public string Status { get; set; }
    public string BoxInfo { get; set; }

    public User Sender { get; set; }
    public BoxRecipient Recipient { get; set; }
}
