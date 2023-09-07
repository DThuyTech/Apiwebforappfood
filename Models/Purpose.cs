using System.ComponentModel.DataAnnotations;

namespace apiforapp.Models
{
    public class Purpose
    {
        [Key]
        public int IdPurpose { get; set; }
        public string Name { get; set; }
        public string desciption { get; set; }
    }
}
