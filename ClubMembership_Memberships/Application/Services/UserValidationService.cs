using ClubMembership_Memberships.gRPC;
using Grpc.Net.Client;

namespace ClubMembership_Memberships.Application.Services
{
    public class UserValidationService
    {
        private readonly UserService.UserServiceClient _client;

        public UserValidationService()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:7254");
            _client = new UserService.UserServiceClient(channel);
        }

        public async Task<bool> ValidateUserAsync(Guid userId)
        {
            var request = new ValidateUserRequest { UserId = userId.ToString() };
            var response = await _client.ValidateUserAsync(request);
            return response.Exists;
        }
    }
}
