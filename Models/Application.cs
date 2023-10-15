using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    [Table("UngTuyen")]
    public class Application
    {
        [Key]
        [ForeignKey("Candidate")]
        private string candidateId;
        public virtual Candidate? Candidate { get; set; }
        [Key]
        [ForeignKey("Job")]
        private string jobId;
        public virtual Job? Job { get; set; }
        private DateTime applyDate;
        private string level;
        private int aStatement;

        public string CandicateId { get => candidateId; set => candidateId = value; }
        public string JobId { get => jobId; set => jobId = value; }
        public DateTime ApplyDate { get => applyDate; set => applyDate = value; }
        public string Level { get => level; set => level = value; }
        public int State { get => aStatement; set => aStatement = value; }
    }
}
