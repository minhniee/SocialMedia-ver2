using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;

namespace SocialMedia.Repositories
{

    public class PostRepository : IPostRepository
    {

        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            _context.SaveChanges();
            return post;
        }

        public async Task<bool> DeletePostAsync(Post post)
        {
            _context.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<IEnumerable<Post>> GetPostsAsync(string userId)
        {
            return await _context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
