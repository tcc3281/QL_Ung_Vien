using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Benefit//quyền lợi
    {
        
        [Key]
        [Column(TypeName = "int")]
        [Display(Name = "Mã quyền lợi")]
        public int benefitID {  get; set; }
        [Column(TypeName ="nvarchar(500)")]
        [StringLength(500)]
        [Display(Name = "Nội dung")]
        public string? benefitContent { get; set; }
        public virtual ICollection<Job> jobs { get; set; }
        public Benefit() 
        {
            jobs = new HashSet<Job>();
        }

    }
}
