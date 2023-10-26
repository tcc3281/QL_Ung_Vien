using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Job
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Mã công việc")]
        public string jobID { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? benifitID { get; set; }
        public virtual Benefit? Benefit { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? requirementID { get; set; }
        public virtual Requirement Requirement { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên công việc")]
        public string? jobName { get; set; }
        [Display(Name = "Mô tả")]
        [Column(TypeName = "nvarchar(500)")]
        public string? jD { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Thời gian mơ đơn")]
        public DateTime? timeOpen { get; set; }//thời giản mở ứng tuyển
        [Column(TypeName = "datetime")]
        [Display(Name = "Hạn ứng tuyển")]
        public DateTime? timeClose { get; set; }//thời gian đóng ứng tuyển
        [Column(TypeName = "varchar(20)")]
        public string? ImageID { get; set; }
        public Image? Image { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }

        public Job()
        {
            Applications = new HashSet<Application>();
            Interviews = new HashSet<Interview>();
        }

    }
}