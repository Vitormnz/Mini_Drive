using Microsoft.AspNetCore.Mvc;
using Mini_drive.Services.IServices;
using Mini_drive.Models;

namespace Mini_drive.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet ("")]
        public async Task<IActionResult> GetAllFiles()
        {
            var files = await _fileService.GetAllFilesAsync();
            return Ok(files);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetFileById(Guid id)
        {
            var file = await _fileService.GetFilesByIdAsync(id);
            if (file == null)
                return NotFound();
            return Ok(file);
        }

        [HttpGet("extensao/{Extensao}")]
        public async Task<IActionResult> GetFileByExtensao(string name) {

            var file = _fileService.GetFilesByTipoAsync(name);

            if (file == null)
                return NotFound();
            return Ok(file);
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadFile(Guid id)
        {
            var file = await _fileService.DownloadFileAsync(id);
            if (file == null)
                return NotFound();
            return File(file.ArquivoByte, file.TipoMime, file.NomeDoArquivo);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Arquivo inválido.");

            var created = await _fileService.UploadFileAsync(file);

            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFile(Guid id, IFormFile file)
        {
            if (id == null)
                return BadRequest("ID do arquivo não corresponde.");

            var updatedFile = await _fileService.UpdateFiles(id, file);
            return Ok(updatedFile);
        }
    }
}
