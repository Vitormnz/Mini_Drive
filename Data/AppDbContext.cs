using Microsoft.EntityFrameworkCore;
using Mini_drive.Models;

namespace Mini_drive.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<FilesModel> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FilesModel>()
                .HasKey(f => f.Id);

        }
    }
}
