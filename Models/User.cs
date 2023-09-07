using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace apiforapp.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Passsword { get; set; }
        [AllowNull]
        public int weight { get; set; }
        [AllowNull]
        public int heigh { get; set; }
        [AllowNull]
        public int gender { get; set; }
        [AllowNull]
        public int age { get; set; }
        [AllowNull]
        public string avatar { get; set; }

        [ForeignKey ("Statebody")]
        public int idStatebody { get; set; }
        public Statebody Statebody { get; set; }
        [ForeignKey ("Role")]
        public int idRole { get; set; }
        public Role role { get; set; }
    }
}
