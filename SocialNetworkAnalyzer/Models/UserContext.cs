using Microsoft.EntityFrameworkCore;
using SocialNetworkAnalyzer.Models;

namespace SocialNetworkAnalyzer.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
