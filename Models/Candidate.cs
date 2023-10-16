using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Candidate//ứng viên
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string candidateID {  get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string fullName {  get; set; }

        [Column(TypeName = "varchar(100)")]
        public string email { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string cV { get; set; }//CV lưu trữ bằng url
        [Column(TypeName ="int")]
        public int cStatement { get; set; }//trang thai  được nhận chưa đang xet tuyển hay gì

        [Column(TypeName = "varchar(200)")]
        public string cImage { get; set; }//url lưu ảnh

        [Column(TypeName = "varchar(20)")]
        public string phoneNumber { get; set; }
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }

        public Candidate()
        {
            Application = new HashSet<Application>();
            Interviews = new HashSet<Interview>();
        }
    }
}
