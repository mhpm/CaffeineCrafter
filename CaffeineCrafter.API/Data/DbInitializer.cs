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
                    new Categories{Name="Coffee", Description="Freshly brewed coffee", ImageUrl="https://images.unsplash.com/photo-1497935586351-b67a49e012bf?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow},
                    new Categories{Name="Tea", Description="Herbal and black teas", ImageUrl="https://images.unsplash.com/photo-1594631252845-29fc4cc8cde9?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow},
                    new Categories{Name="Pastries", Description="Delicious snacks", ImageUrl="https://images.unsplash.com/photo-1509365465985-25d11c17e812?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow},
                    new Categories{Name="Cold Drinks", Description="Refreshing cold beverages", ImageUrl="https://images.unsplash.com/photo-1513558161293-cdaf765ed2fd?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow}
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
                    new Products{Name="Espresso", Description="Strong black coffee", ImageUrl="https://images.unsplash.com/photo-1510591509098-f4fdc6d0ff04?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow, CategoriesId=coffeeCategory?.Id},
                    new Products{Name="Latte", Description="Coffee with steamed milk", ImageUrl="https://images.unsplash.com/photo-1570968992193-d6ea0826f923?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow, CategoriesId=coffeeCategory?.Id},
                    new Products{Name="Green Tea", Description="Healthy green tea", ImageUrl="https://images.unsplash.com/photo-1627435601361-ec25f5b1d0e5?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow, CategoriesId=teaCategory?.Id},
                    new Products{Name="Croissant", Description="Buttery pastry", ImageUrl="https://images.unsplash.com/photo-1555507036-ab1f4038808a?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow, CategoriesId=pastryCategory?.Id},
                    new Products{Name="Muffin", Description="Fluffy pastry", ImageUrl="https://images.unsplash.com/photo-1558401391-7899b4bd5bbf?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow, CategoriesId=pastryCategory?.Id},
                    new Products{Name="Cold Brew", Description="Refreshing cold brew coffee", ImageUrl="https://images.unsplash.com/photo-1517701604599-bb29b5c73553?auto=format&fit=crop&w=800&q=80", IsActive=true, CreatedAt=DateTime.UtcNow, UpdatedAt=DateTime.UtcNow, CategoriesId=coffeeCategory?.Id},
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
            else
            {
                // Update existing products with images if they have placeholder values
                var espresso = context.Products.FirstOrDefault(p => p.Name == "Espresso");
                if (espresso != null && (string.IsNullOrEmpty(espresso.ImageUrl) || espresso.ImageUrl == "espresso.jpg"))
                {
                    espresso.ImageUrl = "https://images.unsplash.com/photo-1510591509098-f4fdc6d0ff04?auto=format&fit=crop&w=800&q=80";
                }

                var latte = context.Products.FirstOrDefault(p => p.Name == "Latte");
                if (latte != null && (string.IsNullOrEmpty(latte.ImageUrl) || latte.ImageUrl == "latte.jpg"))
                {
                    latte.ImageUrl = "https://images.unsplash.com/photo-1570968992193-d6ea0826f923?auto=format&fit=crop&w=800&q=80";
                }

                var greenTea = context.Products.FirstOrDefault(p => p.Name == "Green Tea");
                if (greenTea != null && (string.IsNullOrEmpty(greenTea.ImageUrl) || greenTea.ImageUrl == "green_tea.jpg"))
                {
                    greenTea.ImageUrl = "https://images.unsplash.com/photo-1627435601361-ec25f5b1d0e5?auto=format&fit=crop&w=800&q=80";
                }

                var croissant = context.Products.FirstOrDefault(p => p.Name == "Croissant");
                if (croissant != null && (string.IsNullOrEmpty(croissant.ImageUrl) || croissant.ImageUrl == "croissant.jpg"))
                {
                    croissant.ImageUrl = "https://images.unsplash.com/photo-1555507036-ab1f4038808a?auto=format&fit=crop&w=800&q=80";
                }

                var muffin = context.Products.FirstOrDefault(p => p.Name == "Muffin");
                if (muffin != null && (string.IsNullOrEmpty(muffin.ImageUrl) || muffin.ImageUrl == "muffin.jpg"))
                {
                    muffin.ImageUrl = "https://images.unsplash.com/photo-1558401391-7899b4bd5bbf?auto=format&fit=crop&w=800&q=80";
                }

                var coldBrew = context.Products.FirstOrDefault(p => p.Name == "Cold Brew");
                if (coldBrew != null && (string.IsNullOrEmpty(coldBrew.ImageUrl) || coldBrew.ImageUrl == "cold_brew.jpg"))
                {
                    coldBrew.ImageUrl = "https://images.unsplash.com/photo-1517701604599-bb29b5c73553?auto=format&fit=crop&w=800&q=80";
                }

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
