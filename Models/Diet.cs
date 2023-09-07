using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiforapp.Models
{
    public class Diet
    {
        [Key]
        public int idDiet { get; set; }
        public DateTime dateStart { get; set; }
        public int isActive { get; set; }
        [ForeignKey("User")]
        public int idUser { get; set; }
        public User usser { get; set; }


    }
}
