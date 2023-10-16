using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Benefit//quyền lợi
    {
        
        [Key]
        [Column(TypeName ="varchar(10)")]
        public string benefitID {  get; set; }
        [Column(TypeName ="nvarchar(500)")]
        public string benefitContent { get; set; }
        public virtual ICollection<Job> jobs { get; set; }
        public Benefit() 
        {
            jobs = new HashSet<Job>();
        }

    }
}
