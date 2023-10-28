using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QL_Ung_Vien.Areas.Identity.Data;
namespace QL_Ung_Vien.Models
{
    public class Candidate//ứng viên
    {
        [Key]
        [Column(TypeName = "int")]
        [Display(Name = "Mã ứng viên")]
        public int candidateID {  get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Tên")]
        public string? firstName {  get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Họ")]
        public string? lastName {  get; set; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Email")]
        public string? email { get; set; }
        [Column(TypeName ="int")]
        [Display(Name = "Trạng thái xét tuyển")]
        public int? cStatement { get; set; }//trang thai  được nhận chưa đang xet tuyển hay gì

        [Column(TypeName = "int")]
        public int? ImageID { get; set; }
        public Image? Image { get; set; }
        [Column(TypeName = "int")]
        public int? CVID { get; set; }
        public CV? CV { get; set; }

        [Column(TypeName = "varchar(20)")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Độ dài không phù hợp")]
        [RegularExpression(@"(0){1}[0-9]+", ErrorMessage ="Phải nhập số")]
        [Display(Name = "Số điện thoại")]
        public string? phoneNumber { get; set; }
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
        [Column(TypeName = "varchar(450)")]
        public string? Id { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public Candidate()
        {
            Application = new HashSet<Application>();
            Interviews = new HashSet<Interview>();
        }
    }
}
public enum CandidateState
{
    Interviewing,
    Pass,
    Fail
}
