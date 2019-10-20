using System;
using System.Collections.Generic;

namespace shared_classes.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime DateStarted { get; set; }
        //public IEnumerable<PostModel> Posts { get; set; }
        //because of the way we are setting up "IBlogService" and "IPostService" (as per the tutorials instructions),
        //our BlogModel does not have to know anything about its Posts. Rather, the Posts themselves will necessitate a
        //BlogId. 
    }
}
