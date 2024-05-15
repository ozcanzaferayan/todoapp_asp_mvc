using Microsoft.AspNetCore.Mvc;
using todoapp.Data;

public class DeleteController : Controller
{

    private readonly ApplicationDbContext db;
    public DeleteController(ApplicationDbContext db)
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
    public async Task<IActionResult> Index(int id)
    {
        var todo = db.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();

        return RedirectToAction("Index", "Home");

    }
}