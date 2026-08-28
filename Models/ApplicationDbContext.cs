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

            // Seed staff accounts so bartenders/servers can sign in.
            // Passwords are stored as SHA-256 hashes (see PasswordHelper).
            // bartender@bar.com / bartender123
            // server@bar.com / server123
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Sam Barkeep",
                    Email = "bartender@bar.com",
                    Password = "4523f961e3845992b04ae19a48d846a986d87062e5c9e91c785b4c691dbd4636",
                    Role = "Bartender"
                },
                new User
                {
                    Id = 2,
                    Name = "Riley Server",
                    Email = "server@bar.com",
                    Password = "14bf075c90460abf992eded5e80766dc474229ecc33a72b63e6844cce4a5f32c",
                    Role = "Server"
                });

            Drink.Create(modelBuilder, 1, "Mojito", "A refreshing cocktail made with rum, lime juice, sugar, mint leaves, and soda water.", 8.50m);
            Drink.Create(modelBuilder, 2, "Margarita", "A classic cocktail made with tequila, lime juice, and orange liqueur, served in a salt-rimmed glass.", 9.00m);
            Drink.Create(modelBuilder, 3, "Old Fashioned", "A timeless cocktail made with bourbon or rye whiskey, sugar, bitters, and a twist of citrus.", 10.00m);
            Drink.Create(modelBuilder, 4    , "Cosmopolitan", "A stylish cocktail made with vodka, triple sec, cranberry juice, and lime juice.", 9.50m);
        }
    }
}
