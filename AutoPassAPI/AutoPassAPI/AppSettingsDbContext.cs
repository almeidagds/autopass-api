using Microsoft.EntityFrameworkCore;

namespace AutoPassAPI
{
    public class AppSettingsDbContext : DbContext
    {
        public AppSettingsDbContext(DbContextOptions<AppSettingsDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Client> Clients { get; set; }
        public DbSet<Models.Card> Cards { get; set; }
        public DbSet<Models.Transaction> Transactions { get; set; }
    }
}
