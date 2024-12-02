using Microsoft.EntityFrameworkCore;

namespace SeasonalStory.EFDbContext
{
    public class SSDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=mssql3.unoeuro.com;Initial Catalog=tinylink_se_db_seasonalstory;User ID=tinylink_se;Password=dAp6gFkE93wnzmy5Bhxe;TrustServerCertificate=true");
        }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Temperature> Temperatures { get; set; }

    }
}
