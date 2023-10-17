using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class InterviewResult
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string? iRID {  get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? comment {  get; set; }
        [Column(TypeName = "int")]
        public int? iRStatement { get; set; }//trang thai ket qua do hay chua
    }
}
