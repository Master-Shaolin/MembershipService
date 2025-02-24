using ClubMembership_Memberships.Domain.Entities;

namespace ClubMembership_Memberships.Infrastructure.Repositories
{
    public interface ISubscriptionRepository
    {
        Task AddAsync(Subscription subscription);
        Task<Subscription?> GetByIdAsync(Guid id);
        Task<List<Subscription>> GetUserSubscriptionsAsync(Guid userId);
        Task CancelSubscriptionAsync(Guid subscriptionId);
    }
}
