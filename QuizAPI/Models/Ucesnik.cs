using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAPI.Models
{
    public class Ucesnik
    {
        [Key]
        public int UcesnikId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Ime { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Prezime { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Lozinka { get; set; }
        public int Poeni { get; set; }
        public int Vreme { get; set; }
    }
    public class UcesnikRezultat
    {
        public int UcesnikId { get; set; }
        public int Poeni { get; set; }
        public int Vreme { get; set; }
    }
}
