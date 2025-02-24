namespace ClubMembership_Memberships.API.DTOs
{
    public class SubscribeMembershipDto
    {
        public Guid UserId { get; set; }  // Identifies the user subscribing
        public Guid MembershipId { get; set; } // Identifies the existing membership
    }
}
