using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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
        public string imagePath { get; set; }
        public string RecipePath { get; set; }
        [AllowNull]
        public int Ratecount { get; set; }

        [ForeignKey("FoodType")]
        public int IdFoodTypes { get; set; }
        public FoodType FoodType { get; set; }
    }
}
