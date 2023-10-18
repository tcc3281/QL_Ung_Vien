using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class CV
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string cVID {  get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? path {  get; set; }
        public IFormFile? cv;

    }
}
