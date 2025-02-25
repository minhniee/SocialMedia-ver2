using SocialMedia.Models;

namespace SocialMedia.Service
{
    public interface IPostService
    {
        Task<string> GetPost(string postId);
        Task<IEnumerable<Post>> GetPosts(string userId);
        Task<string> CreatePost(Post post);
        Task<string> DeletePost(string postId);
        Task<string> UpdatePost(string postId);


    }
}
