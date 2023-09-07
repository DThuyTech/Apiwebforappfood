using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiforapp.Models
{
    public class DetailDietFood
    {
        [Key]
        public int idDetailDietFood { get; set; }
        [ForeignKey("Food")]
        public int idFood { get; set; }
        public Food food { get; set; }
        [ForeignKey("Diet")]
        public int idDiet { get; set; }
        public Diet diet { get; set; }
        public DateTime date { get; set; }
        // day la so buoi di tu  0 toi 2 tuong ung sang trua toi 
        public int bref { get; set; }
    }
}
