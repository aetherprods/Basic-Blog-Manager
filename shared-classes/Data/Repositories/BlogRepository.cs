using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using shared_classes.Models;

namespace shared_classes.Data
{
    public class BlogRepository : EntityBaseRepository<BlogModel>, IBlogRepository
    {
        public BlogRepository(BlogDbContext context) : base(context) { }
    }
}