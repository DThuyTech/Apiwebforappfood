using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiforapp.Models
{
    public class Food
    {
        [Key]
        public int IdFood { get; set; }
        public string NameFoodPart { get; set; }
        public float fat { get; set; }
        public float calories { get; set; }
        public float cacbonhydrat { get; set; }
        public float protein { get; set; }
        public string Desciption { get; set; }
        public string RecipePath { get; set; }
        public int Ratecount { get; set; }

        [ForeignKey("FoodType")]
        public int IdFoodTypes { get; set; }
        public FoodType FoodType { get; set; }
    }
}
