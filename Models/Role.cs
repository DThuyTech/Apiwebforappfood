using System.ComponentModel.DataAnnotations;

namespace apiforapp.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
    }
}
