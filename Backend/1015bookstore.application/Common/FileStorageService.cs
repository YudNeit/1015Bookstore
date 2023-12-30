using Microsoft.AspNetCore.Hosting;

namespace _1015bookstore.application.Common
{
    public class FileStorageService : IStorageService
    {
        private readonly string _userContentFolderWeb;
        private readonly string _userContentFolderWebAdmin;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _userContentFolderWeb = Path.Combine("../../Frontend/src/assets/", USER_CONTENT_FOLDER_NAME);
            _userContentFolderWebAdmin = Path.Combine("../1015bookstore.webadmin/wwwroot/img/", USER_CONTENT_FOLDER_NAME);
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{USER_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_userContentFolderWeb, fileName);
            using var output1 = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output1);

            filePath = Path.Combine(_userContentFolderWebAdmin, fileName);
            using var output2 = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output2);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_userContentFolderWeb, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
            filePath = Path.Combine(_userContentFolderWebAdmin, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}
