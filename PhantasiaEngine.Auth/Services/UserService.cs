using AutoMapper;
using Microsoft.Extensions.Logging;
using PhantasiaEngine.Auth.Models;
using PhantasiaEngine.Auth.Repositories;
using PhantasiaEngine.Auth.Requests;
using PhantasiaEngine.Auth.Responses;

namespace PhantasiaEngine.Auth.Services
{
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

        public void CreateUser(CreateUserRequest createUserRequest)
        {
            var user = _mapper.Map<CreateUserRequest, User>(createUserRequest);

            _userRepository.AddUser(user);
            _logger.LogInformation($"User \"{user.Username}\" was successfully created");
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public TokenResponse GetTokenResponse(GetTokenRequest getTokenRequest)
        {
            var token = _userRepository.GetToken(getTokenRequest.Username, getTokenRequest.Password);

            var tokenResponse = new TokenResponse
            {
                Token = token
            };

            return tokenResponse;
        }

        public bool ValidateUserCredential(string username, string password)
        {
            return _userRepository.GetToken(username, password) != null;
        }
    }
}