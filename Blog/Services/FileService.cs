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

        public async Task<string?> UploadImageAsync(IFormFile file, string? existingUrl = null)
        {
            if (file is null || file.Length == 0) return existingUrl;

            if (!file.ContentType.StartsWith("image/")) throw new ArgumentException("Only images allowed.");
            if (file.Length > 5 * 1024 * 1024) throw new ArgumentException("Max limit is 5 MB.");

            if (!string.IsNullOrEmpty(existingUrl) && file != null) await DeleteFileAsync(existingUrl);

            string fileName = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss") + Guid.NewGuid() + Path.GetExtension(file!.FileName);
            string filePath = Path.Combine(_environment.WebRootPath, _uploadPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/{_uploadPath}/{fileName}";
        }

        public async Task DeleteFileAsync(string? fileUrl)
        {
            if (!string.IsNullOrEmpty(fileUrl))
            {
                string filePath = Path.Combine(_environment.WebRootPath, fileUrl.TrimStart('/'));
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}