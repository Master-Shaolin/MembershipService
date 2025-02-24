using ClubMembership_Memberships.Domain.Entities;

namespace ClubMembership_Memberships.Infrastructure.Repositories
{
    public interface IMembershipRepository
    {
        Task<List<Membership>> GetAllAsync();
        Task<Membership?> GetByIdAsync(Guid id);
        Task AddAsync(Membership membership);
        Task UpdateAsync(Membership membership);
        Task DeleteAsync(Membership membership);
    }
}
