using shared_classes.Models;

namespace shared_classes.Data
{
    public interface IBlogRepository : IEntityBaseRepository<BlogModel> { }
    public interface IPostRepository : IEntityBaseRepository<PostModel> { }
    public interface ICommentRepository : IEntityBaseRepository<CommentModel> { }

}