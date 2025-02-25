using ClubMembership_Memberships.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubMembership_Memberships.Infrastructure.Persistence.Seeders
{
    public class MembershipSeeder
    {
        public static async Task Seed(AppDbContext context)
        {
            if (!await context.Memberships.AnyAsync())
            {
                var memberships = new List<Membership>
            {
                new() { Id = Guid.NewGuid(), Type = "Gold", Price = 99.99m, DurationInMonths = 12 },
                new() { Id = Guid.NewGuid(), Type = "Silver", Price = 59.99m, DurationInMonths = 6 },
                new() { Id = Guid.NewGuid(), Type = "Bronze", Price = 29.99m, DurationInMonths = 3 }
            };

                await context.Memberships.AddRangeAsync(memberships);
                await context.SaveChangesAsync();
            }
        }
    }
}
