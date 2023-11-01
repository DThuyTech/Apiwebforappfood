using apiforapp.Models;

namespace apiforapp.ViewModels
{
    public class FoodViewModel
    {
        public FoodViewModel(List<Food> listFood)
        {
            this.listFood = listFood;
        }

        public List<Food> listFood {  get; set; }
    }
}
