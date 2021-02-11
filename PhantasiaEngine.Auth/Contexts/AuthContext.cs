using Microsoft.EntityFrameworkCore;
using PhantasiaEngine.Auth.Models;

namespace PhantasiaEngine.Auth.Contexts
{
    public class AuthContext : DbContext
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<User> Users { get; set; }
        
        public AuthContext(DbContextOptions<AuthContext> dbContextOptions) : base(dbContextOptions) { }
    }
}