using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_Ung_Vien.Areas.Identity.Data;
using X.PagedList;

namespace QL_Ung_Vien.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AppRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationDbContext Context { get; set; }
        public AppRolesController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
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
            int pageSize = 2;
            int pagenumber = (page ?? 1);
            var users = Context.Users.ToList();
            return PartialView("ListUser", users.ToPagedList(pagenumber, pageSize));
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
    }
}
