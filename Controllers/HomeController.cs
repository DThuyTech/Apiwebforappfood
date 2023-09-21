using apiforapp.Models;
using apiforapp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

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

        public JsonResult Index(double tdee, double protein,double cabrs, double fat )
        {


            // Tính lượng dinh dưỡng cho mỗi bữa
            double totalCaloriesPerDay = 2400;
            double totalProteinPerDay = 139;
            double totalFatPerDay = 50;
            double totalCarbsPerDay =  348;

            //============================================
            double breakfastCalories = totalCaloriesPerDay * (2.0 / 10.0);
            double lunchCalories = totalCaloriesPerDay * (5.0 / 10.0);
            double dinnerCalories = totalCaloriesPerDay * (3.0 / 10.0);

            double breakfastProtein = totalProteinPerDay * (2.0 / 10.0);
            double lunchProtein = totalProteinPerDay * (5.0 / 10.0);
            double dinnerProtein = totalProteinPerDay * (3.0 / 10.0);

            double breakfastFat = totalFatPerDay * (2.0 / 10.0);
            double lunchFat = totalFatPerDay * (5.0 / 10.0);
            double dinnerFat = totalFatPerDay * (3.0 / 10.0);

            double breakfastCarbs = totalCarbsPerDay * (2.0 / 10.0);
            double lunchCarbs = totalCarbsPerDay * (5.0 / 10.0);
            double dinnerCarbs = totalCarbsPerDay * (3.0 / 10.0);

            var menus = new
            {
                Monday = new DailyMenuView(),
                Tuesday = new DailyMenuView(),
                Wednesday = new DailyMenuView(),
                Thursday = new DailyMenuView(),
                Friday = new DailyMenuView(),
                Saturday = new DailyMenuView(),
                Sunday = new DailyMenuView()
            };

            List<Food> foodItems = _db.Foods.ToList();

            for (int i = 0; i < 7; i++)
            {
                
                List<Food> breakfastFoods = Logic.SelectFoods(foodItems, breakfastCalories, breakfastProtein, breakfastFat, breakfastCarbs, 3);
                List<Food> lunchFoods = Logic.SelectFoods(foodItems, lunchCalories, lunchProtein, lunchFat, lunchCarbs, 3);
                List<Food> dinnerFoods = Logic.SelectFoods(foodItems, dinnerCalories, dinnerProtein, dinnerFat, dinnerCarbs, 3);

                switch (i)
                {
                    case 0:
                        menus.Monday.Breakfast = breakfastFoods;
                        menus.Monday.Lunch = lunchFoods;
                        menus.Monday.Dinner = dinnerFoods;
                        break;

                    case 1:
                        menus.Tuesday.Breakfast = breakfastFoods;
                        menus.Tuesday.Lunch = lunchFoods;
                        menus.Tuesday.Dinner = dinnerFoods;
                        break;

                    case 2:
                        menus.Wednesday.Breakfast = breakfastFoods;
                        menus.Wednesday.Lunch = lunchFoods;
                        menus.Wednesday.Dinner = dinnerFoods;
                        break; 

                    case 3:
                        menus.Thursday.Breakfast = breakfastFoods;
                        menus.Thursday.Lunch = lunchFoods;
                        menus.Thursday.Dinner = dinnerFoods;
                        break;

                    case 4:
                        menus.Friday.Breakfast = breakfastFoods;
                        menus.Friday.Lunch = lunchFoods;
                        menus.Friday.Dinner = dinnerFoods;
                        break;

                    case 5:
                        menus.Saturday.Breakfast = breakfastFoods;
                        menus.Saturday.Lunch = lunchFoods;
                        menus.Saturday.Dinner = dinnerFoods;
                        break;

                    case 6:
                        menus.Sunday.Breakfast = breakfastFoods;
                        menus.Sunday.Lunch = lunchFoods;
                        menus.Sunday.Dinner = dinnerFoods;
                        break;
                }
            }
            return Json(menus);
        }

        public IActionResult Task(int colorMain, int taste, int age, int gender, int ActivityDen, int EmotionSen)
        {

            var jsonPath = "..\\wwwroot\\Content\\jsonAlth.txt";
            string JsonData = System.IO.File.ReadAllText(jsonPath);
            List<Nutrient> lnutr = JsonConvert.DeserializeObject<List<Nutrient>>(JsonData);
            double getValue = lnutr[1].Emotion;

            double ProteinRecommand = lnutr[0].Age * age + lnutr[0].Color_main * colorMain + lnutr[0].Gender * gender + 1 * lnutr[0].intercept + lnutr[0].Emotion * EmotionSen + lnutr[0].Activity_Sensitive * ActivityDen + lnutr[0].Taste * taste;
            double Cacbonhydratrecommand = lnutr[1].Age * age + lnutr[1].Color_main * colorMain + lnutr[1].Gender * gender + 1 * lnutr[1].intercept + lnutr[1].Emotion * EmotionSen + lnutr[1].Activity_Sensitive * ActivityDen + lnutr[1].Taste * taste;
            double FatRecommand = lnutr[2].Age * age + lnutr[2].Color_main * colorMain + lnutr[2].Gender * gender + 1 * lnutr[2].intercept + lnutr[2].Emotion * EmotionSen + lnutr[2].Activity_Sensitive * ActivityDen + lnutr[2].Taste * taste;
            List<double> nutriReocmmand = new List<double> { ProteinRecommand, Cacbonhydratrecommand, FatRecommand };
            return View(nutriReocmmand);
        }
    }
}