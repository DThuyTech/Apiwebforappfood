using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiforapp.Models
{ 
    public class Rate
    {
        [Key]
        public int IdRate { get; set; }
        [ForeignKey("Food")]
        public int idFood { get; set; }

        public Food food { get; set; }
        [ForeignKey("FoodPart")]
        public int idFoodpart { get; set; }
        public FoodPart foodpart { get; set; }
        public int rate { get; set; }
    }
}
