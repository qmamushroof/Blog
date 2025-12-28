using Blog.Models.Entities;

namespace Blog.Services.Interfaces
{
    public interface IFileService
    {
        Task<string?> UploadHeaderImageAsync(IFormFile file, Post post, string? existingUrl = null);
        Task DeleteFileAsync(string fileUrl);
    }
}