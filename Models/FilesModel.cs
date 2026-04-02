using System.ComponentModel.DataAnnotations;

namespace Mini_drive.Models
{
    public class FilesModel
    {
        [Key]
        public Guid Id { get; set; }

        public string NomeDoArquivo { get; set; }

        public string Extensao { get; set; }
        public string TipoMime { get; set; }

        public long Tamanho { get; set; }

        public DateTime DataUpload { get; set; }

        public byte[] ArquivoByte { get; set; }
    }
}
