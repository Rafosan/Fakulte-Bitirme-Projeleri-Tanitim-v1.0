using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfStudentDal : GenericRepository<Student>, IStudentDal
    {
        private readonly MyDbContext _context;
        public EfStudentDal(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public Student StudentLoginCheck(string username, string password)
        {
            return _context.Students.SingleOrDefault(x => x.UserName == username && x.Password == password);
        }
    }
}
