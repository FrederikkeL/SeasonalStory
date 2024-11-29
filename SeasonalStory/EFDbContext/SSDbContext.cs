using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SeasonalStory.EFDbContext
{
    public class SSDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"data source=Emmas-PC;initial catalog=myDatabase;trusted_connection=true;trustServerCertificate=true");
        }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Temperature> Temperatures { get; set; }
    }
}
