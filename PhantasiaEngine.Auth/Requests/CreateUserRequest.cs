﻿namespace PhantasiaEngine.Auth.Requests
{
    /// <summary>
    /// <c>CreateUserRequest</c> class contains the properties required for
    /// the create user request.
    /// </summary>
    // ReSharper disable UnusedAutoPropertyAccessor.Global
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}