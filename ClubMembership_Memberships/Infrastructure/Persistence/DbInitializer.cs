using ClubMembership_Memberships.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;

namespace ClubMembership_Memberships.Infrastructure.Persistence
{
    public class DbInitializer
    {
        public static async Task Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            if (context != null)
            {
                await SeedAsync(context);
            }
        }

        public static async Task SeedAsync(AppDbContext context)
        {
            await context.Database.MigrateAsync();
            await MembershipSeeder.Seed(context);
        }
    }
}
