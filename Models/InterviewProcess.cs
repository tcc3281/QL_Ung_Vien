using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class InterviewProcess
    {
        [Key]
        private string iDID;
        private DateTime date;//ngày diễn ra

        //[ForeignKey("Interview")]
        private string interviewID;
        public virtual Interview?Interview { get; set; }
        //[ForeignKey("HR")]
        private string hRID;
        public virtual HR?HR { get; set; }
        //[ForeignKey("InterviewResult")]
        private string iRID;
        public virtual InterviewResult?InterviewResult { get; set; }
        public string IDID { get => iDID; set => iDID = value; }
        public DateTime Date { get => date; set => date = value; }
        public string InterviewID { get => interviewID; set => interviewID = value; }
        public string HRID { get => hRID; set => hRID = value; }
        public string IRID { get => iRID; set => iRID = value; }
    }
}
