using CaffeineCrafter.API.Models;

namespace CaffeineCrafter.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Seed Categories
            if (!context.Categories.Any())
            {
                var categories = new Categories[]
                {
                    new Categories{Name="Coffee", Description="Freshly brewed coffee", ImageUrl="https://images.unsplash.com/photo-1497935586351-b67a49e012bf?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new Categories{Name="Tea", Description="Herbal and black teas", ImageUrl="https://images.unsplash.com/photo-1594631252845-29fc4cc8cde9?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new Categories{Name="Pastries", Description="Delicious snacks", ImageUrl="https://images.unsplash.com/photo-1509365465985-25d11c17e812?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new Categories{Name="Cold Drinks", Description="Refreshing cold beverages", ImageUrl="https://images.unsplash.com/photo-1513558161293-cdaf765ed2fd?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now}
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
            else
            {
                // Update existing categories with images if they have placeholder values
                var coffee = context.Categories.FirstOrDefault(c => c.Name == "Coffee");
                if (coffee != null && (string.IsNullOrEmpty(coffee.ImageUrl) || coffee.ImageUrl == "coffee.jpg"))
                {
                    coffee.ImageUrl = "https://images.unsplash.com/photo-1497935586351-b67a49e012bf?auto=format&fit=crop&w=800&q=80";
                }

                var tea = context.Categories.FirstOrDefault(c => c.Name == "Tea");
                if (tea != null && (string.IsNullOrEmpty(tea.ImageUrl) || tea.ImageUrl == "tea.jpg"))
                {
                    tea.ImageUrl = "https://images.unsplash.com/photo-1594631252845-29fc4cc8cde9?auto=format&fit=crop&w=800&q=80";
                }

                var pastries = context.Categories.FirstOrDefault(c => c.Name == "Pastries");
                if (pastries != null && (string.IsNullOrEmpty(pastries.ImageUrl) || pastries.ImageUrl == "pastries.jpg"))
                {
                    pastries.ImageUrl = "https://images.unsplash.com/photo-1509365465985-25d11c17e812?auto=format&fit=crop&w=800&q=80";
                }

                var coldDrinks = context.Categories.FirstOrDefault(c => c.Name == "Cold Drinks");
                if (coldDrinks != null && (string.IsNullOrEmpty(coldDrinks.ImageUrl) || coldDrinks.ImageUrl == "cold_drinks.jpg"))
                {
                    coldDrinks.ImageUrl = "https://images.unsplash.com/photo-1513558161293-cdaf765ed2fd?auto=format&fit=crop&w=800&q=80";
                }

                context.SaveChanges();
            }

            // Seed Products
            if (!context.Products.Any())
            {
                // Retrieve categories to link products
                var coffeeCategory = context.Categories.FirstOrDefault(c => c.Name == "Coffee");
                var teaCategory = context.Categories.FirstOrDefault(c => c.Name == "Tea");
                var pastryCategory = context.Categories.FirstOrDefault(c => c.Name == "Pastries");

                var products = new Products[]
                {
                    new Products{Name="Espresso", Description="Strong black coffee", ImageUrl="espresso.jpg", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now, CategoriesId=coffeeCategory?.Id},
                    new Products{Name="Latte", Description="Coffee with steamed milk", ImageUrl="latte.jpg", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now, CategoriesId=coffeeCategory?.Id},
                    new Products{Name="Green Tea", Description="Healthy green tea", ImageUrl="green_tea.jpg", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now, CategoriesId=teaCategory?.Id},
                    new Products{Name="Croissant", Description="Buttery pastry", ImageUrl="croissant.jpg", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now, CategoriesId=pastryCategory?.Id},
                    new Products{Name="Muffin", Description="Fluffy pastry", ImageUrl="muffin.jpg", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now, CategoriesId=pastryCategory?.Id},
                    new Products{Name="Cold Brew", Description="Refreshing cold brew coffee", ImageUrl="cold_brew.jpg", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now, CategoriesId=coffeeCategory?.Id},
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }

            // Seed Users
            if (!context.Users.Any())
            {
                var users = new Users[]
                {
                    new Users{Name="Admin User", Email="admin@caffeinecrafter.com", Password="Password123!"},
                    new Users{Name="Regular User", Email="user@caffeinecrafter.com", Password="Password123!"}
                };
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
