using Microsoft.AspNetCore.Mvc;
using PhantasiaEngine.Auth.Requests;
using PhantasiaEngine.Auth.Services;

namespace PhantasiaEngine.Auth.Controllers
{
    /// <summary>
    /// <c>UserController</c> class contains all the required user actions
    /// accessed using the provided routes.
    /// </summary>
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Creates a single user using the user service based on
        /// the provided <c>CreateUserRequest</c> object sent in the request body. 
        /// </summary>
        /// <param name="createUserRequest">The create user request.</param>
        /// <returns>
        /// The result of the action either Ok(200) or BadRequest(400) if createUserRequest is invalid.
        /// </returns>
        [HttpGet]
        [Route("create")]
        public IActionResult CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            _userService.CreateUser(createUserRequest);

            return Ok();
        }
    }
}