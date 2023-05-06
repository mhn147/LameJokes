using System.Diagnostics;
using DemoApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _db;

    public HomeController(ILogger<HomeController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        var jokes = _db.Jokes?.ToList();

        return View(jokes);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Joke joke)
    {
        _db.Jokes.Add(joke);
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
}
