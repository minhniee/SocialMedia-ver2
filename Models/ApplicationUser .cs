using Microsoft.AspNetCore.Identity;

namespace SocialMedia.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    public string Avatar { get; set; }
    public string Bio { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
    public virtual ICollection<Friendship> FriendshipsInitiated { get; set; }
    public virtual ICollection<Friendship> FriendshipsReceived { get; set; }
    public virtual ICollection<Notification> Notifications { get; set; }

}
