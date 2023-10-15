using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    [Table("SinhVien")]
    public class Candidate
    {
        [Key]
        private string candidateID;
        private string fullName;
        private string email;
        private string cV;
        private int state;
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }

        public string CandidateID { get => candidateID; set => candidateID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Email { get => email; set => email = value; }
        public string CV { get => cV; set => cV = value; }
        public int State { get => state; set => state = value; }

        public Candidate()
        {
            Application = new HashSet<Application>();
            Interviews = new HashSet<Interview>();
        }
    }
}
