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
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        [HttpGet]
        public IActionResult GetAll(int blogId)
        {
            var posts = _postRepository.GetAll(blogId);
            if (!posts.Any())
                return new NoContentResult();
            
            return new ObjectResult(posts);
        }

        [HttpGet("{id}", Name = "GetPostById")]
        public PostModel GetById(int id)
        {
            return _postRepository.GetById(id);
        }

        [HttpPost]
        public IActionResult Add([FromBody]PostModel post)
        {
            post.TimePosted = DateTime.Now;
            _postRepository.Add(post);
            _postRepository.Commit();

            return CreatedAtRoute("GetPostById", new { id = post.Id }, post);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]PostModel post)
        {
            _postRepository.Delete(post);
            return GetAll(post.BlogModelId);
        }
    }
}