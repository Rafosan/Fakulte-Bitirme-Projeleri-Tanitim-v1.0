using System.Linq.Expressions;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IProjectDal:IGenericDal<Project>
    {
        List<Project> GetListWithExpressionStudentAndTeacher(Expression<Func<Project, bool>> filter);
        List<Project> GetProjectsByTeacherId(int id);
        Project GetProjectByStudentId(int studentId);

        List<Project> GetProjectsByCategory(Category.Types categoryType,string value);
    }
}

