using ConnectElectronics.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ConnectElectronics.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Porosi_Detaje>().HasKey(am => new
            {
                am.PorosiId,
                am.ProduktId
            });
            modelBuilder.Entity<Porosi_Detaje>().HasOne(m => m.Produkt).WithMany(am => am.Porosi_Detajet).HasForeignKey(m => m.ProduktId);
            modelBuilder.Entity<Porosi_Detaje>().HasOne(m => m.Porosi).WithMany(am => am.Porosi_Detajet).HasForeignKey(m => m.PorosiId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Marka> Markat { get; set; }
        public DbSet<Kategori> Kategorit { get; set; }
        public DbSet<Porosi> Porosit { get; set; }
        public DbSet<Produkt> Produkte { get; set; }

        public DbSet<Porosi_Detaje> Porosi_Detajet { get; set; }

    }
}