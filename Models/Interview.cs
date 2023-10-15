using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    [Table("PhongVan")]
    public class Interview
    {
        [Key]
        private string interviewID;
        private DateTime interviewDate;
        [ForeignKey("Job")]
        private string jobID;
        public virtual Job? Job { get; set; }

        [ForeignKey("Candidate")]
        private string candidateID;
        public virtual Candidate? Candidate { get; set; }
        public virtual ICollection<InterviewProcess> InterviewProcesses { get; set; }

        
        public string InterviewID { get => interviewID; set => interviewID = value; }
        public DateTime InterviewDate { get => interviewDate; set => interviewDate = value; }
        public string JobID { get => jobID; set => jobID = value; }
        public string CandidateID { get => candidateID; set => candidateID = value; }
    }
}
