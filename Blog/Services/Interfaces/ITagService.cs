using Blog.Models.Entities;

namespace Blog.Services.Interfaces
{
    public interface ITagService : IService<Tag>
    {
        Task<ICollection<Post>> GetPostsByTagIdAsync(int id);
        string GetFullUrl(Tag tag);
    }
}