using Blog.Models.Entities;

namespace Blog.Services.Interfaces
{
    public interface IFileService
    {
        Task<string?> UploadImageAsync(IFormFile file, string? existingUrl = null);
        Task DeleteFileAsync(string? fileUrl);
    }
}