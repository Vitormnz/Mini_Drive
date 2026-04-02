using Mini_drive.Repositories.IRepositories;
using Mini_drive.Models;
using Mini_drive.Data;
using Microsoft.EntityFrameworkCore;

namespace Mini_drive.Repositories
{
    public class FileRepository : IFilerepository
    {
        private readonly AppDbContext _context;

        public FileRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<FilesModel>> GetAllFilesAsync()
        {
            return await _context.Files.ToListAsync();
        }
        public async Task<FilesModel?> GetFileByTipoAsync(string Extensao)
        {
            return await _context.Files
                .FirstOrDefaultAsync(f => f.Extensao == Extensao);
        }

        public async Task<FilesModel?> GetFileByIdAsync(Guid id)
        {
            return await _context.FindAsync<FilesModel>(id);
        }

        public async Task<FilesModel?> GetFileByNomeAsync(string NomeDoArquivo)
        {
            return await _context.Files
                .FirstOrDefaultAsync(f => f.NomeDoArquivo == NomeDoArquivo);
        }

        public async Task<FilesModel> CreateFileAsync(FilesModel file)
        {
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<FilesModel> UpdateFileAsync(FilesModel file)
        {
            var existingFile = await _context.Files.FindAsync(file.Id);
            if (existingFile == null)
            {
                throw new Exception("Arquivo não encontrado");
            }
            existingFile.NomeDoArquivo = file.NomeDoArquivo;
            existingFile.Extensao = file.Extensao;
            existingFile.TipoMime = file.TipoMime;
            existingFile.Tamanho = file.Tamanho;
            existingFile.DataUpload = file.DataUpload;
            existingFile.ArquivoByte = file.ArquivoByte;
            _context.Files.Update(existingFile);
            await _context.SaveChangesAsync();
            return existingFile;
        }

        public async Task<FilesModel> DownloadFilesAsync(Guid id)
        {
            var file = await _context.Files
                .FirstOrDefaultAsync(f => f.Id == id);

            if (file == null)
                throw new Exception("Arquivo não encontrado");

            return file;
        }

        public async Task DeleteFilesAsync(Guid id)
        {
            var file = await _context.Files.FindAsync(id);

            if (file == null)
                return;

            _context.Files.Remove(file);
            await _context.SaveChangesAsync();
        }
    }
    }