using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Requirement
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string requirementID { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string requirementContent { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public Requirement()
        {
            Jobs= new HashSet<Job>();
        }
    }
}
