using Mini_drive.Models;
using Mini_drive.Repositories.IRepositories;
using Mini_drive.Services.IServices;

namespace Mini_drive.Services
{
    public class FileService : IFileService
    {
        private readonly IFilerepository _fileRepository;

        public FileService(IFilerepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<List<FilesModel>> GetAllFilesAsync()
        {
            return await _fileRepository.GetAllFilesAsync();
        }

        public async Task<FilesModel> GetFilesByIdAsync(Guid id)
        {
            return await _fileRepository.GetFileByIdAsync(id);
        }

        public async Task<FilesModel> GetFilesByTipoAsync(string Extensao)
        {
            return await _fileRepository.GetFileByTipoAsync(Extensao);
        }

        public async Task DeleteFilesAsync(Guid id)
        {
            await _fileRepository.DeleteFilesAsync(id);
        }

        public async Task<FilesModel> CreateFilesAsync(FilesModel file)
        {
            return await _fileRepository.CreateFileAsync(file);
        }

        public async Task<FilesModel> UpdateFiles(Guid id, IFormFile file)
        {
            var existingFile = await _fileRepository.GetFileByIdAsync(id);

            if (existingFile == null)
                throw new Exception("Arquivo não encontrado");

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            existingFile.NomeDoArquivo = file.FileName;
            existingFile.Extensao = Path.GetExtension(file.FileName);
            existingFile.TipoMime = file.ContentType;
            existingFile.Tamanho = file.Length;
            existingFile.DataUpload = DateTime.UtcNow;
            existingFile.ArquivoByte = memoryStream.ToArray();

            return await _fileRepository.UpdateFileAsync(existingFile);
        }

        public async Task<FilesModel> UploadFileAsync(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var fileModel = new FilesModel
            {
                Id = Guid.NewGuid(),
                NomeDoArquivo = file.FileName,
                Extensao = Path.GetExtension(file.FileName),
                TipoMime = file.ContentType,
                Tamanho = file.Length,
                DataUpload = DateTime.UtcNow,
                ArquivoByte = memoryStream.ToArray()
            };

            return await _fileRepository.CreateFileAsync(fileModel);
        }
    }

}