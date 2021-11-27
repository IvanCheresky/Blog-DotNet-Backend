using DotNet_Backend.Data.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotNet_Backend.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options, IConfiguration configuration)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

    }
    }