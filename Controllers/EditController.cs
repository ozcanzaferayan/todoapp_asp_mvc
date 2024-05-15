using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoapp.Data;
using todoapp.Models;

public class EditController : Controller
{

    private readonly ApplicationDbContext db;
    public EditController(ApplicationDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public IActionResult Index(int? id)
    {
        var todo = db.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        return View(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Index(Todo model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var todo = await db.Todos.FirstOrDefaultAsync(t => t.Id == model.Id);
        if (todo == null)
        {
            return View(model);
        }

        todo.Title = model.Title;
        todo.Description = model.Description;
        todo.IsComplete = model.IsComplete;

        await db.SaveChangesAsync();

        return RedirectToAction("Index", "Home");

    }
}