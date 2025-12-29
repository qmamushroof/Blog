using Blog.Models.Entities;
using Blog.Models.Enums;

namespace Blog.Services.Interfaces
{
    public interface ICategoryService : IService<Category>
    {
        Task<ICollection<Post>> GetPostsByCategoryId(int id);
    }
}