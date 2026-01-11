using Blog.Models.Entities;
using Blog.Models.ViewModels;
using Blog.Services;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

        public async Task<IActionResult> ShowAllCategories()
        {
            IEnumerable<Category> categories = await _categoryService.GetAllAsync();
            var categoriesViewModel = new List<CategoryListDetailViewModel>();
            foreach (var category in categories)
            {
                var categoryViewModel = new CategoryListDetailViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    PostCount = await _categoryService.CountPublishedPostsByCategoryIdAsync(category.Id)
                };

                categoriesViewModel.Add(categoryViewModel);
            }
            return View(categoriesViewModel);
        }

        public async Task<IActionResult> ShowCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            var viewModel = new CategoryListDetailViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                PostCount = await _categoryService.CountPublishedPostsByCategoryIdAsync(category.Id),
                Posts = await _categoryService.GetPublishedPostsByCategoryIdAsync(id)
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Create() => View(new CategoryCreateEditViewModel());

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateEditViewModel viewModel)
        {
            var category = new Category
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description
            };
            await _categoryService.CreateAsync(category);
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            var viewModel = new CategoryCreateEditViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryCreateEditViewModel viewModel)
        {
            var category = new Category
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            };
            await _categoryService.UpdateAsync(category);
            return View();
        }

        [HttpPost]
        public async Task<int> Delete(int id) => await _categoryService.DeleteByIdAsync(id);
    }
}
