using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Job
    {
        [Key]
        private string jobID;
                     
        //[ForeignKey("Benifit")]
        private string benifitID;
        public virtual Benefit Benefit { get; set; }

        //[ForeignKey("Requirement")]
        private string requirementID;
        public virtual Requirement Requirement { get; set; }

        private string jobName;
        private string jD;
        private DateTime timeOpen;//thời giản mở ứng tuyển
        private DateTime timeClose;//thời gian đóng ứng tuyển

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
        public string JobID { get => jobID; set => jobID = value; }
        public string JobName { get => jobName; set => jobName = value; }
        public string JD { get => jD; set => jD = value; }
        public string BenifitID { get => benifitID; set => benifitID = value; }
        public string RequirementID { get => requirementID; set => requirementID = value; }
        public DateTime TimeOpen { get => timeOpen; set => timeOpen = value; }
        public DateTime TimeClose { get => timeClose; set => timeClose = value; }

        public Job()
        {
            Applications=new HashSet<Application>();
            Interviews=new HashSet<Interview>();
        }

    }
}
