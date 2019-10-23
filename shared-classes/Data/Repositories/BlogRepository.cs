using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using shared_classes.Models;

namespace shared_classes.Data
{
    public class BlogRepository : EntityBaseRepository<BlogModel>, IBlogRepository
    {
        private BlogDbContext _context;
        public BlogRepository(BlogDbContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<BlogModel> GetAll()
        {
            return _context.Set<BlogModel>().Include(b => b.Posts);
        }

        public override BlogModel GetById(int blogId)
        {
            return _context.Set<BlogModel>().Include(b => b.Posts).FirstOrDefault(b => b.Id==blogId);
        }
    }
}