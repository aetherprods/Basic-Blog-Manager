using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shared_classes.Models;

namespace webapp.Services
{
    public class PostMemoryService : IPostService<IBlogService>
    {
        private readonly IBlogService _blogService;
        private readonly List<PostModel> _posts = new List<PostModel>();
        public PostMemoryService(IBlogService blogService)
        {
            this._blogService = blogService;

            _posts.Add(new PostModel {AuthorId = 1, BlogModelId = 0, Id = 1, Title = "How to Eat Scromps", Text = "This is how you eat scrumps", TimePosted = DateTime.Now});
            _posts.Add(new PostModel {AuthorId = 2, BlogModelId = 0, Id = 1, Title = "How to Make Scobies", Text = "This is how you make scobies", TimePosted = DateTime.Now});
        }
        public Task<IEnumerable<PostModel>> GetAll(int blogId)
        {
            return Task.Run(() => 
                from post in _posts
                where post.BlogModelId == blogId
                select post
                );
        }
        public Task<PostModel> GetById(int postId)
        {
            return Task.Run(() => _posts.Find(p => p.Id == postId));
        }
        public Task Add(PostModel post)
        {
            post.Id = _posts.Max(p => p.Id) + 1;
            post.TimePosted = DateTime.Now;
            _posts.Add(post);

            return Task.CompletedTask;
        }
        public Task Update(PostModel post)
        {
            return Task.Run(() => {var _post = _posts.Find(p => p.Id == post.Id);_post = post;});
        }
        public Task Delete(PostModel post)
        {
            return Task.Run(() => _posts.Remove(_posts.Find(p => p.Id == post.Id)));
        }

    }
}