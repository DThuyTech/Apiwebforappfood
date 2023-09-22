using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
=======
>>>>>>> 104ae7713c68ad65a205b91ef481811d7b7fc44a

namespace apiforapp.Models
{
    public class Food
    {
        [Key]
<<<<<<< HEAD
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
=======
        public int Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public string ImageUrl { get; set; }
>>>>>>> 104ae7713c68ad65a205b91ef481811d7b7fc44a
    }
}
