using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiforapp.Models
{
    public class DetailNutributionFood
    {
        [Key]
        public int IdNutributionFood { get; set; }
        [ForeignKey("Food")]
        public int IdFoods { get; set; }
        public Food food { get; set; }
        [ForeignKey("Nutribution")]
        public int IdNutribution { get; set; }
        public Nutribution nutribution { get; set; }
        public int level { get; set; }
    }
}
