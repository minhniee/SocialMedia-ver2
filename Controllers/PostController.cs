using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using SocialMedia.Service;

namespace SocialMedia.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
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
                   UserId = "ebbf62d6-adae-4f98-87dd-48a35a6c7c63"
               };
            _postService.CreatePost(post);
            return post.ToString();
        }
    }
}
