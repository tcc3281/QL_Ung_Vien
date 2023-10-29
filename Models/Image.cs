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
        public int imageID { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Link")]
        public string? path { get; set; }
        public Image() { }

        public static readonly List<string> ImageExtensions = new List<string> { ".jpg", ".jpeg", ".jpe", ".bmp", ".png" };

        public static bool IsImageFile(string filename)
        {
            // Kiểm tra xem tệp có tồn tại không
            if (!File.Exists(filename))
            {
                return false;
            }

            // Lấy phần mở rộng của tên tệp
            string extension = Path.GetExtension(filename).ToLowerInvariant();

            // So sánh nó với danh sách các phần mở rộng hợp lệ
            return ImageExtensions.Contains(extension);
        }
    }
    
}