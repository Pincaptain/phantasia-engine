using PhantasiaEngine.Auth.Models;

namespace PhantasiaEngine.Auth.Repositories
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        
        public User GetUserByUsername(string username);
    }
}