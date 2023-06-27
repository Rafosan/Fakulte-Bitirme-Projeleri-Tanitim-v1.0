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
    public class EfTeacherDal : GenericRepository<Teacher>, ITeacherDal
    {
        private readonly MyDbContext _context;
        public EfTeacherDal(MyDbContext context) : base(context)
        {
            _context = context;
        }

        

        public Teacher TeacherLoginCheck(string username, string password)
        {
            return _context.Teachers.SingleOrDefault(x => x.UserName == username && x.Password == password);
        }

        List<Project> ITeacherDal.ProjectListByTeacher(int id)
        {
            return _context.Teachers
                    .Where(t => t.ID == id)
                    .SelectMany(t => t.Projects)
                    .ToList();
        }
    }
}
