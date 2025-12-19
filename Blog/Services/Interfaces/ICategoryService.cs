using Blog.Models.Entities;
using Blog.Models.ViewModels;

namespace Blog.Services.Interfaces
{
    public interface ICategoryService : IService<Category>
    {       
        Task CreateCategoryAsync(CategoryCreateEditViewModel viewModel);
        Task UpdateCategoryAsync(CategoryCreateEditViewModel viewModel);        
    }
}
