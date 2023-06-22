using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DoAnThucTap.Services
{
    public interface IStorageService
    {
        Task<string> SaveFileAsync(IFormFile file, string filePath);
        Task<string> UpdateFileAsync(IFormFile file, string existingFilePath, string filePath);
        Task DeleteFileAsync(string filePath);
    }
}
