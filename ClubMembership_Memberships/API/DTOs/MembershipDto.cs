namespace ClubMembership_Memberships.API.DTOs
{
    public class MembershipDto
    {
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationInMonths { get; set; }
        public string Status { get; set; } = "Active";
    }
}
