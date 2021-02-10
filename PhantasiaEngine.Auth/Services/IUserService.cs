using PhantasiaEngine.Auth.Models;
using PhantasiaEngine.Auth.Requests;

namespace PhantasiaEngine.Auth.Services
{
    public interface IUserService
    {
        public void CreateUser(CreateUserRequest createUserRequest);

        public User GetUserByUsername(string username);
    }
}