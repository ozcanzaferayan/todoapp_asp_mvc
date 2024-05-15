using Microsoft.AspNetCore.Mvc;
using todoapp.Data;
using todoapp.Models;

public class AddController : Controller
{

    private readonly ApplicationDbContext db;
    public AddController(ApplicationDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public IActionResult Index()
    {
        // Create an empty Todo object to fill in the form
        var todo = new Todo();
        return View(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Index(Todo model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        await db.Todos.AddAsync(model);
        await db.SaveChangesAsync();
        return RedirectToAction("Index", "Home");
    }
}