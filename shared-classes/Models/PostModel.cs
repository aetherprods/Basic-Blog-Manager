using System;
using System.Collections.Generic;

namespace shared_classes.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime TimePosted { get; set; }
        //public IEnumerable<CommentModel> Comments { get; set; }
    }
}
