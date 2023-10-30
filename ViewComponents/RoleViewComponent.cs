using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QL_Ung_Vien.Areas.Identity.Data;

namespace QL_Ung_Vien.ViewComponents
{
    public class RoleViewComponent:ViewComponent
    {
        ApplicationDbContext _context;
        List<IdentityRole> _roles;
        public RoleViewComponent(ApplicationDbContext context)
        {
            _context = context;
            _roles=_context.Roles.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View("RenderRole", _roles);
        }
    }
}
