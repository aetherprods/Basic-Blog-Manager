using System;
using System.Collections.Generic;
using shared_classes.Models;

namespace shared_classes.Data
{
    public class PostRepository : EntityBaseMemoryRepository<PostModel>, IPostRepository
    {
        public PostRepository(ICollection<PostModel> collection) : base(collection) 
        {
            collection.Add(new PostModel {AuthorId = 1, BlogId = 1, Id = 1, Title = "How to Eat Scromps", Text = "This is how you eat scrumps", TimePosted = DateTime.Now});
            collection.Add(new PostModel {AuthorId = 2, BlogId = 2, Id = 1, Title = "How to Make Scobies", Text = "This is how you make scobies", TimePosted = DateTime.Now});
        }
    }
}