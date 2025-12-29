using Blog.Models.Entities;
using Blog.Services.Interfaces;

namespace Blog.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _uploadPath = $"uploads/blog/posts";

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
            var absolutePath = Path.Combine(_environment.WebRootPath, _uploadPath);
            Directory.CreateDirectory(absolutePath);
        }

        public async Task<string?> UploadHeaderImageAsync(IFormFile file, Post post, string? existingUrl = null)
        {
            if (!string.IsNullOrEmpty(existingUrl) && file != null)
                await DeleteFileAsync(existingUrl);

            if (file == null || file.Length == 0) return existingUrl;

            var fileName = DateTime.UtcNow.ToString() + post.Id + post.Title;
            var filePath = Path.Combine(_environment.WebRootPath, _uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/{_uploadPath}/{fileName}";
        }

        public Task DeleteFileAsync(string fileUrl)
        {
            throw new NotImplementedException();
        }
    }
}