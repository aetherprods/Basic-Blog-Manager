using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using shared_classes.Models;

namespace shared_classes.Data
{
    public class PostMemoryRepository : EntityBaseMemoryRepository<PostModel>, IPostRepository
    {
        private ICollection<PostModel> _posts = new Collection<PostModel>();
        public PostMemoryRepository(ICollection<PostModel> posts) : base(posts) 
        {
            _posts = posts;
            
            _posts.Add(new PostModel {AuthorId = 1, BlogId = 1, Id = 1, Title = "How to Eat Scromps", Text = "This is how you eat scrumps", TimePosted = DateTime.Now});
            _posts.Add(new PostModel {AuthorId = 2, BlogId = 2, Id = 1, Title = "How to Make Scobies", Text = "This is how you make scobies", TimePosted = DateTime.Now});
        }
    }
}