using Microsoft.EntityFrameworkCore;

namespace Sales.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Point> Points { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();                            
        }
    }
}
