using Microsoft.EntityFrameworkCore;

namespace QL_Ung_Vien.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new QL_Ung_VienContext(serviceProvider.GetRequiredService<DbContextOptions<QL_Ung_VienContext>>()))
            {
                //EnsureCreated(); Kiểm tra xem database có được tạo mới hay không nếu có trả về true và tạo database
                //false nếu đã có
                context.Database.EnsureCreated();
                context.SaveChanges();
            }
        }
    }
}
