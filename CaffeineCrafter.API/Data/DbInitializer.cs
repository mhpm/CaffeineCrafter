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
                    new Categories{Name="Coffee", Description="Freshly brewed coffee", ImageUrl="coffee.jpg", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new Categories{Name="Tea", Description="Herbal and black teas", ImageUrl="tea.jpg", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new Categories{Name="Pastries", Description="Delicious snacks", ImageUrl="pastries.jpg", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                    new Categories{Name="Cold Drinks", Description="Refreshing cold beverages", ImageUrl="cold_drinks.jpg", IsActive=true, CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now}
                };
                context.Categories.AddRange(categories);
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
