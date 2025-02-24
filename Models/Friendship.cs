namespace SocialMedia.Models;

public class Friendship
{
    public int Id { get; set; }
    public string RequesterId { get; set; }
    public string AddresseeId { get; set; }
    public FriendshipStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ApplicationUser Requester { get; set; }
    public virtual ApplicationUser Addressee { get; set; }
}

