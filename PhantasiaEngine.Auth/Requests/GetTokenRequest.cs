namespace PhantasiaEngine.Auth.Requests
{
    /// <summary>
    /// <c>GetTokenRequest</c> class contains the properties required for
    /// the get token request.
    /// </summary>
    // ReSharper disable UnusedAutoPropertyAccessor.Global
    public class GetTokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}