using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using shared_classes.Models;

namespace shared_classes.Data
{
    public class PostRepository : EntityBaseRepository<PostModel>, IPostRepository
    {
        public PostRepository(BlogDbContext context) : base(context) { }
    }
}