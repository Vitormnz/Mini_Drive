using Mini_drive.Models;

namespace Mini_drive.Repositories.IRepositories
{
    public interface IFilerepository
    {
        Task<Files> UpdateFileAsync(Files file);
        Task<Files> CreateFileAsync(Files file);
        Task<Files?> GetFileByIdAsync(Guid id);
        Task<List<Files>> GetAllFilesAsync();
        Task DeleteFilesAsync(Guid id);

    }
}
