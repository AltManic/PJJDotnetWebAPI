using Microsoft.EntityFrameworkCore;

namespace Day1WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aset> Aset => Set<Aset>();
        public DbSet<Kategori> Kategori => Set<Kategori>();
        public DbSet<Pegawai> Pegawai => Set<Pegawai>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aset>(e =>
            {
                e.ToTable("aset");
                e.Property(x => x.Nama).IsRequired().HasMaxLength(120);
                e.Property(x => x.Nilai).IsRequired().HasColumnName("nilai");
            });

            modelBuilder.Entity<Kategori>(e =>
            {
                e.HasMany(x => x.Aset).WithOne(x => x.Kategori).HasForeignKey(x => x.KategoriId);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
