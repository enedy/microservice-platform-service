using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrebDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            Console.WriteLine("--> PrepPopulation...");
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                    new Platform(name: "Dot Net", publisher: "Microsoft", cost: "Free"),
                    new Platform(name: "SQL Server Express", publisher: "Microsoft", cost: "Free"),
                    new Platform(name: "Kubernetes", publisher: "Cloud Native Computing Foundation", cost: "Free")

                );

                context.SaveChanges();
            }
            else
                Console.WriteLine("--> We already have data!");
        }
    }
}