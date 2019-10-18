using System.Collections.Generic;
using System.Threading.Tasks;
using class_lib.Models;

namespace webapp.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogModel>> GetAll();
        Task<BlogModel> GetById(int id);
        Task<BlogModel> GetByAuthorId(int id);
        Task Add(BlogModel blog);
    }
}