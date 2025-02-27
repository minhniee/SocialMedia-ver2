using SocialMedia.Models;

namespace SocialMedia.Repositories
{

    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync(string userId);
        Task<Post> CreatePostAsync(Post post);
        Task<bool> UpdatePostAsync(Post post);
        Task<bool> DeletePostAsync(Post post);
        Task<Post> GetPostByIdAsync(int id);


    }
}
