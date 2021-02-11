using Microsoft.AspNetCore.Mvc;
using PhantasiaEngine.Auth.Requests;
using PhantasiaEngine.Auth.Services;

namespace PhantasiaEngine.Auth.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        [Route("create")]
        public IActionResult CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            _userService.CreateUser(createUserRequest);

            return Ok();
        }
        
        [HttpPost]
        [Route("token/get")]
        public IActionResult GetToken([FromBody] GetTokenRequest getTokenRequest)
        {
            var token = _userService.GetTokenResponse(getTokenRequest);

            return Ok(token);
        }
    }
}