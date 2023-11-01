using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class CV
    {
        [Key]
        [Column(TypeName = "int")]
        [Display(Name = "Mã CV")]
        public int cVID {  get; set; }
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Link")]
        public string? path {  get; set; }
        public CV() { }
        public static readonly List<string> CvExtensions = new List<string> { ".PDF" };

        public static bool IsPDFFile(string filename)
        {
            // Lấy phần mở rộng của tên tệp
            string extension = Path.GetExtension(filename);
            // So sánh nó với danh sách các phần mở rộng hợp lệ
            return CvExtensions.Contains(extension.ToUpperInvariant());
        }
    }
}
