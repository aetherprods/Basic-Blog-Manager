using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace shared_classes.Models
{
    public class BlogModel : IEntityBase
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateStarted { get; set; }
        public IEnumerable<PostModel> Posts { get; set; }
        
    }
}