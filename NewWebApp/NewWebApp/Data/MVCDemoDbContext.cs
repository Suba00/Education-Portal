using Microsoft.EntityFrameworkCore;
using NewWebApp.Models.Domain;

namespace NewWebApp.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions<MVCDemoDbContext> options) : base(options)
        {
        }

        public MVCDemoDbContext()
        {
        }

        public DbSet<NewEmployee> NewEmployees { get; set; }
        public DbSet<Test1> Tests1 { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<FileMetadata> FileMetadatas { get; set; }
        public DbSet<VideoMetadata> VideoMetadatas { get; set; }

    }
}
