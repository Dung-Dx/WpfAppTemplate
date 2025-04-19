using Microsoft.EntityFrameworkCore;
using WpfAppTemplate.Helpers;
using WpfAppTemplate.Models;

namespace WpfAppTemplate.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<DaiLy> DsDaiLy { get; set; } = null!;
        public DbSet<LoaiDaiLy> DsLoaiDaiLy { get; set; } = null!;
        public DbSet<Quan> DsQuan { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // DaiLy (1:n) <- (1:1) LoaiDaiLy
            modelBuilder.Entity<DaiLy>()
                .HasOne(d => d.LoaiDaiLy)
                .WithMany(l => l.DsDaiLy)
                .HasForeignKey(d => d.MaLoaiDaiLy)
                .OnDelete(DeleteBehavior.Cascade);

            // DaiLy (1:n) <- (1:1) Quan
            modelBuilder.Entity<DaiLy>()
                .HasOne(d => d.Quan)
                .WithMany(q => q.DsDaiLy)
                .HasForeignKey(d => d.MaQuan)
                .OnDelete(DeleteBehavior.Cascade);

            DatabaseSeeder.Seed(modelBuilder);
        }
    }
}
