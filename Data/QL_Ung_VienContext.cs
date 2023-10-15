using Microsoft.EntityFrameworkCore;
using QL_Ung_Vien.Models;

namespace QL_Ung_Vien.Data
{
    public class QL_Ung_VienContext:DbContext
    {
        public QL_Ung_VienContext(DbContextOptions<QL_Ung_VienContext> options) : base(options) { }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<HR> HRs { get; set; }
        public virtual DbSet<Requirement> Requirements { get; set; }
        public virtual DbSet<Benefit> Benefits { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Interview> Interviews { get; set; }
        public virtual DbSet<InterviewResult> InterviewsResults { get; set; }
        public virtual DbSet<InterviewProcess> InterviewsProcesses { get; set; }
        
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasKey(a => new { a.CandidateID });
            modelBuilder.Entity<HR>().HasKey(a => new { a.HRID });
            modelBuilder.Entity<Requirement>().HasKey(a => new { a.RequirementID });
            modelBuilder.Entity<Benefit>().HasKey(a => new { a.BenefitID });
            modelBuilder.Entity<Job>().HasKey(a => new { a.JobID });
            modelBuilder.Entity<Interview>().HasKey(a => new { a.InterviewID});
            modelBuilder.Entity<Application>().HasKey(a => new { a.JobID, a.CandidateID });
            modelBuilder.Entity<InterviewProcess>().HasKey(a => new { a.IDID });
            modelBuilder.Entity<InterviewResult>().HasKey(a => new { a.IRID });        
            
            modelBuilder.Entity<Candidate>().ToTable(nameof(Candidate));
            modelBuilder.Entity<HR>().ToTable(nameof(HR));
            modelBuilder.Entity<Benefit>().ToTable(nameof(Benefit));
            modelBuilder.Entity<Requirement>().ToTable(nameof(Requirement));
            modelBuilder.Entity<Job>().ToTable(nameof(Job));
            modelBuilder.Entity<Application>().ToTable(nameof(Application));
            modelBuilder.Entity<Interview>().ToTable(nameof(Interview));
            modelBuilder.Entity<InterviewResult>().ToTable(nameof(InterviewResult));
            modelBuilder.Entity<InterviewProcess>().ToTable(nameof(InterviewProcess));
        }
    }
}
