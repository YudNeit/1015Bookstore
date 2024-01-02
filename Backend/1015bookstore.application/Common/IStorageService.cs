namespace _1015bookstore.application.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);

        Task SaveFileAsyncFE_user(Stream mediaBinaryStream, string fileName);
        Task SaveFileAsyncFE_admin(Stream mediaBinaryStream, string fileName);

        Task DeleteFileAsync(string fileName);
    }
}
