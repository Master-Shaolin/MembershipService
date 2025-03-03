using ClubMembership_Memberships.API.DTOs;
using ClubMembership_Memberships.Domain.Entities;
using ClubMembership_Memberships.Infrastructure.Repositories;

namespace ClubMembership_Memberships.Application.Services
{
    public class MemberShipService(IMembershipRepository membershipRepository, ISubscriptionRepository subscriptionRepository, UserValidationService userValidationService) : IMembershipService
    {
        private readonly IMembershipRepository _membershipRepository = membershipRepository;
        private readonly ISubscriptionRepository _subscriptionRepository = subscriptionRepository;
        private readonly UserValidationService _userValidationService = userValidationService;

        public async Task<List<MembershipDto>> GetAllMembershipsAsync()
        {
            var memberships = await _membershipRepository.GetAllAsync();
            return memberships.Select(m => new MembershipDto
            {
                Type = m.Type,
                Price = m.Price,
                DurationInMonths = m.DurationInMonths,
                Status = m.Status
            }).ToList();
        }

        public async Task<MembershipDto?> GetMembershipByIdAsync(Guid id)
        {
            var membership = await _membershipRepository.GetByIdAsync(id);
            return membership != null ? new MembershipDto()
            {
                Type = membership.Type,
                Price = membership.Price,
                DurationInMonths = membership.DurationInMonths,
                Status = membership.Status
            } : null;
        }

        public async Task SubscribeUserAsync(SubscribeMembershipDto subscriptionDto)
        {
            var userExists = await _userValidationService.ValidateUserAsync(subscriptionDto.UserId);
            if (!userExists)
            {
                throw new Exception("User does not exist.");
            }

            var membership = await _membershipRepository.GetByIdAsync(subscriptionDto.MembershipId)
            ?? throw new Exception("Membership not found.");

            var endDate = DateTime.UtcNow.AddMonths(membership.DurationInMonths);

            var subscription = new Subscription
            {
                Id = Guid.NewGuid(),
                UserId = subscriptionDto.UserId,
                MembershipId = membership.Id,
                StartDate = DateTime.UtcNow,
                EndDate = endDate
            };

            await _subscriptionRepository.AddAsync(subscription);
        }

        public async Task CancelSubscriptionAsync(Guid subscriptionId)
        {
            try
            {
                var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionId) ?? throw new Exception("Subscription not found");
                subscription.Status = "Cancelled";
                await _subscriptionRepository.CancelSubscriptionAsync(subscriptionId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error cancelling membership", ex);
            }
        }
    }
}
