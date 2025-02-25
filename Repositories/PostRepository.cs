using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;

namespace SocialMedia.Repositories
{

    public class PostRepository : IPostRepository
    {

        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context )
        {
            _context = context;
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
          await  _context.Posts.AddAsync(post);
           _context.SaveChanges();
        return post;

        }

        public async Task<bool> DeletePostAsync(Post post)
        {
            var postExitst = _context.Posts.Find(post.Id);
            if (postExitst != null)
            {
                 _context.Remove(postExitst);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            var postExitst =  _context.Posts.Find(id);
            if (postExitst == null) return null;
            return  postExitst;

        }

        public async Task<IEnumerable<Post>> GetPostsAsync(int userId)
        {
            return await _context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .Where(p => p.UserId == userId.ToString())
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            var postExist = await _context.Posts.FindAsync(post.Id);
            if(postExist != null)
            {
                postExist.Content = post.Content;
                postExist.ImageUrl = post.ImageUrl;

                _context.Posts.Update(postExist);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
