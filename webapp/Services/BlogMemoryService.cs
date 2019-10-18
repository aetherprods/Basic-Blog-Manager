using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using class_lib.Models;

namespace webapp.Services
{
    public class BlogMemoryService : IBlogService
    {
        private readonly List<BlogModel> Blogs = new List<BlogModel>();
        private readonly List<PostModel> FirstsPost = new List<PostModel>();
        private readonly List<PostModel> SecondsPost = new List<PostModel>();

        public BlogMemoryService()
        {
            FirstsPost.Add(new PostModel {ID = 1, AuthorID = 1, BlogID = 1, Text = "This is the first test post", Title = "First Post", TimePosted = DateTime.Now});
            SecondsPost.Add(new PostModel {ID = 2, AuthorID = 2, BlogID = 2, Text = "This is the second test post", Title = "Second Post", TimePosted = DateTime.Now});
            Blogs.Add(new BlogModel {ID = 1, AuthorID = 1, Name = "The Scromps", Posts = FirstsPost});
            Blogs.Add(new BlogModel {ID = 2, AuthorID = 2, Name = "The Scobies", Posts = SecondsPost});
        }

        public Task Add(BlogModel blog)
        {
            blog.ID = Blogs.Max(b => b.ID) + 1;
            Blogs.Add(blog);

            return Task.CompletedTask;
        }
        public Task<IEnumerable<BlogModel>> GetAll()
        {
            return Task.Run(() => Blogs.AsEnumerable());
        }

        public Task<BlogModel> GetById(int id)
        {
            return Task.Run(() => Blogs.First(b => b.ID==id));
        }

        public Task<BlogModel> GetByAuthorId(int author)
        {
            return Task.Run(() => Blogs.Find(b => b.AuthorID==author));
        }
    }
}