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
    public class BenefitController : Controller
    {
        private readonly ApplicationDbContext db;

        public BenefitController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET: Benefit
        public async Task<IActionResult> Index()
        {
              return db.Benefits != null ? 
                          View(await db.Benefits.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Benefits'  is null.");
        }

        // GET: Benefit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.Benefits == null)
            {
                return NotFound();
            }

            var benefit = await db.Benefits
                .FirstOrDefaultAsync(m => m.benefitID == id);
            if (benefit == null)
            {
                return NotFound();
            }

            return View(benefit);
        }

        // GET: Benefit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Benefit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("benefitID,benefitContent")] Benefit benefit)
        {
            if (ModelState.IsValid)
            {
                db.Add(benefit);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(benefit);
        }

        // GET: Benefit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.Benefits == null)
            {
                return NotFound();
            }

            var benefit = await db.Benefits.FindAsync(id);
            if (benefit == null)
            {
                return NotFound();
            }
            return View(benefit);
        }

        // POST: Benefit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("benefitID,benefitContent")] Benefit benefit)
        {
            if (id != benefit.benefitID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(benefit);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BenefitExists(benefit.benefitID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(benefit);
        }

        // GET: Benefit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.Benefits == null)
            {
                return NotFound();
            }

            var benefit = await db.Benefits
                .FirstOrDefaultAsync(m => m.benefitID == id);
            if (benefit == null)
            {
                return NotFound();
            }

            return View(benefit);
        }

        // POST: Benefit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.Benefits == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Benefits'  is null.");
            }
            var benefit = await db.Benefits.FindAsync(id);
            if (benefit != null)
            {
                db.Benefits.Remove(benefit);
            }
            
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BenefitExists(int id)
        {
          return (db.Benefits?.Any(e => e.benefitID == id)).GetValueOrDefault();
        }
    }
}
