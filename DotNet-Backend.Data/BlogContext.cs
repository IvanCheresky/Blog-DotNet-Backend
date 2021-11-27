using DotNet_Backend.Data.Contracts.Interfaces;
using DotNet_Backend.Data.Settings.Interfaces;
using DotNet_Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Backend.Data
{
    public class BlogContext : DbContext, IBlogContext
    {
        private readonly IConnectionStrings _connectionStrings;
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options, IConnectionStrings connectionStrings)
            : base(options)
        {
            _connectionStrings = connectionStrings;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(_connectionStrings.DefaultSchema);

            //builder.ApplyConfiguration(new ...);
        }

    }
}