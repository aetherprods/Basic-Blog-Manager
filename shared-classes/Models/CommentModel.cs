using System;

namespace shared_classes.Models
{
    public class CommentModel
    {
        public CommentModel()
        {
            TimePosted = DateTime.Now;
        }
        public int ID { get; set; }
        public int PostID { get; set; }
        public int AuthorID { get; set; }
        public string Text { get; set; }
        public DateTime TimePosted { get; set; }

    }
}
