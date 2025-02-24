namespace ClubMembership_Memberships.API.DTOs
{
    public class SubscriptionDto
    {
        public Guid UserId { get; set; }
        public Guid MembershipId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Active";
    }
}
