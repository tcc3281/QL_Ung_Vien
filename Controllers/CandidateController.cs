using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_Ung_Vien.Areas.Identity.Data;
using QL_Ung_Vien.Models;
using X.PagedList;

namespace QL_Ung_Vien.Controllers
{
    public class CandidateController : Controller
    {
        ApplicationDbContext db;
        public CandidateController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index(string name, int? page)
        {
            //if (statement == null)
            //{
            //    return View(db.Candidates.ToList());
            //}
            //else
            //{
            //    var candidate = db.Candidates.Where(c => c.cStatement == statement)
            //        .ToList();
            //    return View(candidate);
            //}

            var candidates = (from c in db.Candidates select c).OrderBy( x=> x.candidateID);
            if (!string.IsNullOrEmpty(name))
            {
                candidates = (IOrderedQueryable<Candidate>)candidates.Where(x => (x.firstName + " " + x.lastName).Contains(name));
            }
            
            if (page == null) page = 1;
            int pageNumber = page ?? 1;
            int pageSize = 3;

            return View(candidates.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Candidate c, IFormFile cv, IFormFile img)
        {
            for(int i = 1; i <= db.Candidates.Count()+1; i++)
            {
                if(db.Candidates.Find(i) == null)
                {
                    c.candidateID = i;
                    break;
                }
            }

            if (cv != null && img != null)
            {
                //img
                string imgName = img.FileName;
                //combine gộp path
                var pathImg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/candidate", imgName);
                var streamImg = new FileStream(pathImg, FileMode.Create);
                img.CopyToAsync(streamImg);

                string urlImg = "/images/candidate/" + imgName;

                //cv
                string cvName = cv.FileName;
                //combine gộp path
                var pathCV = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CVs/candidate", cvName);
                var streamCV = new FileStream(pathCV, FileMode.Create);
                cv.CopyToAsync(streamCV);

                string urlCV = "/CVs/candidate/" + cvName;
            }

            //for (int i = 0; i < db.Images.Count() + 1; i++)
            //{
            //    if (db.Images.Find(i) == null)
            //    {
            //        c.CVID = i;
            //        break;
            //    }
            //}

            db.Candidates.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null || db.Candidates == null)
            {
                return NotFound();
            }

            var candidate = db.Candidates.Find(id);

            if (candidate == null)
            {
                NotFound();
            }

            return View(candidate);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(Candidate c)
        {
            var candidate = db.Candidates.Find(c.candidateID);

            candidate.firstName = c.firstName;
            candidate.lastName = c.lastName;
            candidate.email = c.email;
            candidate.phoneNumber = c.phoneNumber;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            if (id == null || db.Candidates == null)
            {
                return NotFound();
            }

            var candidate = db.Candidates.Find(id);

            if (candidate == null)
            {
                NotFound();
            }

            return View(candidate);
        }

        public IActionResult Delete(int id)
        {
            var candidate = db.Candidates.Find(id);
            db.Candidates.Remove(candidate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
