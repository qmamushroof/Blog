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
            string absolutePath = Path.Combine(_environment.WebRootPath, _uploadPath);
            Directory.CreateDirectory(absolutePath);
        }

        public async Task<string?> UploadHeaderImageAsync(IFormFile file, Post? post = null, string? existingUrl = null)
        {
            if (!string.IsNullOrEmpty(existingUrl) && file != null)
                await DeleteFileAsync(existingUrl);

            if (file == null || file.Length == 0) return existingUrl;

            string fileName = DateTime.UtcNow.ToString() + post!.Id! + post!.Title! + Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(_environment.WebRootPath, _uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/{_uploadPath}/{fileName}";
        }

        public Task DeleteFileAsync(string? fileUrl)
        {
            throw new NotImplementedException();
        }
    }
}