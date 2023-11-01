using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Pkcs;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using QL_Ung_Vien.Areas.Identity.Data;
using QL_Ung_Vien.Models;

namespace QL_Ung_Vien.Controllers
{
    
    public class JobController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment _environment;

        public JobController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            _environment = environment; 
        }

        // GET: Job
        public IActionResult Index()
        {
            var jobs = (from c in db.Jobs select c).OrderBy(x => x.jobID);
            return View(jobs);
        }

        // GET: Job/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || db.Jobs == null)
            {
                return NotFound();
            }

            var job = db.Jobs.Find(id);
            if (job == null)
            {
                return NotFound();
            }

            ViewBag.url = db.Images.Find(job.ImageID).path;
            return View(job);
        }

        // GET: Job/Create
        [Authorize(Roles ="Admin,HR")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Admin,HR")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Job job)
        {
            job.jobName = job.jobName.Trim();
            Console.WriteLine(job.image.FileName);
            Console.WriteLine(job.image.FileName);
            Console.WriteLine(job.image==null?0:1);
            await SaveImg(job,null);
            db.Jobs.Add(job);
            db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,HR")]
        public IActionResult Edit(int? id)
        {
            if (id == null || db.Jobs == null)
            {
                return NotFound();
            }

            var job = db.Jobs.Find(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        [Authorize(Roles ="Admin,HR")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Job job)
        {
            var jb = db.Jobs.Find(job.jobID);
            jb.jobName = job.jobName.Trim();
            jb.jD = job.jD;
            jb.timeOpen = job.timeOpen;
            jb.timeClose = job.timeClose;
            await SaveImg(job, jb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,HR")]
        public IActionResult Delete(int id)
        {
            var job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Candidate")]
        public IActionResult CandidateApply(int id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            //lấy id user của candidate
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var candidate = db.Candidates.Where(c => c.Id == userID).FirstOrDefault();

            var application = db.Applications.FirstOrDefault(a => a.candidateID == candidate.candidateID && a.jobID == id);
            if (application == null)
            {
                application = new Application() { 
                    candidateID = candidate.candidateID,
                    Candidate = candidate,
                    jobID = id,
                    Job = db.Jobs.Find(id),
                    applyDate = DateTime.Now,
                    aStatement = 0
                };
                db.Applications.Add(application);

                db.SaveChanges();

                ViewBag.aStatement = application.aStatement;
            }

            var listJob = from a in db.Jobs
                          join b in db.Applications on a.jobID equals b.jobID
                          where b.candidateID == candidate.candidateID
                          select new
                          {
                              jobID = a.jobID,
                              jobName = a.jobName,
                              des = a.jD,
                              JobStatement = b.aStatement
                          };
            dynamic model;
            model = listJob.ToList();

            return RedirectToAction("ShowApply");
        }
        [Authorize(Roles = "CAndidate")]

        public IActionResult UnApply(int id)
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var candidate = db.Candidates.Where(c => c.Id == userID).FirstOrDefault();

            var application = db.Applications.FirstOrDefault(a => a.candidateID == candidate.candidateID && a.jobID == id);
            db.Applications.Remove(application);
            db.SaveChanges();
            
            var listJob = from a in db.Jobs
                          join b in db.Applications on a.jobID equals b.jobID
                          where b.candidateID == candidate.candidateID
                          select new
                          {
                              jobID = a.jobID,
                              jobName = a.jobName,
                              des = a.jD,
                              JobStatement = b.aStatement
                          };
            dynamic model;
            model = listJob.ToList();

            return View("CandidateApply", model);
        }

        public IActionResult ShowApply()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var candidate = db.Candidates.Where(c => c.Id == userID).FirstOrDefault();

            var listJob = from a in db.Jobs
                          join b in db.Applications on a.jobID equals b.jobID
                          where b.candidateID == candidate.candidateID
                          select new
                          {
                              jobID = a.jobID,
                              jobName = a.jobName,
                              des = a.jD,
                              JobStatement = b.aStatement
                          };
            dynamic model;
            model = listJob.ToList();

            return View("CandidateApply", model);
        }
        [Authorize(Roles = "Candidate,HR,Admin")]
        public IActionResult ShowCandidateApply()
        {
            var listJob = from a in db.Jobs
                          join b in db.Applications on a.jobID equals b.jobID
                          join c in db.Candidates on b.candidateID equals c.candidateID
                          select new
                          {
                              candidateID = c.candidateID,
                              jobID = a.jobID,
                              jobName = a.jobName,
                              des = a.jD,
                              CandidateName = c.firstName + " " + c.lastName,
                              JobStatement = b.aStatement
                          };
            dynamic model;
            model = listJob.ToList();

            return View("ShowCandidateApply", model);
        }

        public IActionResult ShowCandidate(int id)
        {
            var candidate = db.Candidates.Find(id);
            return View(candidate);
        }
        public async Task SaveImg(Job j,Job? job)
        {
            if (j.image != null)
            {
                
                // Sử dụng _environment.WebRootPath để lấy đường dẫn vật lý của thư mục gốc
                string folder = "..\\wwwroot\\images\\";
                folder += Guid.NewGuid().ToString() + "_" + j.image.FileName;

                var i = new Image();
                i.path = folder;

                string serverFolder = Path.Combine(_environment.WebRootPath, folder);


                await j.image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                await db.AddAsync(i);
                // Lưu đối tượng i vào database trước khi gán giá trị cho thuộc tính CVID

                await db.SaveChangesAsync();
                if (job == null)
                {
                    j.ImageID = i.imageID;
                }
                else
                {
                    job.ImageID = i.imageID;
                }
            }
        }
    }
}
