using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using QL_Ung_Vien.Areas.Identity.Data;
using QL_Ung_Vien.Models;
using X.PagedList;


namespace QL_Ung_Vien.Controllers
{
    [Authorize(Roles = "HR, Admin, Candidate")]
    public class CandidateController : Controller
    {
        private ApplicationDbContext db;
        private readonly IWebHostEnvironment _environment;
        public CandidateController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            this.db = db;
            _environment = environment; 
        }
        public IActionResult Index(string name, int? page)
        {
            
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
        public async Task<IActionResult> Edit(int? id)
        {
            return View(db.Candidates.Find(id));
        }
        // Action để chỉnh sửa thông tin của ứng viên
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken] // Thêm tham số này để ngăn chặn tấn công giả mạo yêu cầu
        
        public async Task<IActionResult> Edit(Candidate c)
        {
            var candidate = db.Candidates.Find(c.candidateID);

            // Thêm điều kiện này để kiểm tra ứng viên có tồn tại hay không
            if (candidate == null)
            {
                return NotFound();
            }
            var user = db.Users.FirstOrDefault(x => x.Id == candidate.Id);
            user.firstName = candidate.firstName = c.firstName;
            user.lastName= candidate.lastName = c.lastName;
            user.PhoneNumber=candidate.phoneNumber = c.phoneNumber;
            //giúp chạy đồng bộ
            await SaveImg(c, candidate);
            await SaveCV(c, candidate);

            // Thêm phương thức await vào lệnh này để lưu dữ liệu đồng bộ và an toàn
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Detail(int id)
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
            Image temp= db.Images.Where(m => m.imageID == candidate.ImageID).FirstOrDefault();
            ViewBag.url = CandidateController.ConvertPath(temp.path);
            return View(candidate);
        }

        public IActionResult Delete(int id)
        {
            var candidate = db.Candidates.Find(id);
            db.Candidates.Remove(candidate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task SaveImg(Candidate c,Candidate candidate)
        {
            if (c.image != null)
            {
                if (true)
                {
                    // Sử dụng _environment.WebRootPath để lấy đường dẫn vật lý của thư mục gốc
                    string folder = "..\\wwwroot\\images\\";
                    folder += Guid.NewGuid().ToString() + "_" + c.image.FileName;

                    var i = new Image();
                    i.path = folder;

                    string serverFolder = Path.Combine(_environment.WebRootPath, folder);

                    await c.image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    db.Add(i);
                    // Lưu đối tượng i vào database trước khi gán giá trị cho thuộc tính CVID
                    await db.SaveChangesAsync();
                    candidate.ImageID = i.imageID;
                }
            }
        }
        public async Task SaveCV(Candidate c, Candidate candidate)
        {
            if (c.cv!=null)
            {
                if (true)
                {
                    // Sử dụng _environment.WebRootPath để lấy đường dẫn vật lý của thư mục gốc
                    string folder = "..\\wwwroot\\CVs\\";
                    folder += Guid.NewGuid().ToString() + "_" + c.cv.FileName;

                    var i = new CV();
                    i.path = folder;
                    string serverFolder = Path.Combine(_environment.WebRootPath, folder);

                    await c.cv.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    db.Add(i);
                    // Lưu đối tượng i vào database trước khi gán giá trị cho thuộc tính CVID
                    await db.SaveChangesAsync();
                    candidate.CVID = i.cVID;
                }
            }
        }
        public static string ConvertPath(string relativePath)
        {
            // Kiểm tra xem chuỗi có rỗng hay không
            if (string.IsNullOrEmpty(relativePath))
            {
                // Nếu rỗng, trả về chuỗi rỗng
                return "";
            }
            // Loại bỏ phần ..\wwwroot\ nếu có
            if (relativePath.StartsWith(@"..\wwwroot\"))
            {
                relativePath = relativePath.Remove(0, 11);
            }
            // Thay thế ký tự \ bằng /
            relativePath = relativePath.Replace(@"\", "/");
            // Trả về chuỗi đường dẫn tuyệt đối
            return "/" + relativePath;
        }
        [HttpGet]
        public async Task<FileResult> DownloadCV(int id)
        {
            Console.WriteLine("");
            Console.WriteLine(id);
            var temp = await db.Candidates.FirstOrDefaultAsync(m => m.candidateID == id);
           
            var cv = await db.CVs.FirstOrDefaultAsync(k => k.cVID == temp.CVID);

            if (cv == null)
            {
                return null;
            }

            string fileName = temp.firstName + temp.lastName + temp.candidateID.ToString() + ".pdf";
            Console.WriteLine("");
            Console.WriteLine(cv.path);
            byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(cv.path.Remove(0,1));

            return File(fileBytes, "application/pdf", fileName);
        }

    }
}
