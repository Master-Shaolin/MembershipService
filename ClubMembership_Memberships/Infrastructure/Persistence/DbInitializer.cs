using ClubMembership_Memberships.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;

namespace ClubMembership_Memberships.Infrastructure.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.Migrate();
            MembershipSeeder.Seed(context);
        }
    }
}
