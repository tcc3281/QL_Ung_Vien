using QL_Ung_Vien.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class HR
    {
        [Key]
        [Column(TypeName = "int")]
        [Display(Name = "Mã HR")]
        public int hRID{ get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Tên")]
        public string? firstName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Họ")]
        public string? lastName { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Email")]
        public string? email { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Phone")]
        public string? phoneNumber { get; set; }
        [Column(TypeName = "int")]
        [Display(Name = "Ảnh")]
        public int? ImageID { get; set; }
        public Image? Image { get; set; }
        public virtual ICollection<InterviewProcess> InterviewProcesses { get; set; }
        [Column(TypeName = "varchar(450)")]
        public string? Id { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }
        [NotMapped]
        [Display(Name = "Ảnh")]
        public IFormFile? image { get; set; }
        public HR()
        {
            InterviewProcesses=new HashSet<InterviewProcess>();
        }
    }
}
