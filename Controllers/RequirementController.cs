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
    public class RequirementController : Controller
    {
        private readonly ApplicationDbContext db;

        public RequirementController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET: Requirement
        public async Task<IActionResult> Index()
        {
              return db.Requirements != null ? 
                          View(await db.Requirements.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Requirements'  is null.");
        }

        // GET: Requirement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.Requirements == null)
            {
                return NotFound();
            }

            var requirement = await db.Requirements
                .FirstOrDefaultAsync(m => m.requirementID == id);
            if (requirement == null)
            {
                return NotFound();
            }

            return View(requirement);
        }

        // GET: Requirement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Requirement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("requirementID,requirementContent")] Requirement requirement)
        {
            if (ModelState.IsValid)
            {
                db.Add(requirement);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requirement);
        }

        // GET: Requirement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.Requirements == null)
            {
                return NotFound();
            }

            var requirement = await db.Requirements.FindAsync(id);
            if (requirement == null)
            {
                return NotFound();
            }
            return View(requirement);
        }

        // POST: Requirement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("requirementID,requirementContent")] Requirement requirement)
        {
            if (id != requirement.requirementID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(requirement);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequirementExists(requirement.requirementID))
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
            return View(requirement);
        }

        // GET: Requirement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.Requirements == null)
            {
                return NotFound();
            }

            var requirement = await db.Requirements
                .FirstOrDefaultAsync(m => m.requirementID == id);
            if (requirement == null)
            {
                return NotFound();
            }

            return View(requirement);
        }

        // POST: Requirement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.Requirements == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Requirements'  is null.");
            }
            var requirement = await db.Requirements.FindAsync(id);
            if (requirement != null)
            {
                db.Requirements.Remove(requirement);
            }
            
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequirementExists(int id)
        {
          return (db.Requirements?.Any(e => e.requirementID == id)).GetValueOrDefault();
        }
    }
}
