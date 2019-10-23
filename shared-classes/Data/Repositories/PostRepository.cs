using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using shared_classes.Models;

namespace shared_classes.Data
{
    public class PostRepository : EntityBaseRepository<PostModel>, IPostRepository
    {
        private BlogDbContext _context;
        public PostRepository(BlogDbContext context) : base(context) 
        {
            _context = context;
        }
        public IEnumerable<PostModel> GetAll(int blogId)
        {
            var posts = _context.Posts.Where(p => p.BlogModelId == blogId);
            return posts;
        }
    }
}