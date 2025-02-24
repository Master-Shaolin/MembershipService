namespace ClubMembership_Memberships.Domain.Entities
{
    public class Membership
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationInMonths { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
