using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shared_classes.Models;
using webapp.Services;

namespace webapp.Controllers
{
    public class PostController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IPostService<IBlogService> _postService;

        public PostController(IBlogService blogService, IPostService<IBlogService> postService)
        {
            this._blogService = blogService;
            this._postService = postService;
        }

        public async Task<IActionResult> Index(int blogId)
        {
            var blog = await _blogService.GetById(blogId);
            ViewBag.BlogId = blogId;
            ViewBag.Title = $"{blog.Name}'s Posts";
            
            return View(await _postService.GetAll(blogId));
        }

        public IActionResult Add(int blogId)
        {
            ViewBag.Title = "Add Post";
            return View(new PostModel {BlogId = blogId});
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostModel post)
        {
            if (ModelState.IsValid)
                await _postService.Add(post);
            
            return RedirectToAction("Index", new {blogId = post.BlogId});
        }
    }
}