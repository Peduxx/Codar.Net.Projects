using Codar.Net.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Codar.Net.Users.Data
{
    public class UserDataContext : DbContext
    {
        public DbSet<User> Users { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server = server-name; Database = your-database; User ID = your-id; Password = your-password;",
                    providerOptions => { providerOptions.EnableRetryOnFailure(); });
        }
    }
}