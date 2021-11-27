using DotNet_Backend.Data.Contracts.Interfaces;
using DotNet_Backend.Data.Settings;
using DotNet_Backend.Data.Settings.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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