using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Job
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string jobID { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string benifitID { get; set; }
        public virtual Benefit Benefit { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string requirementID { get; set; }
        public virtual Requirement Requirement { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string jobName { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string jD { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime timeOpen { get; set; }//thời giản mở ứng tuyển
        [Column(TypeName = "datetime2")]
        public DateTime timeClose { get; set; }//thời gian đóng ứng tuyển

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }

        public Job()
        {
            Applications = new HashSet<Application>();
            Interviews = new HashSet<Interview>();
        }

    }
}