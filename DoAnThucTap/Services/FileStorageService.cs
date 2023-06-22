using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DoAnThucTap.Services
{
    public class FileStorageService : IStorageService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileStorageService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string filePath)
        {
            var fileNameUnique = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(file.FileName);
            var path = Path.Combine(_hostingEnvironment.WebRootPath, filePath, fileNameUnique);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine(filePath, fileNameUnique);
        }

        public async Task<string> UpdateFileAsync(IFormFile file, string existingFilePath, string filePath)
        {
            if (file == null)
            {
                return existingFilePath;
            }

            await DeleteFileAsync(existingFilePath);
            return await SaveFileAsync(file, filePath);
        }

        public async Task DeleteFileAsync(string filePath)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, filePath);

            if (File.Exists(path))
            {
                await Task.Run(() => File.Delete(path));
            }
        }
    }
}
