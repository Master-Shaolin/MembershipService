using ClubMembership_Memberships.API.DTOs;
using ClubMembership_Memberships.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClubMembership_Memberships.API.Controllers
{
    [Route("api/memberships")]
    [ApiController]
    public class MembershipController(IMembershipService membershipService) : ControllerBase
    {
        private readonly IMembershipService _membershipService = membershipService;

        // 1️⃣ Get all memberships
        [HttpGet]
        public async Task<IActionResult> GetAllMemberships()
        {
            var memberships = await _membershipService.GetAllMembershipsAsync();
            return Ok(memberships);
        }

        // 2️⃣ Get membership by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMembershipById(Guid id)
        {
            var membership = await _membershipService.GetMembershipByIdAsync(id);
            if (membership == null)
                return NotFound("Membership not found.");

            return Ok(membership);
        }

        // 3️⃣ Subscribe a user to an existing membership
        [HttpPost("subscribe")]
        public async Task<IActionResult> SubscribeUser([FromBody] SubscribeMembershipDto subscribeDto)
        {
            try
            {
                await _membershipService.SubscribeUserAsync(subscribeDto);
                return Ok("User successfully subscribed to the membership.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 4️⃣ Cancel a subscription
        [HttpPatch("cancel")]
        public async Task<IActionResult> CancelSubscription([FromBody] CancelSubscriptionDto cancelDto)
        {
            try
            {
                await _membershipService.CancelSubscriptionAsync(cancelDto.SubscriptionId);
                return Ok("Membership subscription successfully cancelled.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
