using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QL_Ung_Vien.Areas.Identity.Data;
using QL_Ung_Vien.Models;
using System.Security.Claims;
using System.Xml.Linq;

namespace QL_Ung_Vien.Controllers
{
    public class DefaultController : Controller
    {
        ApplicationDbContext db;
        
        private readonly UserManager<ApplicationUser> _userManager;

        public DefaultController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            this.db = db;
        }

        public async Task<ActionResult> Index()
        {
            // Lấy thông tin user bằng ID
            var userDetails = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            string firstName = applicationUser?.firstName;
            string lastName = applicationUser?.lastName;
            string iduser = applicationUser?.Id;
            // Hiển thị thông tin người dùng
            var Candidate = db.Candidates.Where(c => c.Id == iduser).FirstOrDefault();
            int canID = Candidate.candidateID;
            Console.WriteLine("Hello " + iduser);
            return RedirectToAction("Detail", "Candidate", new { id =  canID});
        }
    }
}
