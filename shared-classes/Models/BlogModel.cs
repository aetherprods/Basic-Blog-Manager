using System.Collections.Generic;

namespace shared_classes.Models
{
    public class BlogModel
    {
        public int ID { get; set; }
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public IEnumerable<PostModel> Posts { get; set; }
    }
}
