using System.Collections.Generic;
using System.Threading.Tasks;
using shared_classes.Models;

namespace webapp.Services
{
    public interface IPostService<IBlogService>
    {
        Task<IEnumerable<PostModel>> GetAll(int blogId);
        Task<PostModel> GetById(int postId);
        Task Add(PostModel post);
        Task Update(PostModel post);
        Task Delete(PostModel post);
    }
}