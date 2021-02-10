namespace PhantasiaEngine.Auth.Models
{
    /// <summary>
    /// User is a data class that contains all the properties a user needs
    /// including a hashed version of his password.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
    }
}