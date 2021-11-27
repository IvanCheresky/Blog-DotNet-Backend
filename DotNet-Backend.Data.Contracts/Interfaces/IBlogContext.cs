using DotNet_Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Backend.Data.Contracts.Interfaces
{
    public interface IBlogContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }

        int SaveChanges();
    }
}