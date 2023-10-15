﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_Ung_Vien.Models
{
    public class Application
    {
        //[ForeignKey("Candidate")]
        private string candidateID;
        public virtual Candidate? Candidate { get; set; }
        //[ForeignKey("Job")]
        private string jobID;
        public virtual Job? Job { get; set; } 
        public string CandidateID { get => candidateID; set => candidateID = value; }
        public string JobID { get => jobID; set => jobID = value; }
        public DateTime ApplyDate { get => applyDate; set => applyDate = value; }
        public string Level { get => level; set => level = value; }
        public int AStatement { get => aStatement; set => aStatement = value; }

        private DateTime applyDate;
        private string level;
        private int aStatement;

    }
}
