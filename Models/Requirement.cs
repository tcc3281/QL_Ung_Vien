using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Requirement
    {
        [Key]
        [Column(TypeName = "int")]
        [Display(Name ="Mã quyền lợi")]
        public int requirementID { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        [StringLength(500)]
        [Display(Name = "Nội dung quyền lợi")]
        public string? requirementContent { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public Requirement()
        {
            Jobs= new HashSet<Job>();
        }
    }
}
