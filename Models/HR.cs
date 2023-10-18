using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class HR
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string hRID{ get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? fullName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? email { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? phoneNumber { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? ImageID { get; set; }
        public Image? Image { get; set; }
        public virtual ICollection<InterviewProcess> InterviewProcesses { get; set; }
        
        public HR()
        {
            InterviewProcesses=new HashSet<InterviewProcess>();
        }
    }
}
