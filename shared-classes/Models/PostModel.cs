using System;
using System.Collections.Generic;

namespace shared_classes.Models
{
    public class PostModel
    {
        public int ID { get; set; }
        public int BlogID { get; set; }
        public int AuthorID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime TimePosted { get; set; }
        //public IEnumerable<CommentModel> Comments { get; set; }
    }
}
