using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class InterviewProcess
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string iDID { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }//ngày diễn ra

        [Column(TypeName = "varchar(20)")]
        public string interviewID { get; set; }
        public virtual Interview?Interview { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string hRID { get; set; }
        public virtual HR?HR { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string iRID { get; set; }
        public virtual InterviewResult?InterviewResult { get; set; }
    }
}
