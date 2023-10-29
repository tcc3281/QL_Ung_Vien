using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QL_Ung_Vien.Areas.Identity.Data;
using QL_Ung_Vien.Models;
using System.Reflection.Emit;

namespace QL_Ung_Vien.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public virtual DbSet<Candidate> Candidates { get; set; }
    public virtual DbSet<HR> HRs { get; set; }
    public virtual DbSet<Requirement> Requirements { get; set; }
    public virtual DbSet<Benefit> Benefits { get; set; }
    public virtual DbSet<Job> Jobs { get; set; }
    public virtual DbSet<Application> Applications { get; set; }
    public virtual DbSet<Interview> Interviews { get; set; }
    public virtual DbSet<InterviewResult> InterviewsResults { get; set; }
    public virtual DbSet<InterviewProcess> InterviewsProcesses { get; set; }
    public virtual DbSet<Image> Images { get; set; }
    public virtual DbSet<CV> CVs { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Application>().HasKey(a => new { a.jobID, a.candidateID });

        //nap du lieu
        builder.Entity<Candidate>().ToTable(nameof(Candidate));
        builder.Entity<HR>().ToTable(nameof(HR));
        builder.Entity<Benefit>().ToTable(nameof(Benefit));
        builder.Entity<Requirement>().ToTable(nameof(Requirement));
        builder.Entity<Job>().ToTable(nameof(Job));
        builder.Entity<Application>().ToTable(nameof(Application));
        builder.Entity<Interview>().ToTable(nameof(Interview));
        builder.Entity<InterviewResult>().ToTable(nameof(InterviewResult));
        builder.Entity<InterviewProcess>().ToTable(nameof(InterviewProcess));
        builder.Entity<Image>().ToTable(nameof(Image));
        builder.Entity<CV>().ToTable(nameof(CV));
        base.OnModelCreating(builder);
        
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.firstName).HasMaxLength(100);
        builder.Property(x => x.lastName).HasMaxLength(100);
    }
}