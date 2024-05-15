namespace todoapp.Data;

using Microsoft.EntityFrameworkCore;
using todoapp.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Todo> Todos { get; set; }

      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

}