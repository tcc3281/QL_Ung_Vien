using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Interview
    {
        [Key]
        [Column(TypeName = "int")]
        [Display(Name = "Mã phỏng vấn")]
        public int interviewID { get; set; }

        [Column(TypeName = "int")]
        public int? jobID { get; set; }
        public virtual Job? Job { get; set; }
        [Column(TypeName = "int")]
        public int? candidateID { get; set; }
        public virtual Candidate? Candidate { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Thời gian phỏng vấn")]
        public DateTime? interviewDate { get; set; }//ngày phỏng vấn
        public virtual ICollection<InterviewProcess> InterviewProcesses { get; set; }
        public Interview()
        {
            InterviewProcesses= new HashSet<InterviewProcess>();
        }
    }
}
