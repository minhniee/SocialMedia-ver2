namespace SocialMedia.Models;

public class Notification
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Content { get; set; }
    public string Link { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
    public NotificationType Type { get; set; }
    public virtual ApplicationUser User { get; set; }
}