namespace todoapp.Data;

using Microsoft.EntityFrameworkCore;
using todoapp.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
       using (var db = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
            if (db.Blogs.Any() || db.Posts.Any()||db.Todos.Any())
            {
                return;
            }
            db.Todos.AddRange(
                new Todo
                {
                    Title = "Grocery Shopping",
                    Description = "Buy milk, eggs, and bread",
                    IsComplete = false
                },
                new Todo
                {
                    Title = "Laundry",
                    Description = "Do the laundry",
                    IsComplete = false
                },
                new Todo
                {
                    Title = "Clean the house",
                    Description = "Vacuum and dust",
                    IsComplete = false
                }
                
            );

            db.Blogs.AddRange(
                new Blog
                {
                    Url = "https://www.medium.com"
                },
                new Blog
                {
                    Url = "https://www.google.com"
                },
                new Blog
                {
                    Url = "https://www.microsoft.com"
                }
            );
            db.SaveChanges();
            db.Posts.AddRange(
                new Post
                {
                    Title = "Hello World",
                    Content = "I wrote an app using EF Core!",
                    Blog = db.Blogs.First()
                },
                new Post
                {
                    Title = "Second Post",
                    Content = "This is the second post",
                    Blog = db.Blogs.First()
                },
                new Post
                {
                    Title = "Third Post",
                    Content = "This is the third post",
                    Blog = db.Blogs.Skip(1).First()
                },
                new Post
                {
                    Title = "Fourth Post",
                    Content = "This is the fourth post",
                    Blog = db.Blogs.Skip(2).First()
                }
            );
            db.SaveChanges();
        }
    }
}
