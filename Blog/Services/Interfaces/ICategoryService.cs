using Blog.Models.Entities;
using Blog.Models.ViewModels;

namespace Blog.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> GetCategoryBySlugAsync(string slug);
        
        Task CreateCategoryAsync(CategoryCreateEditViewModel viewModel);
        Task UpdateCategoryAsync(CategoryCreateEditViewModel viewModel);
        
        Task DeleteCategoryByIdAsync(int id);
    }
}
