﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Application//ứng tuyển
    {
        [Column(TypeName ="varchar(20)")]
        public string candidateID { get; set; }
        public virtual Candidate? Candidate { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string jobID { get; set; }
        public virtual Job? Job { get; set; } 
        [Column(TypeName ="datetime2")]
        public DateTime applyDate { get; set; }//ngày ứng tuyển
        [Column(TypeName ="nvarchar(100)")]
        public string level { get; set; }//trình độ
        [Column(TypeName ="int")]
        public int aStatement { get; set; }//trạng thái - chưa xét duyệt - đã xét duyệt - từ chối

    }
}
