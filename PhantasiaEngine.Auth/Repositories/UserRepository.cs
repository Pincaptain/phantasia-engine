using System.Linq;
using PhantasiaEngine.Auth.Contexts;
using PhantasiaEngine.Auth.Models;
using PhantasiaEngine.Shared.Utilities;

namespace PhantasiaEngine.Auth.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthContext _authContext;

        public UserRepository(AuthContext authContext)
        {
            _authContext = authContext;
        }

        public void AddUser(User user)
        {
            _authContext.Users.Add(user);
            _authContext.SaveChanges();
        }

        public User GetUserByUsername(string username)
        {
            return _authContext.Users
                .FirstOrDefault(user => user.Username.Equals(username));
        }

        public string GetToken(string username, string password)
        {
            var user = _authContext.Users.FirstOrDefault(u => u.Username.Equals(username));

            if (user == null) return null;
            if (!Cryptonite.Verify(password, user.PasswordHash)) return null;
            if (Tokenizer.VerifyTimestampedToken(user.Token)) return user.Token;
            
            user.Token = Tokenizer.CreateTimestampedToken();
            _authContext.SaveChanges();

            return user.Token;
        }
    }
}