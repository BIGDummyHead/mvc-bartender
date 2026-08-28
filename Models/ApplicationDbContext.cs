using Microsoft.EntityFrameworkCore;

namespace cis_proj.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Order> Order { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);




            Drink.Create(modelBuilder, 1, "Mojito", "A refreshing cocktail made with rum, lime juice, sugar, mint leaves, and soda water.", 8.50m);
            Drink.Create(modelBuilder, 2, "Margarita", "A classic cocktail made with tequila, lime juice, and orange liqueur, served in a salt-rimmed glass.", 9.00m);
            Drink.Create(modelBuilder, 3, "Old Fashioned", "A timeless cocktail made with bourbon or rye whiskey, sugar, bitters, and a twist of citrus.", 10.00m);
            Drink.Create(modelBuilder, 4    , "Cosmopolitan", "A stylish cocktail made with vodka, triple sec, cranberry juice, and lime juice.", 9.50m);
        }
    }
}
