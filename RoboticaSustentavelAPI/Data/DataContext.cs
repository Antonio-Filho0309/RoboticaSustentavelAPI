using Microsoft.EntityFrameworkCore;
using RoboticaSustentavelAPI.Models;


namespace ProjetoLivrariaAPI.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Computer> Computers { get; set; }

        public DbSet<Donation> Donations { get; set; }

        public DbSet<ItemDonation> ItemDonations { get; set; }

        public DbSet<ItemSale> ItemSales { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Donation>()
      .Property(d => d.DateDonation)
      .HasColumnType("timestamp");

            builder.Entity<Sale>()
                .Property(s => s.SaleDate)
                .HasColumnType("timestamp");

            builder.Entity<Computer>()

                .HasData(new Computer(1, "Dell", "16GB", "512GB SSD", "Intel i7", 10),
            new Computer(2, "HP", "8GB", "1TB HDD", "Intel i5", 5),
            new Computer(3, "Lenovo", "32GB", "1TB SSD", "Intel i9", 3),
            new Computer(4, "Acer", "16GB", "256GB SSD", "AMD Ryzen 5", 8),
            new Computer(5, "Asus", "32GB", "2TB HDD", "AMD Ryzen 7", 4)
                );

            builder.Entity<Donation>()
      .HasData(
          new Donation(1, new DateTime(2023, 1, 15)),
          new Donation(2, new DateTime(2023, 2, 20)),
          new Donation(3, new DateTime(2023, 3, 10))
      );


            builder.Entity<ItemDonation>()
                .HasData(new ItemDonation(1, 1, 1, 2), 
                          new ItemDonation(2, 2, 1, 1),
                          new ItemDonation(3, 3, 2, 3),
                          new ItemDonation(4, 4, 3, 1),
                          new ItemDonation(5, 5, 3, 2)  
                );

            builder.Entity<Sale>()
         .HasData(
             new Sale(1, new DateTime(2023, 4, 5), 1500.00),
             new Sale(2, new DateTime(2023, 4, 10), 2000.00)
         );


            builder.Entity<ItemSale>()
                .HasData(new ItemSale(1, 1, 1, 1), 
                          new ItemSale(2, 2, 1, 1), 
                          new ItemSale(3, 3, 2, 1)  
                );
        }

    }
}
