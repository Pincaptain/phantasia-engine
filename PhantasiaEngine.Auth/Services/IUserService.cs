using PhantasiaEngine.Auth.Models;
using PhantasiaEngine.Auth.Requests;
using PhantasiaEngine.Auth.Responses;

namespace PhantasiaEngine.Auth.Services
{
    public interface IUserService
    {
        public void CreateUser(CreateUserRequest createUserRequest);

        public User GetUserByUsername(string username);

        public TokenResponse GetTokenResponse(GetTokenRequest getTokenRequest);

        public bool ValidateUserCredential(string username, string password);
    }
}