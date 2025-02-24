using ClubMembership_Memberships.Domain.Entities;
using ClubMembership_Memberships.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubMembership_Memberships.Infrastructure.Repositories
{
    public class SubscriptionRepository(AppDbContext context) : ISubscriptionRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task<Subscription?> GetByIdAsync(Guid id)
        {
            return await _context.Subscriptions.FindAsync(id);
        }

        public async Task<List<Subscription>> GetUserSubscriptionsAsync(Guid userId)
        {
            return await _context.Subscriptions.Where(s => s.UserId == userId).ToListAsync();
        }

        public async Task CancelSubscriptionAsync(Guid subscriptionId)
        {
            var subscription = await _context.Subscriptions.FindAsync(subscriptionId);
            if (subscription == null) throw new Exception("Subscription not found.");

            subscription.Status = "Cancelled";
            await _context.SaveChangesAsync();
        }

    }
}
