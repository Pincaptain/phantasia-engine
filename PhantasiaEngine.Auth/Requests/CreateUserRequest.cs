namespace PhantasiaEngine.Auth.Requests
{
    // ReSharper disable UnusedAutoPropertyAccessor.Global
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}