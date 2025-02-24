using ClubMembership_Memberships.Domain.Entities;
using ClubMembership_Memberships.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClubMembership_Memberships.Infrastructure.Repositories
{
    public class MembershipRepository(AppDbContext context) : IMembershipRepository
    {
        public async Task<List<Membership>> GetAllAsync()
        {
            return await context.Memberships.ToListAsync();
        }

        public async Task<Membership?> GetByIdAsync(Guid id)
        {
            return await context.Memberships.FindAsync(id);
        }

        public async Task AddAsync(Membership membership)
        {
            context.Memberships.Add(membership);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Membership membership)
        {
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Membership membership)
        {
            context.Memberships.Remove(membership);
            await context.SaveChangesAsync();
        }
    }
}
