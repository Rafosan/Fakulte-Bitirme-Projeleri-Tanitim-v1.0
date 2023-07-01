using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IProjectDal:IGenericDal<Project>
    {
        List<Project> GetListWithExpressionStudentAndTeacher(Expression<Func<Project, bool>> filter);
        List<Project> GetProjectsByTeacherId(int id);

    }
}
