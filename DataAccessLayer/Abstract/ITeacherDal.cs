using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ITeacherDal:IGenericDal<Teacher>
    {
        Teacher TeacherLoginCheck (string username, string password);
        List<Project> ProjectListByTeacher(int id);
    }
}
