using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;
public  class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options) { }

    public DbSet<Computer> Computers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Computer>()
                    .HasData(new Computer()
                    {
                        Id = 1,
                        Name = "Dell Inspiron 15 3000",
                        Brand = "Dell",
                        Price = 500,
                        Description = "Dell Inspiron 15 3000, 15.6-inch FHD, Intel Core i5-1035G1, 8GB 2666MHz DDR4, 256 GB [SATA] M.2 (SSD), Intel UHD Graphics, Windows 10 Home",
                        ImageUrl = "https://m.media-amazon.com/images/I/71nP6lTogjL._AC_UF894,1000_QL80_.jpg"
                    });

        base.OnModelCreating(modelBuilder);
    }
}