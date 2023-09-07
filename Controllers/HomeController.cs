using apiforapp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace apiforapp.Controllers
{
    public class HomeController : Controller

    {
        private readonly apDbcontext _db;
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger,apDbcontext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet("/get-todo-json")]
        public IActionResult GetTodoItemAsJson()
        {
            var todoItem = new TodoItem
            {
                Id = 1,
                Name = "Buy groceries",
                IsComplete = false
            };

            // Return the JSON data directly from the server
            return Json(todoItem);
        }
        public IActionResult getApi()
        {
            return View();
        }

        [HttpGet("/get-Nutribution-json")]
        public IActionResult GetApiNutribution() { 
            List<Nutribution> nutributions = _db.nutributions.ToList();
            
            return Json(nutributions);
        }
    }
}