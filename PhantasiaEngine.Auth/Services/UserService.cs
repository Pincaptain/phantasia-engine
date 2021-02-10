using AutoMapper;
using Microsoft.Extensions.Logging;
using PhantasiaEngine.Auth.Models;
using PhantasiaEngine.Auth.Repositories;
using PhantasiaEngine.Auth.Requests;
using PhantasiaEngine.Auth.Responses;

namespace PhantasiaEngine.Auth.Services
{
    /// <summary>
    /// <c>UserService</c> class contains the business logic and
    /// other functionalities for the user model.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Creates a user by mapping the <c>CreateUserRequest</c> object to a
        /// <c>User</c> object and then adding it to the database through the repository. 
        /// </summary>
        /// <param name="createUserRequest">The request containing the user information</param>
        public void CreateUser(CreateUserRequest createUserRequest)
        {
            var user = _mapper.Map<CreateUserRequest, User>(createUserRequest);

            _userRepository.AddUser(user);
            _logger.LogInformation($"User \"{user.Username}\" was successfully created");
        }

        /// <summary>
        /// Finds and returns a single user based on the provided username.
        /// </summary>
        /// <param name="username">The username used to find the user.</param>
        /// <returns>The users whose username matches the provided one or null.</returns>
        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        /// <summary>
        /// Returns a token response based on the provided <c>GetTokenRequest</c> object
        /// containing the username and password.
        /// </summary>
        /// <param name="getTokenRequest">The token request containing the username and password</param>
        /// <returns><c>TokenResponse</c> object that contains the requested token</returns>
        public TokenResponse GetTokenResponse(GetTokenRequest getTokenRequest)
        {
            var token = _userRepository.GetToken(getTokenRequest.Username, getTokenRequest.Password);

            var tokenResponse = new TokenResponse
            {
                Token = token
            };

            return tokenResponse;
        }

        /// <summary>
        /// Validates the provided user credentials and returns true or false
        /// based on their validity.
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The password of the user</param>
        /// <returns>Returns true or false based on the validity</returns>
        public bool ValidateUserCredential(string username, string password)
        {
            return _userRepository.GetToken(username, password) != null;
        }
    }
}