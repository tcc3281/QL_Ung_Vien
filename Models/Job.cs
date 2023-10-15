using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    [Table("CongViec")]
    public class Job
    {
        [Key]
        private string jobID;
        private string jobName;
        private string JD;
        private DateTime timeOpen;
        private DateTime timeClose;

        [ForeignKey("Requirement")]
        private string requirementID;
        public virtual Requirement? Requirement { get; set; }
        [ForeignKey("Benifit")]
        private string benifitID;
        public virtual Benefit? Benefit { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
        public string JobID { get => jobID; set => jobID = value; }
        public string Name { get => jobName; set => jobName = value; }
        public string Description { get => JD; set => JD = value; }
        public DateTime TimeOpen { get => timeOpen; set => timeOpen = value; }
        public DateTime TimeClose { get => timeClose; set => timeClose = value; }
        public string RequirementID { get => requirementID; set => requirementID = value; }
        public string BenifitID { get => benifitID; set => benifitID = value; }

        public Job()
        {
            Applications=new HashSet<Application>();
            Interviews=new HashSet<Interview>();
        }

    }
}
