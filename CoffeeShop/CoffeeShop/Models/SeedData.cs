using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Cafe Sữa",
                        Description = "Nhiều Sữa",
                        Category = "Cafe",
                        Price = 100
                    },
                    new Product
                    {
                        Name = "Sinh tố Hoa quả",
                        Description = "Sinh tố táo",
                        Category = "Sinh tố",
                        Price  = 150
                    },
                    new Product
                    {
                        Name = "Cafe đắng",
                        Description = "Cafe không đường",
                        Category = "Cafe",
                        Price = 90
                    },
                    new Product
                    {
                        Name = "Nước Cam ép",
                        Description = "Nước ép hoa quả",
                        Category = "Sinh tố",
                        Price = 90
                    },
                    new Product
                    {
                        Name = "Pacsiu",
                        Description = "Cafe Nhiều sữa",
                        Category = "Cafe",
                        Price = 120
                    },
                    new Product
                    {
                        Name = "Nâu đá",
                        Description = "Cafe Sữa đá",
                        Category = "Cafe",
                        Price = 70
                    },
                    new Product
                    {
                        Name = "Hoa quả dằm",
                        Description = "Hoa quả thập cẩm rằm",
                        Category = "Sinh tố",
                        Price = 180
                    }

                );
            }
        }

    }
}
