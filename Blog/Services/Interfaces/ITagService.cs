using Blog.Models.Entities;

namespace Blog.Services.Interfaces
{
    public interface ITagService : IService<Tag>
    {
        Task<ICollection<Post>> GetPostsByTagIdAsync(int id);
        Task<ICollection<Post>> GetPublishedPostsByTagIdAsync(int id);
        string GetFullUrl(Tag tag);
        Task<int> CountSubmittedPostsByTagIdAsync(int id);
        Task<int> CountPublishedPostsByTagIdAsync(int id);
    }
}