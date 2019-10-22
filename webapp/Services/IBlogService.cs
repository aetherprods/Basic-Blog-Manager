using System.Collections.Generic;
using System.Threading.Tasks;
using shared_classes.Models;

namespace webapp.Services
{
    public interface IBlogService
    {
        //List<BlogModel> Blogs { get; }
        Task<IEnumerable<BlogModel>> GetAll();
        Task<BlogModel> GetById(int id);
        Task Add(BlogModel blog);
    }
}