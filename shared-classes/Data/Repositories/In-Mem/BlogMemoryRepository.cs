using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using shared_classes.Models;

namespace shared_classes.Data
{
    public class BlogMemoryRepository : EntityBaseMemoryRepository<BlogModel>, IBlogRepository
    {
        private List<BlogModel> _collection = new List<BlogModel>();
        public BlogMemoryRepository(List<BlogModel> collection) : base(collection) 
        {
            _collection = collection;

            _collection.Add(new BlogModel {Id = 1, AuthorId = 1, Name = "The Scromps", DateStarted = DateTime.Now});
            _collection.Add(new BlogModel {Id = 2, AuthorId = 2, Name = "The Scobies", DateStarted = DateTime.Now});
        }
    }
}