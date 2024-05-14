using Microsoft.AspNetCore.Mvc;

using todoapp.Models;


public class TodosController : Controller {
    
    

    private readonly ILogger<TodosController> _logger;
    private readonly BloggingContext db;
    public TodosController(ILogger<TodosController> logger)
    {
         db = new BloggingContext();
        _logger = logger;

    }
      protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }
     public IActionResult Index()
    {

        Console.WriteLine("Querying for a blog");
        List<Blog> blogs = this.db.Blogs.ToList();


        return View(blogs);
    }
}