using System.ComponentModel.DataAnnotations;

namespace apiforapp.Models
{
    public class FoodType
    {
        [Key]
        public int IdFoodType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
