using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class HR
    {
        [Key]
        private string hRID;
        private string fullName;
        private string email;
        private string phoneNumber;
        private string image;
        public virtual ICollection<InterviewProcess> InterviewProcesses { get; set; }
        public string HRID { get => hRID; set => hRID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Image { get => image; set => image = value; }

        public HR()
        {
            InterviewProcesses=new HashSet<InterviewProcess>();
        }
    }
}
