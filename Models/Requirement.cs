using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Requirement
    {
        [Key]
        private string requirementID;
        private string requirementContent;
        public virtual ICollection<Job> Jobs { get; set; }
        public string RequirementID { get => requirementID; set => requirementID = value; }
        public string RequirementContent { get => requirementContent; set => requirementContent = value; }

        public Requirement()
        {
            Jobs= new HashSet<Job>();
        }
    }
}
