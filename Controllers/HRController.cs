using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using QL_Ung_Vien.Areas.Identity.Data;
using QL_Ung_Vien.Models;
using X.PagedList;

namespace QL_Ung_Vien.Controllers
{
    public class HRController : Controller
    {
        ApplicationDbContext db;
        public HRController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index(string name, int? page)
        {
            var hrs = (from c in db.HRs select c).OrderBy(x => x.hRID);
            if (!string.IsNullOrEmpty(name))
            {
                hrs = (IOrderedQueryable<HR>)hrs.Where(x => (x.firstName + " " + x.lastName).Contains(name));
            }

            if (page == null) page = 1;
            int pageNumber = page ?? 1;
            int pageSize = 3;
            
            return View(hrs.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HR hr)
        {
            db.HRs.Add(hr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var hr = db.HRs.Find(id);
            return View(hr);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HR hr)
        {
            var h = db.HRs.Find(hr.hRID);

            h.firstName = hr.firstName;
            h.lastName = hr.lastName;
            h.email = hr.email;
            h.phoneNumber = hr.phoneNumber;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles="Admin, HR, Candidate")]
        public IActionResult Detail(int id)
        {
            return View(db.HRs.Find(id));
        }

        public IActionResult Delete(int id)
        {
            var hr = db.HRs.Find(id);
            db.HRs.Remove(hr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
