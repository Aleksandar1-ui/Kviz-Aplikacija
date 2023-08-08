using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAPI.Models
{
    public class Prashanja
    {
        [Key]
        public int PrashanjeId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Prashanje { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? ImeSlika { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Opcija1 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Opcija2 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Opcija3 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Opcija4 { get; set; }
        public int Odgovor { get; set; }
    }
}
