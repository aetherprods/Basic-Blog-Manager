using System.Collections.Generic;
using System.Threading.Tasks;
using class_lib.Models;

namespace webapp.Services
{
    public interface IPostService<BlogModel>
    {
        Task<IEnumerable<PostModel>> GetAll(int blogId);
        Task<PostModel> Read(int postId);
        Task Add(PostModel post);
        Task Update(PostModel post);
        Task Delete(PostModel post);
    }
}