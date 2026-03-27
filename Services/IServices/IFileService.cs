using Mini_drive.Models;

namespace Mini_drive.Services.IServices
{
    public interface IFileService
    {
        Task<FilesModel> UpdateFiles(Guid id);
        Task<FilesModel> CreateFilesAsync(FilesModel file);

        Task<FilesModel> DeleteFilesAsync(Guid id);
        Task<FilesModel> GetFilesAsync(Guid id);
        Task<List<FilesModel>> GetAllFilesAsync();
    }
}
