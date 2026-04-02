using Mini_drive.Models;

namespace Mini_drive.Repositories.IRepositories
{
    public interface IFilerepository
    {
        Task<FilesModel> UpdateFileAsync(FilesModel file);
        Task<FilesModel> CreateFileAsync(FilesModel file);
        Task<FilesModel?> GetFileByTipoAsync(string Extensao);
        Task<FilesModel> GetFileByIdAsync(Guid id);
        Task<List<FilesModel>> GetAllFilesAsync();
        Task DeleteFilesAsync(Guid id);
        Task<FilesModel> GetFileByNomeAsync(string NoNomeDoArquivo);
        Task<FilesModel> DownloadFilesAsync(Guid id);
    }
}
