using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace shared_classes.Models
{
    public class PostModel : IEntityBase
    {
        public int Id { get; set; }
        [Required]
        public int BlogModelId { get; set; }
        public int AuthorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime TimePosted { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }
    }
}
