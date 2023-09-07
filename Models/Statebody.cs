using System.ComponentModel.DataAnnotations;

namespace apiforapp.Models
{
    public class Statebody
    {
        [Key]
        public int IdStatebody { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
