using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Interview
    {
        [Key]
        public string interviewID;
        public DateTime interviewDate;//ngày phỏng vấn
        //[ForeignKey("Job")]
        public string jobID;
        public virtual Job? Job { get; set; }

        //[ForeignKey("Candidate")]
        public string candidateID;
        public virtual Candidate? Candidate { get; set; }
        public virtual ICollection<InterviewProcess> InterviewProcesses { get; set; }

        
        public string InterviewID { get => interviewID; set => interviewID = value; }
        public DateTime InterviewDate { get => interviewDate; set => interviewDate = value; }
        public string JobID { get => jobID; set => jobID = value; }
        public string CandidateID { get => candidateID; set => candidateID = value; }

        public Interview()
        {
            InterviewProcesses= new HashSet<InterviewProcess>();
        }
    }
}
