using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QL_Ung_Vien.Areas.Identity.Data;
using QL_Ung_Vien.Models;

namespace QL_Ung_Vien.Controllers
{
    public class JobController : Controller
    {
        private readonly ApplicationDbContext db;

        public JobController(ApplicationDbContext db)
        {
            this.db = db;
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

            return View(job);
        }

        // GET: Job/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Add(job);
                db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Job/Edit/5
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

        // POST: Job/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                var jb = db.Jobs.Find(job.jobID);
                jb.benifitID = job.benifitID;
                jb.Benefit = job.Benefit;
                jb.requirementID = job.requirementID;
                jb.Requirement = job.Requirement;
                jb.jobName = job.jobName;
                jb.jD=job.jD;
                jb.timeOpen = job.timeOpen;
                jb.timeClose = job.timeClose;

                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }


        public IActionResult Delete(int id)
        {
            var job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
