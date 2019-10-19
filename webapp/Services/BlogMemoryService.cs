using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shared_classes.Models;
using webapp.Services;

namespace webapp.Services
{
    public class BlogMemoryService : IBlogService
    {
        public List<BlogModel> Blogs { get; set; }
        
        public BlogMemoryService()
        {
            Blogs = new List<BlogModel> { };
            Blogs.Add(new BlogModel {ID = 1, AuthorID = 1, Name = "The Scromps", DateStarted = DateTime.Now});
            Blogs.Add(new BlogModel {ID = 2, AuthorID = 2, Name = "The Scobies", DateStarted = DateTime.Now});
        }
        public Task Add(BlogModel blog)
        {
            blog.ID = Blogs.Max(b => b.ID) + 1;
            blog.DateStarted = DateTime.Now;
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
    }
}