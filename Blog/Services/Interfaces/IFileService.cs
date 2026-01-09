using Blog.Models.Entities;

namespace Blog.Services.Interfaces
{
    public interface IFileService
    {
        Task<string?> UploadHeaderImageAsync(IFormFile file, Post? post = null, string? existingUrl = null);
        Task<string?> UploadContentImageAsync(IFormFile file, Post? post = null);
        Task DeleteFileAsync(string? fileUrl);
    }
}