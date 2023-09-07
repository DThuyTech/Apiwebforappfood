using System.ComponentModel.DataAnnotations;

namespace apiforapp.Models
{
    public class Nutribution
    {
        [Key]
        public int IdNutribution { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
