using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace apiforapp.Models
{
    public class DetailPurpose
    {
        [Key]
        public int idPurposedetail { get; set; }
        [ForeignKey("User")]
        public int idUser { get; set; }
        public User user { get; set; }
        [ForeignKey("Purpose")]
        public int idPurpose { get; set; }
        public Purpose purpose { get; set; }

        [AllowNull]
        public int  level { get; set; }
        
    }
}
