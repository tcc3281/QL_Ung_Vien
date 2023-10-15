using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Candidate
    {
        [Key]
        public string candidateID;
        public string fullName;
        public string email;
        public string cV;
        public int cStatement;
        public string cImage;
        public string phoneNumber;
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
