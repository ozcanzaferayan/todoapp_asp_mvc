using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoapp.Data;
using todoapp.ViewModels;


public class HomeController : Controller {
    
    private readonly ApplicationDbContext db;
    public HomeController(ApplicationDbContext db)
    {
        this.db = db;
    }
    public async Task<IActionResult> Index()
    {

        var todos = await db.Todos.ToListAsync();
        var blogs = await db.Blogs.Include(b => b.Posts).ToListAsync();
        var viewModel = new HomeViewModel
        {
            Todos = todos,
            Blogs = blogs
        };

        return View(viewModel);
    }
}