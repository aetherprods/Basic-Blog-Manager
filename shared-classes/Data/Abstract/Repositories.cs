using System.Collections.Generic;
using shared_classes.Models;

namespace shared_classes.Data
{
    public interface IBlogRepository : IEntityBaseRepository<BlogModel> { }
    public interface IPostRepository : IEntityBaseRepository<PostModel>
    {
        IEnumerable<PostModel> GetAll(int blogId);
    }
    public interface ICommentRepository : IEntityBaseRepository<CommentModel> { }

}