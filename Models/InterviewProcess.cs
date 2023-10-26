using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class InterviewProcess
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string ipID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? date { get; set; }//ngày diễn ra

        [Column(TypeName = "varchar(20)")]
        public string? interviewID { get; set; }
        public virtual Interview? Interview { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? hRID { get; set; }
        public virtual HR? HR { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? iRID { get; set; }
        public virtual InterviewResult?InterviewResult { get; set; }
    }
}
