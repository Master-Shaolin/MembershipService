using ClubMembership_Memberships.Application.Services;
using ClubMembership_Memberships.Infrastructure.Repositories;

namespace ClubMembership_Memberships.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<IMembershipRepository, MembershipRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            // Register services
            services.AddScoped<IMembershipService, MemberShipService>();

            return services;
        }
    }
}
