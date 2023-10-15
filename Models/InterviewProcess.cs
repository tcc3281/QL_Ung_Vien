using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    [Table("QuaTrinhPhongVan")]
    public class InterviewProcess
    {
        [Key]
        private string IDID;
        private DateTime date;

        [ForeignKey("Interview")]
        private string interviewID;
        public virtual Interview?Interview { get; set; }
        [ForeignKey("HR")]
        private string HRID;
        public virtual HR?HR { get; set; }
        [ForeignKey("InterviewResult")]
        private string IRID;
        public virtual InterviewResult?InterviewResult { get; set; }
        public string IDID1 { get => IDID; set => IDID = value; }
        public DateTime Date { get => date; set => date = value; }
        public string InterviewID { get => interviewID; set => interviewID = value; }
        public string HRID1 { get => HRID; set => HRID = value; }
        public string IRID1 { get => IRID; set => IRID = value; }
    }
}
