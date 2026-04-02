using Mini_drive.Models;

namespace Mini_drive.Services.IServices
{
    public interface IFileService
    {
        Task<FilesModel> UpdateFiles(Guid id, IFormFile file);
        Task<FilesModel> CreateFilesAsync(FilesModel file);

        Task DeleteFilesAsync(Guid id);
        Task<FilesModel> GetFilesByTipoAsync(string Extensao);
        Task<FilesModel> GetFilesByIdAsync(Guid id);
        Task<List<FilesModel>> GetAllFilesAsync();
        Task<FilesModel> UploadFileAsync(IFormFile file);
        Task<FilesModel> DownloadFileAsync(Guid id);
        Task<FilesModel> GetFilesByNameAsync(string NoNomeDoArquivo);
    }
}
