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
        private ApplicationDbContext db;
        private readonly IWebHostEnvironment _environment;

        public HRController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            _environment = environment;
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

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken] // Thêm tham số này để ngăn chặn tấn công giả mạo yêu cầu
        public async Task<IActionResult> Edit(HR h)
        {
            var hr = db.HRs.Find(h.hRID);

            // Thêm điều kiện này để kiểm tra ứng viên có tồn tại hay không
            if (hr == null)
            {
                return NotFound();
            }

            hr.firstName = h.firstName;
            hr.lastName = h.lastName;
            hr.email = h.email;
            hr.phoneNumber = h.phoneNumber;
            SaveImg(h, hr);

            // Thêm phương thức await vào lệnh này để lưu dữ liệu đồng bộ và an toàn
            await db.SaveChangesAsync();
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
        public async Task SaveImg(HR h, HR hr)
        {
            if (h.image != null)
            {
                // Sử dụng _environment.WebRootPath để lấy đường dẫn vật lý của thư mục gốc
                string folder = "..\\wwwroot\\images\\";
                folder += Guid.NewGuid().ToString() + "_" + h.image.FileName;

                var i = new Image();
                i.path = folder;

                string serverFolder = Path.Combine(_environment.WebRootPath, folder);

                await h.image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                db.Add(i);
                // Lưu đối tượng i vào database trước khi gán giá trị cho thuộc tính CVID
                await db.SaveChangesAsync();
                hr.ImageID = i.imageID;
            }
        }
    }
}
