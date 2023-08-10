using Microsoft.EntityFrameworkCore;

namespace Restaurant_MVC.Data
{
    public class RestaurantsDbContext : DbContext
    {
        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> opt) : base(opt)
        {

        }
        #region DbSet
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<FoodCategory>? FoodCategories { get; set; }
        public DbSet<FoodItem>? FoodItems { get; set; }
        public DbSet<Reservation>? Reservations { get; set; }
        public DbSet<ContactUs>? ContactUss { get; set; }
        public DbSet<Restaurants>? Restaurantss { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
