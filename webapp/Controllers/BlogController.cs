using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using webapp.Services;
using shared_classes.Models;

namespace webapp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService blog;

        public BlogController(IBlogService blog)
        {
            this.blog = blog;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Blogs Overview";
            return View(await blog.GetAll());
        }

        public IActionResult Add()
        {
            ViewBag.Title = "Add Conference";
            return View(new BlogModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(BlogModel model)
        {   
            if (ModelState.IsValid)
                await this.blog.Add(model);

            return RedirectToAction("Index");
        }
    }
}