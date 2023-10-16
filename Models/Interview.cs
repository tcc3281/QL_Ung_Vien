using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Interview
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string interviewID { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string jobID { get; set; }
        public virtual Job? Job { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string candidateID { get; set; }
        public virtual Candidate? Candidate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime interviewDate { get; set; }//ngày phỏng vấn
        public virtual ICollection<InterviewProcess> InterviewProcesses { get; set; }
        public Interview()
        {
            InterviewProcesses= new HashSet<InterviewProcess>();
        }
    }
}
