using Microsoft.AspNetCore.Authorization;
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
            string idUser = applicationUser?.Id;
            // Hiển thị thông tin người dùng

            var user1 = db.Candidates.Where(c => c.Id == idUser).FirstOrDefault();
            var user2 = db.HRs.Where(h => h.Id == idUser).FirstOrDefault();
            
            if(user1 != null) 
            {
                int canID = user1.candidateID;
                //Console.WriteLine("Hello " + idUser);
                return RedirectToAction("Detail", "Candidate", new { id =  canID});
            }
            else
            {
                int hrID = user2.hRID;
                //Console.WriteLine("Hello " + idUser);
                return RedirectToAction("Detail", "HR", new { id = hrID });
            }
        }
    }
}
