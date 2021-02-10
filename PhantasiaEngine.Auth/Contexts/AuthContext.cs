using Microsoft.EntityFrameworkCore;
using PhantasiaEngine.Auth.Models;

namespace PhantasiaEngine.Auth.Contexts
{
    /// <summary>
    /// <c>AuthContext</c> database context class contains all the database sets
    /// for the auth scope.
    /// </summary>
    public class AuthContext : DbContext
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<User> Users { get; set; }
        
        public AuthContext(DbContextOptions<AuthContext> dbContextOptions) : base(dbContextOptions) { }
    }
}