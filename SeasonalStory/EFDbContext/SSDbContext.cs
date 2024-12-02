using Microsoft.EntityFrameworkCore;

namespace SeasonalStory.EFDbContext;

public class SSDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(@"data source=Emmas-PC;initial catalog=myDatabase;trusted_connection=true;trustServerCertificate=true");
    }

    public DbSet<Photo> Photos { get; set; }

    public DbSet<Temperature> Temperatures { get; set; }
}
