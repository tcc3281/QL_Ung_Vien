using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
namespace QL_Ung_Vien.Models
{
    public class Image
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Mã ảnh")]
        public string imageID {  get; set; }
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Link")]
        public string? path {  get; set; }
        public IFormFile? image;
    }
}