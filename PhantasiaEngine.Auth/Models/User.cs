namespace PhantasiaEngine.Auth.Models
{
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