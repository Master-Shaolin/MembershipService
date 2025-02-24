namespace ClubMembership_Memberships.Events
{
    public class MembershipCreatedEvent
    {
        public Guid UserId { get; set; }
        public Guid MembershipId { get; set; }
        public DateTime SubscribedAt { get; set; } = DateTime.UtcNow;
    }
}


