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


        public async Task<List<Files>> GetAllFilesAsync()
        {
            return await _context.Files.ToListAsync();
        }
        public async Task<Files?> GetFileByIdAsync(Guid id)
        {
            return await _context.FindAsync<Files>(id);
        }

        public async Task<Files> CreateFileAsync(Files file)
        {
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<Files> UpdateFileAsync(Files file)
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