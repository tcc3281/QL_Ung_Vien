using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Benefit
    {
        [Key]
        private string benefitID;
        private string benefitContent;
        public virtual ICollection<Job> Jobs { get; set; }
        public string BenefitID { get => benefitID; set => benefitID = value; }
        public string BenefitContent { get => benefitContent; set => benefitContent = value; }

        public Benefit() 
        {
            Jobs=new HashSet<Job>();
        }

    }
}
