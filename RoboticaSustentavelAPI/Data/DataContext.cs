using Microsoft.EntityFrameworkCore;
using RoboticaSustentavelAPI.Models;
using RoboticaSustentavelAPI.Models.Enum;

namespace ProjetoLivrariaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<ItemDonation> ItemDonations { get; set; }
        public DbSet<ItemSale> ItemSales { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configuração de tipos
            builder.Entity<ItemDonation>()
                .HasOne(i => i.Computer)
                .WithMany(c => c.ItensDonation)
                .HasForeignKey(i => i.ComputerId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<ItemSale>()
               .HasOne(i => i.Computer)
              .WithMany(c => c.ItensSales)
               .HasForeignKey(i => i.ComputerId)
               .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Donation>()
                .Property(d => d.DateDonation)
                .HasColumnType("timestamp");

            builder.Entity<Sale>()
                .Property(s => s.SaleDate)
                .HasColumnType("timestamp");

        }
    }
}
