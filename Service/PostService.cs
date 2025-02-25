using SocialMedia.Models;
using SocialMedia.Repositories;

namespace SocialMedia.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<string> CreatePost(Post post)
        {
            var result = await _postRepository.CreatePostAsync(post);
            return result.Content;
        }

        public Task<string> DeletePost(string postId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPost(string postId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetPosts(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdatePost(string postId)
        {
            throw new NotImplementedException();
        }
    }
}
