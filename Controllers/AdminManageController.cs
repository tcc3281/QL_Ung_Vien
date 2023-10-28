using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_Ung_Vien.Areas.Identity.Data;
using X.PagedList;

namespace QL_Ung_Vien.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminManageController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationDbContext Context { get; set; }
        public AdminManageController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            Context = context;
        }
        //List all roles are created by users
        public IActionResult Index()
        {
            var role = _roleManager.Roles;
            return View(role);
        }
        public async Task<IActionResult> ListUser(int ? page)
        {
            int pageSize = 7;
            int pagenumber = (page ?? 1);
            if (Context.Users == null)
            {
                return NotFound();
            }
            var query = from a in Context.Users
                        join b in Context.UserRoles on a.Id equals b.UserId
                        join c in Context.Roles on b.RoleId equals c.Id
                        select new
                        {
                            Id = a.Id,
                            firstName = a.firstName,
                            lastName = a.lastName,
                            Email = a.Email,
                            PhoneNumber = a.PhoneNumber,
                            ChucVu = c.Name

                        };
            dynamic model;
            model = query.ToPagedList(pagenumber, pageSize);

            if (model == null)
            {
                return NotFound();
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if(!_roleManager.RoleExistsAsync(role.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole { Name = role.Name }).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(string? detail)
        {
            if (detail == null || Context.Users == null)
            {
                return NotFound();
            }
            ApplicationUser user =await Context.Users.Where(m=>m.Id==detail).FirstOrDefaultAsync();
            var temp1 = await Context.Candidates.Where(m=>m.Id==user.Id).FirstOrDefaultAsync();
            ViewBag.Can = temp1;
            var temp2 = await Context.HRs.Where(m => m.Id == user.Id).FirstOrDefaultAsync();
            ViewBag.HR = temp2;
            if (user == null)
            {
                return Content(detail);
            }
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string? id)
        {
            if (Context.Users == null)
            {
                return Problem("Entity set 'SchoolContext.Users'  is null.");
            }

            var user = await Context.Users.FindAsync(id);

            var q = from a in Context.Candidates join b in Context.Users on a.Id equals b.Id
                    where b.Id == id
                    select new {id=b.Id,canID=a.candidateID };

            var h = from a in Context.HRs
                    join b in Context.Users on a.Id equals b.Id
                    where b.Id == id
                    select new { id = b.Id, canID = a.hRID };
            if (q.First().canID != null)
            {
                Context.Candidates.Remove(
                    Context.Candidates.Where(l => l.candidateID == q.First().canID).FirstOrDefault()
                    );
            }
            if (user != null)
            {
                Context.Users.Remove(user);
            }
            await Context.SaveChangesAsync();
            return RedirectToAction("ListUser");
        }
        [HttpPost, ActionName("EditUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(string ? id)
        {
            return View();
        }
    }
}
