using ClubMembership_Memberships.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubMembership_Memberships.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Membership>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Subscription>()
                .HasKey(s => new { s.UserId, s.MembershipId }); // Composite Key for Subscription

            modelBuilder.Entity<Subscription>()
            .HasOne(s => s.Membership)
            .WithMany()
            .HasForeignKey(s => s.MembershipId);
        }
    }
}
