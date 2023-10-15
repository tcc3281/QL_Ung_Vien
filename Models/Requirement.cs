using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    [Table("QuyenLoi")]
    public class Requirement
    {
        [Key]
        private string requirementId;
        private string requirementContent;
        public virtual ICollection<Job> Jobs { get; set; }
        public string RequirementId { get => requirementId;}
        public string RequirementContent { get => requirementContent; set => requirementContent = value; }

        public Requirement()
        {
            Jobs= new HashSet<Job>();
        }
    }
}
