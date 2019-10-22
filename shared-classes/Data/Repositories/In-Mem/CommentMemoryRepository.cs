using System.Collections.Generic;
using System.Collections.ObjectModel;
using shared_classes.Models;

namespace shared_classes.Data
{
    public class CommentMemoryRepository : EntityBaseMemoryRepository<CommentModel>, ICommentRepository
    {
        private ICollection<CommentModel> _comments = new Collection<CommentModel>();
        public CommentMemoryRepository(ICollection<CommentModel> comments) : base(comments)
        {
            _comments = comments;
        }
    }
}