using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_drive.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NomeDoArquivo = table.Column<string>(type: "TEXT", nullable: false),
                    Extensao = table.Column<string>(type: "TEXT", nullable: false),
                    TipoMime = table.Column<string>(type: "TEXT", nullable: false),
                    Tamanho = table.Column<long>(type: "INTEGER", nullable: false),
                    DataUpload = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ArquivoByte = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
