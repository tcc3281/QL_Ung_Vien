using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Candidate//ứng viên
    {
        [Key]
        [Column(TypeName = "nvarchar (100)")]
        [Required]
        [StringLength(20)]
        public string candidateID;

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [StringLength(100, ErrorMessage = "Độ dài không quá 100 kí tự")]
        public string fullName;

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Email phải dài từ 5 - 100 kí tự")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._%+-]+.[A-Za-z]{2,4}")]
        public string email;

        [Column(TypeName = "nvarchar(200)")]
        [StringLength(200)]
        public string cV;//CV lưu trữ bằng url

        public int cStatement;//trang thai  được nhận chưa đang xet tuyển hay gì

        [Column(TypeName = "nvarchar(200)")]
        [StringLength(200)]
        public string cImage;//url lưu ảnh

        [Column(TypeName = "nvarchar(15)")]
        [StringLength(15, MinimumLength = 5)]
        [RegularExpression(@"(0|+)[0-9]+")]
        public string phoneNumber;
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
        public string CandidateID { get => candidateID; set => candidateID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Email { get => email; set => email = value; }
        public string CV { get => cV; set => cV = value; }
        public int CStatement { get => cStatement; set => cStatement = value; }
        public string CImage { get => cImage; set => cImage = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public Candidate()
        {
            Application = new HashSet<Application>();
            Interviews = new HashSet<Interview>();
        }
    }
}
