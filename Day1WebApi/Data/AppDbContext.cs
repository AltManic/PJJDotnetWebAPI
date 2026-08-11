using Microsoft.EntityFrameworkCore;

namespace Day1WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aset> Aset => Set<Aset>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aset>(e =>
            {
                e.ToTable("aset");
                e.Property(x => x.Nama).IsRequired().HasMaxLength(120);
                e.Property(x => x.Nilai).IsRequired().HasColumnName("nilai");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
