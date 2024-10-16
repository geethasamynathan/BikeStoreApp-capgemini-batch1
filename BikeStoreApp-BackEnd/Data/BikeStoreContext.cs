using BikeStoreApp_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStoreApp_BackEnd.Data
{
    public class BikeStoreContext :DbContext
    {
        public BikeStoreContext(DbContextOptions<BikeStoreContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
    }
}
