using System;
using System.Collections.Generic;
using shared_classes.Models;

namespace shared_classes.Data
{
    public class BlogRepository : EntityBaseMemoryRepository<BlogModel>, IBlogRepository
    {
        public BlogRepository(ICollection<BlogModel> collection) : base(collection) 
        {
            collection.Add(new BlogModel {Id = 1, AuthorId = 1, Name = "The Scromps", DateStarted = DateTime.Now});
            collection.Add(new BlogModel {Id = 2, AuthorId = 2, Name = "The Scobies", DateStarted = DateTime.Now});
        }
    }
}