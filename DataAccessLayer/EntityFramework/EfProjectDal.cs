using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfProjectDal : GenericRepository<Project>, IProjectDal
    {
        private readonly MyDbContext _context;
        public EfProjectDal(MyDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Project> GetListWithExpressionStudentAndTeacher(Expression<Func<Project, bool>> filter)
        {
            return _context.Projects.Include(x => x.Student).Include(x => x.Teacher).Where(filter).ToList();
        }

        public List<Project> GetProjectsByTeacherId(int id)
        {
            return _context.Set<Project>()
                .Include(project => project.Teacher)
                .Where(project => project.Teacher.ID == id && project.Teacher.ID == id)
                .ToList();
        }
    }
}
