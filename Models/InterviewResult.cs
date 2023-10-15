using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    [Table("KetQuaPV")]
    public class InterviewResult
    {
        [Key]
        private string IRID;
        private int rStatement;
        private string comment;

        public string IRId1 { get => IRID; set => IRID = value; }
        public int State { get => rStatement; set => rStatement = value; }
        public string Comment { get => comment; set => comment = value; }
    }
}
