using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using SocialMedia.Service;

namespace SocialMedia.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly UserManager<ApplicationUser> _manager;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string CreatePost(string content)
        {

            Post post = new Post()
            {

                ImageUrl = "this is img",
                Content = content,
                CreatedAt = DateTime.Now,
                UserId = "4f47fc45-ef6f-4026-965b-48c8c3b3ae4f"
            };
            _postService.CreatePost(post);
            return post.ToString();
        }

        [HttpGet]
        public async Task<List<string>> GetPostsByUserId(string userId)
        {
            var posts = await _postService.GetPosts(userId);
            var data = posts.Data.Select(p => p.ToString()).ToList();

            return data;
        }

        [HttpGet]
        public async Task<string> DeletePostsById(string id)
        {
            var post = _postService.DeletePost(id);

            return post.Result.Success ? "Post deleted" : "Post not found";
        }
    }
}
