namespace ClubMembership_Memberships.Domain.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }  // User subscribing
        public Guid MembershipId { get; set; } // Membership subscribed to
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } // Calculate based on membership duration
        public string Status { get; set; } = "Active"; // Active, Cancelled, Expired

        public Membership Membership { get; set; } = null!;
    }
}
