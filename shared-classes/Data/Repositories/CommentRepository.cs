using System.Collections.Generic;
using shared_classes.Models;

namespace shared_classes.Data
{
    public class CommentRepository : EntityBaseMemoryRepository<CommentModel>, ICommentRepository
    {
        public CommentRepository(ICollection<CommentModel> list) : base(list) { }
    }
}