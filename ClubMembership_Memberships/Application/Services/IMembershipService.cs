using ClubMembership_Memberships.API.DTOs;

namespace ClubMembership_Memberships.Application.Services
{
    public interface IMembershipService
    {
        Task<List<MembershipDto>> GetAllMembershipsAsync();
        Task<MembershipDto?> GetMembershipByIdAsync(Guid id);
        Task SubscribeUserAsync(SubscribeMembershipDto subscriptionDto);
        Task CancelSubscriptionAsync(Guid subscriptionId);
    }
}
