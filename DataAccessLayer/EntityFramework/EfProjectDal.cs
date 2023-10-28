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
            return _context.Projects
                .Include(x => x.Student)
                .Include(x => x.Teacher)
                .Where(filter)
                .ToList();
        }

        public Project GetProjectByStudentId(int studentId)
        {
            return _context.Projects
            .Include(p => p.Student)
            .FirstOrDefault(p => p.StudentID == studentId);
        }
        public List<Project> GetProjectsByTeacherId(int id)
        {
            return _context.Set<Project>()
                .Include(project => project.Teacher)
                .Where(project => project.Teacher.ID == id && project.Teacher.ID == id)
                .ToList();
        }


        public List<Project> GetProjectsByCategory(Category.Types categoryType, string value)
        {
            if (categoryType == Category.Types.Yıl)
            {
                int year;
                if (Int32.TryParse(value, out year))
                {
                    return _context.Projects.Where(p => p.CreationTime.HasValue && p.CreationTime.Value.Year == year).ToList();
                }
                else
                {
                    return new List<Project>();
                }
            }
            else if (categoryType == Category.Types.Bölüm)
            {
                DepartmentCode departmentCode;
                if (Enum.TryParse(value, out departmentCode))
                {
                    return _context.Projects.Include(p => p.Student).Where(p => p.Student.DepartmentCode == departmentCode).ToList();
                }
                else
                {
                    return new List<Project>();
                }
            }
            else if (categoryType == Category.Types.Danışman)
            {
                return _context.Projects.Include(p => p.Teacher).Where(p => p.Teacher.NameAndSurname == value.ToString()).ToList();
            }
            else
            {
                return new List<Project>();
            }
        }

    }
}
