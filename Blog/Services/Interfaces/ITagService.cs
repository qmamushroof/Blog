using Blog.Models.Entities;
using Blog.Models.ViewModels;

namespace Blog.Services.Interfaces
{
    public interface ITagService
    {
        Task<Tag> GetTagByIdAsync(int id);
        Task<Tag> GetTagBySlugAsync(string slug);
        
        Task CreateTagAsync(TagCreateEditViewModel viewModel);
        Task UpdateTagAsync(TagCreateEditViewModel viewModel);        
        Task DeleteTagByIdAsync(int id);
    }
}
