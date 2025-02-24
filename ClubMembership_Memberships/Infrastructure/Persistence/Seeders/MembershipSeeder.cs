using ClubMembership_Memberships.Domain.Entities;

namespace ClubMembership_Memberships.Infrastructure.Persistence.Seeders
{
    public class MembershipSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Memberships.Any())
            {
                var memberships = new List<Membership>
            {
                new() { Id = Guid.NewGuid(), Type = "Gold", Price = 99.99m, DurationInMonths = 12 },
                new() { Id = Guid.NewGuid(), Type = "Silver", Price = 59.99m, DurationInMonths = 6 },
                new() { Id = Guid.NewGuid(), Type = "Bronze", Price = 29.99m, DurationInMonths = 3 }
            };

                context.Memberships.AddRange(memberships);
                context.SaveChanges();
            }
        }
    }
}
