using System.ComponentModel.DataAnnotations;

namespace apiforapp.Models
{
    public class FoodPart
    {
            [Key]
        public int IdFoodPart { get; set; }
        public string NameFoodPart { get; set; }
        public float fat { get; set; }
        public float calories { get; set; }
        public float cacbonhydrat { get; set; }
        public float protein { get; set; }
        public string Desciption { get; set;}
    }
}
