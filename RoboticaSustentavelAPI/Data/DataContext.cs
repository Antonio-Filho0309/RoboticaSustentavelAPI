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
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ItemSale>()
               .HasOne(i => i.Computer)
               .WithMany(c => c.ItensSales)
               .HasForeignKey(i => i.ComputerId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Donation>()
                .Property(d => d.DateDonation)
                .HasColumnType("timestamp");

            builder.Entity<Sale>()
                .Property(s => s.SaleDate)
                .HasColumnType("timestamp");

            // Dados iniciais de Computer
            builder.Entity<Computer>().HasData(
                  new Computer(1, "Dell", "Intel i7", "16GB", "512GB SSD", 10),
                  new Computer(2, "HP", "Intel i5", "8GB", "1TB HDD", 5),
                  new Computer(3, "Lenovo", "Intel i9", "32GB", "1TB SSD", 3),
                  new Computer(4, null, "AMD Ryzen 5", "16GB", "256GB SSD", 8),
                  new Computer(5, "Asus", "AMD Ryzen 7", "32GB", "2TB HDD", 4)
            );


            // Dados iniciais de Donation
            builder.Entity<Donation>().HasData(
                new Donation(1, new DateTime(2023, 1, 15)),
                new Donation(2, new DateTime(2023, 2, 20)),
                new Donation(3, new DateTime(2023, 3, 10))
            );

            // Dados iniciais de ItemDonation
            builder.Entity<ItemDonation>().HasData(
                new ItemDonation(1, 1, 1, "Dell", "Intel i7", 2),
                new ItemDonation(2, 2, 1, "HP", "Intel i5", 1),
                new ItemDonation(3, 3, 2, "Lenovo", "Intel i9", 3),
                new ItemDonation(4, 4, 3, null, "AMD Ryzen 5", 1),
                new ItemDonation(5, 5, 3, "Asus", "AMD Ryzen 7", 2)
            );

            // Dados iniciais de Sale
            builder.Entity<Sale>().HasData(
                new Sale(1, new DateTime(2023, 4, 5), 1500.00),
                new Sale(2, new DateTime(2023, 4, 10), 2000.00)
            );

            // Dados iniciais de ItemSale
            builder.Entity<ItemSale>().HasData(
                new ItemSale(1, 1, 1, "Dell", "Intel i7", 1),
                new ItemSale(2, 2, 1, "HP", "Intel i5", 1),
                new ItemSale(3, 3, 2, "Lenovo", "Intel i9", 1)
            );
        }
    }
}
