using SocialMedia.Models;
using SocialMedia.Repositories;

namespace SocialMedia.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ApplicationDbContext _context;

        public PostService(IPostRepository postRepository, ApplicationDbContext context)
        {
            _postRepository = postRepository;
            _context = context;
        }

        public async Task<ServiceResponse<Post>> GetPost(int postId)
        {
            var postExist = await _postRepository.GetPostByIdAsync(postId);
            if (postExist == null) return ServiceResponse<Post>.ErrorResponse("Post not found");
            return ServiceResponse<Post>.SuccessResponse(postExist, "Post found");
        }

        public async Task<ServiceResponse<IEnumerable<Post>>> GetPosts(string userId)
        {
            try
            {
                var posts = await _postRepository.GetPostsAsync(userId);
                return ServiceResponse<IEnumerable<Post>>.SuccessResponse(posts, "Post found");
            }
            catch (Exception e)
            {
                return ServiceResponse<IEnumerable<Post>>.ErrorResponse("'GetPosts' is wrong");

            }

        }

        public async Task<ServiceResponse<string>> CreatePost(Post post)
        {
            await _postRepository.CreatePostAsync(post);
            return ServiceResponse<string>.SuccessResponse("Success", "Post found");
        }

        public async Task<ServiceResponse<bool>> DeletePost(string postId)
        {
            try
            {
                var post = await _postRepository.GetPostByIdAsync(Int32.Parse(postId));
                await _postRepository.DeletePostAsync(post);
                return ServiceResponse<bool>.SuccessResponse(true, "Post deleted");
            }
            catch (Exception e)
            {
                return ServiceResponse<bool>.ErrorResponse("Delete post failed");
            }
        }

        public async Task<ServiceResponse<bool>> UpdatePost(Post post)
        {
            var postExist = await _postRepository.GetPostByIdAsync(post.Id);
            if (post == null) return ServiceResponse<bool>.ErrorResponse("Post not found");

            postExist.Content = post.Content;
            postExist.ImageUrl = post.ImageUrl;

            await _postRepository.UpdatePostAsync(postExist);
            return ServiceResponse<bool>.SuccessResponse(true, "Post updated");

        }
    }
}
