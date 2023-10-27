using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
namespace QL_Ung_Vien.Models
{
    public class Image
    {
        [Key]
        [Column(TypeName = "int")]
        [Display(Name = "Mã ảnh")]
        public int imageID {  get; set; }
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Link")]
        public string? path {  get; set; }
        public IFormFile? image;
    }
}