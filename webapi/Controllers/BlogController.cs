using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}", Name = "GetById")]
        public BlogModel GetById(int id)
        {
            return _blogRepository.GetById(id);
        }

        [HttpPost]
        public IActionResult Add([FromBody]BlogModel blog)
        {
            _blogRepository.Add(blog);
            _blogRepository.Commit();

            return CreatedAtRoute("GetById", new { id = blog.Id }, blog);
        }

        //[HttpPost]
        public IActionResult Delete([FromBody]BlogModel blog)
        {
            _blogRepository.Delete(blog);
            return GetAll();
        }
    }
}