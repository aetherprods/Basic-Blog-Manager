using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using shared_classes.Data;
using shared_classes.Models;

namespace webapi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var blogs = _blogRepository.GetAll();
            if (!blogs.Any())
                return new NoContentResult();

            return new ObjectResult(blogs);
        }

        [HttpGet("{id}", Name = "GetBlogById")]
        public BlogModel GetById(int id)
        {
            return _blogRepository.GetById(id);
        }

        [HttpPost]
        public IActionResult Add([FromBody]BlogModel blog)
        {
            blog.DateStarted = DateTime.Now;
            _blogRepository.Add(blog);
            _blogRepository.Commit();

            return CreatedAtRoute("GetBlogById", new { id = blog.Id }, blog);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]BlogModel blog)
        {
            _blogRepository.Delete(blog);
            return GetAll();
        }
    }
}