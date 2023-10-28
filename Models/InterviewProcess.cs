using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class InterviewProcess
    {
        [Key]
        [Column(TypeName = "int")]
        public int ipID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? date { get; set; }//ngày diễn ra

        [Column(TypeName = "int")]
        public int? interviewID { get; set; }
        public virtual Interview? Interview { get; set; }
        [Column(TypeName = "int")]
        public int? hRID { get; set; }
        public virtual HR? HR { get; set; }
        [Column(TypeName = "int")]
        public int? iRID { get; set; }
        public virtual InterviewResult?InterviewResult { get; set; }
    }
}
