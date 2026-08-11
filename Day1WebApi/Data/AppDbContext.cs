using Microsoft.EntityFrameworkCore;

namespace Day1WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aset> Aset => Set<Aset>();

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aset>(e =>
            {
                e.ToTable("BMN");
                e.Property(x => x.Nama).IsRequired().HasMaxLength(120);
                e.Property(x => x.Nilai).IsRequired().HasColumnName("Harga");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
