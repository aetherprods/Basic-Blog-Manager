using System;
using System.ComponentModel.DataAnnotations;

namespace shared_classes.Models
{
    public class CommentModel : IEntityBase
    {
        public CommentModel()
        {
            TimePosted = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime TimePosted { get; set; }

    }
}
