using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QL_Ung_Vien.Migrations
{
    public partial class initDataCandidate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benefit",
                columns: table => new
                {
                    benefitID = table.Column<string>(type: "varchar(10)", nullable: false),
                    benefitContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefit", x => x.benefitID);
                });

            migrationBuilder.CreateTable(
                name: "CV",
                columns: table => new
                {
                    cVID = table.Column<string>(type: "varchar(20)", nullable: false),
                    path = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.cVID);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    imageID = table.Column<string>(type: "varchar(20)", nullable: false),
                    path = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.imageID);
                });

            migrationBuilder.CreateTable(
                name: "InterviewResult",
                columns: table => new
                {
                    iRID = table.Column<string>(type: "varchar(20)", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    iRStatement = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewResult", x => x.iRID);
                });

            migrationBuilder.CreateTable(
                name: "Requirement",
                columns: table => new
                {
                    requirementID = table.Column<string>(type: "varchar(20)", nullable: false),
                    requirementContent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirement", x => x.requirementID);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    candidateID = table.Column<string>(type: "varchar(20)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", nullable: true),
                    cStatement = table.Column<int>(type: "int", nullable: true),
                    ImageID = table.Column<string>(type: "varchar(20)", nullable: true),
                    CVID = table.Column<string>(type: "varchar(20)", nullable: true),
                    phoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.candidateID);
                    table.ForeignKey(
                        name: "FK_Candidate_CV_CVID",
                        column: x => x.CVID,
                        principalTable: "CV",
                        principalColumn: "cVID");
                    table.ForeignKey(
                        name: "FK_Candidate_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "imageID");
                });

            migrationBuilder.CreateTable(
                name: "HR",
                columns: table => new
                {
                    hRID = table.Column<string>(type: "varchar(20)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", nullable: true),
                    phoneNumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    ImageID = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR", x => x.hRID);
                    table.ForeignKey(
                        name: "FK_HR_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "imageID");
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    jobID = table.Column<string>(type: "varchar(20)", nullable: false),
                    benifitID = table.Column<string>(type: "varchar(20)", nullable: true),
                    benefitID = table.Column<string>(type: "varchar(10)", nullable: true),
                    requirementID = table.Column<string>(type: "varchar(20)", nullable: true),
                    jobName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    jD = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    timeOpen = table.Column<DateTime>(type: "datetime", nullable: true),
                    timeClose = table.Column<DateTime>(type: "datetime", nullable: true),
                    ImageID = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.jobID);
                    table.ForeignKey(
                        name: "FK_Job_Benefit_benefitID",
                        column: x => x.benefitID,
                        principalTable: "Benefit",
                        principalColumn: "benefitID");
                    table.ForeignKey(
                        name: "FK_Job_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "imageID");
                    table.ForeignKey(
                        name: "FK_Job_Requirement_requirementID",
                        column: x => x.requirementID,
                        principalTable: "Requirement",
                        principalColumn: "requirementID");
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    candidateID = table.Column<string>(type: "varchar(20)", nullable: false),
                    jobID = table.Column<string>(type: "varchar(20)", nullable: false),
                    applyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    level = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    aStatement = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => new { x.jobID, x.candidateID });
                    table.ForeignKey(
                        name: "FK_Application_Candidate_candidateID",
                        column: x => x.candidateID,
                        principalTable: "Candidate",
                        principalColumn: "candidateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application_Job_jobID",
                        column: x => x.jobID,
                        principalTable: "Job",
                        principalColumn: "jobID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    interviewID = table.Column<string>(type: "varchar(20)", nullable: false),
                    jobID = table.Column<string>(type: "varchar(20)", nullable: true),
                    candidateID = table.Column<string>(type: "varchar(20)", nullable: true),
                    interviewDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.interviewID);
                    table.ForeignKey(
                        name: "FK_Interview_Candidate_candidateID",
                        column: x => x.candidateID,
                        principalTable: "Candidate",
                        principalColumn: "candidateID");
                    table.ForeignKey(
                        name: "FK_Interview_Job_jobID",
                        column: x => x.jobID,
                        principalTable: "Job",
                        principalColumn: "jobID");
                });

            migrationBuilder.CreateTable(
                name: "InterviewProcess",
                columns: table => new
                {
                    ipID = table.Column<string>(type: "varchar(20)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    interviewID = table.Column<string>(type: "varchar(20)", nullable: true),
                    hRID = table.Column<string>(type: "varchar(20)", nullable: true),
                    iRID = table.Column<string>(type: "varchar(20)", nullable: true),
                    InterviewResultiRID = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewProcess", x => x.ipID);
                    table.ForeignKey(
                        name: "FK_InterviewProcess_HR_hRID",
                        column: x => x.hRID,
                        principalTable: "HR",
                        principalColumn: "hRID");
                    table.ForeignKey(
                        name: "FK_InterviewProcess_Interview_interviewID",
                        column: x => x.interviewID,
                        principalTable: "Interview",
                        principalColumn: "interviewID");
                    table.ForeignKey(
                        name: "FK_InterviewProcess_InterviewResult_InterviewResultiRID",
                        column: x => x.InterviewResultiRID,
                        principalTable: "InterviewResult",
                        principalColumn: "iRID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_candidateID",
                table: "Application",
                column: "candidateID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_CVID",
                table: "Candidate",
                column: "CVID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_ImageID",
                table: "Candidate",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_ImageID",
                table: "HR",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_candidateID",
                table: "Interview",
                column: "candidateID");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_jobID",
                table: "Interview",
                column: "jobID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewProcess_hRID",
                table: "InterviewProcess",
                column: "hRID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewProcess_interviewID",
                table: "InterviewProcess",
                column: "interviewID");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewProcess_InterviewResultiRID",
                table: "InterviewProcess",
                column: "InterviewResultiRID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_benefitID",
                table: "Job",
                column: "benefitID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_ImageID",
                table: "Job",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_requirementID",
                table: "Job",
                column: "requirementID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "InterviewProcess");

            migrationBuilder.DropTable(
                name: "HR");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropTable(
                name: "InterviewResult");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "CV");

            migrationBuilder.DropTable(
                name: "Benefit");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Requirement");
        }
    }
}
