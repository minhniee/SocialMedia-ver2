using SocialMedia.Models;

namespace SocialMedia.Service
{
    public interface IPostService
    {
        Task<ServiceResponse<Post>> GetPost(int postId);
        Task<ServiceResponse<IEnumerable<Post>>> GetPosts(string userId);
        Task<ServiceResponse<string>> CreatePost(Post post);
        Task<ServiceResponse<bool>> DeletePost(string postId);
        Task<ServiceResponse<bool>> UpdatePost(Post post);


    }
}
