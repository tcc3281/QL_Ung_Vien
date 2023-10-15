using Microsoft.EntityFrameworkCore;

namespace QL_Ung_Vien.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new QL_Ung_VienContext(serviceProvider.GetRequiredService<DbContextOptions<QL_Ung_VienContext>>()))
            {
                context.Database.EnsureCreated();
                context.SaveChanges();
            }
        }
    }
}
