using System.Linq;
using PhantasiaEngine.Auth.Contexts;
using PhantasiaEngine.Auth.Models;

namespace PhantasiaEngine.Auth.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthContext _authContext;

        public UserRepository(AuthContext authContext)
        {
            _authContext = authContext;
        }

        /// <summary>
        /// Adds the user to the database using the auth database context.
        /// </summary>
        /// <param name="user">The user to be added.</param>
        public void AddUser(User user)
        {
            _authContext.Users.Add(user);
            _authContext.SaveChanges();
        }

        /// <summary>
        /// Filters and finds the first(only) user that matches the
        /// provided username.
        /// </summary>
        /// <param name="username">The username used to find the user.</param>
        /// <returns>The users which username matches the provided username or null.</returns>
        public User GetUserByUsername(string username)
        {
            return _authContext.Users
                .FirstOrDefault(user => user.Username.Equals(username));
        }
    }
}