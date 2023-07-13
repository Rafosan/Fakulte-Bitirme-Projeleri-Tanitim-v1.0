using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace Fakultemiz_bitirme_projeleri_tanitim.Data.Seed
{
    public static class DataSeeder
    {
        public static void SeedAdmins(MyDbContext dbContext)
        {
            if (!dbContext.Admins.Any())
            {
                var admin = new Admin
                {
                    NameAndSurname = "Admin Name",
                    UserName = "Admin",
                    Password = "Admin123",
                    Status = true,
                    CreationTime = DateTime.Now
                };

                dbContext.Admins.Add(admin);
                dbContext.SaveChanges();
            }
        }
    }
}
