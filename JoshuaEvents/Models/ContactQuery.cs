namespace JoshuaEvents.Models;

public class ContactQuery
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string EventType { get; set; } = string.Empty;
    public DateTime? EventDate { get; set; }
    public int GuestCount { get; set; }
    public decimal Budget { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}
