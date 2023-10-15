using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    [Table("HR")]
    public class HR
    {
        [Key]
        private string HRID;
        private string fullName;
        private string email;
        private string phoneNumber;
        private string image;
        public virtual ICollection<InterviewProcess> InterviewProcesses { get; set; }
        public string HRId { get => HRID; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Image { get => image; set => image = value; }
    }
}
