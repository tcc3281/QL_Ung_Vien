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
        private int cStatement;
        private string cImage;
        private string phoneNumber;
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
        public string CandidateID { get => candidateID; set => candidateID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Email { get => email; set => email = value; }
        public string CV { get => cV; set => cV = value; }
        public int CStatement { get => cStatement; set => cStatement = value; }
        public string CImage { get => cImage; set => cImage = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        public Candidate()
        {
            Application = new HashSet<Application>();
            Interviews = new HashSet<Interview>();
        }
    }
}
