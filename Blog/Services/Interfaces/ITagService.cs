using Blog.Models.Entities;
using Blog.Models.ViewModels;

namespace Blog.Services.Interfaces
{
    public interface ITagService : IService<Tag>
    {
        Task CreateTagAsync(TagCreateEditViewModel viewModel);
        Task UpdateTagAsync(TagCreateEditViewModel viewModel);
    }
}
