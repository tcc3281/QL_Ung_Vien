using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class InterviewResult
    {
        [Key]
        private string iRID;
        private int rStatement;
        private string comment;

        public string IRID { get => iRID; set => iRID = value; }
        public int RStatement { get => rStatement; set => rStatement = value; }
        public string Comment { get => comment; set => comment = value; }
    }
}
