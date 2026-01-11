using Blog.Models.Entities;
using Blog.Models.ViewModels;
using Blog.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService) => _tagService = tagService;

        public async Task<IActionResult> ShowAllCategories()
        {
            IEnumerable<Tag> tags = await _tagService.GetAllAsync();
            var tagsViewModel = new List<TagListDetailViewModel>();
            foreach (var tag in tags)
            {
                var tagViewModel = new TagListDetailViewModel
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Description = tag.Description,
                    PostCount = await _tagService.CountPublishedPostsByTagIdAsync(tag.Id)
                };

                tagsViewModel.Add(tagViewModel);
            }
            return View(tagsViewModel);
        }

        public async Task<IActionResult> ShowCategory(int id)
        {
            var tag = await _tagService.GetByIdAsync(id);
            var viewModel = new TagListDetailViewModel
            {
                Id = tag.Id,
                Name = tag.Name,
                Description = tag.Description,
                PostCount = await _tagService.CountPublishedPostsByTagIdAsync(tag.Id),
                Posts = await _tagService.GetPublishedPostsByTagIdAsync(id)
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Create() => View(new TagCreateEditViewModel());

        [HttpPost]
        public async Task<IActionResult> Create(TagCreateEditViewModel viewModel)
        {
            var tag = new Tag
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description
            };
            await _tagService.CreateAsync(tag);
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tag = await _tagService.GetByIdAsync(id);

            var viewModel = new TagCreateEditViewModel
            {
                Id = tag.Id,
                Name = tag.Name,
                Description = tag.Description
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TagCreateEditViewModel viewModel)
        {
            var tag = new Tag
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            };
            await _tagService.UpdateAsync(tag);
            return View();
        }

        [HttpPost]
        public async Task<int> Delete(int id) => await _tagService.DeleteByIdAsync(id);
    }
}
