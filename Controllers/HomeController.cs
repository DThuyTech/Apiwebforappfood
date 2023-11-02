using apiforapp.Models;
using apiforapp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace apiforapp.Controllers
{
    public class HomeController : Controller

    {
        private readonly ApplicationDbcontext _db;
        private readonly ILogger<HomeController> _logger;

       


        public HomeController(ILogger<HomeController> logger,ApplicationDbcontext db)
        {
            _logger = logger;
            _db = db;
        }

        async public Task<IActionResult> FoodController() 
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://foodtureapi.somee.com/api/Food/GetFoodsToPage?page=1");
            string content = await response.Content.ReadAsStringAsync();
            List<Food> foods =  System.Text.Json.JsonSerializer.Deserialize<List<Food>>(content);
            FoodViewModel foodViewModel = new FoodViewModel(foods);
            return View(foodViewModel);
        }

        async public Task<IActionResult> FoodEdit(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://foodtureapi.somee.com/api/Food/GetFoodsToPage?page=1");
            string content = await response.Content.ReadAsStringAsync();
            List<Food> foods = System.Text.Json.JsonSerializer.Deserialize<List<Food>>(content);
            Food foodEdit = foods.FirstOrDefault(p => p.Id == id);            
            return View(foodEdit);
        }

        public IActionResult Index()
        {
                
            return View();
        }
         public IActionResult Admin()
        {
            return View();
        }
        async public Task<IActionResult> DetailFood()
        {
            HttpClient clientt = new HttpClient();
            HttpResponseMessage response = await clientt.GetAsync("http://foodtureapi.somee.com/api/Food/GetFoodsToPage?page=1");
            string content = await response.Content.ReadAsStringAsync();
            List<Food> foods = System.Text.Json.JsonSerializer.Deserialize<List<Food>>(content);
            FoodViewModel foodViewModel = new FoodViewModel(foods);
            return View(foodViewModel);           
        }
        public IActionResult DETAIL()
        {
            return View();
        }
    }
}