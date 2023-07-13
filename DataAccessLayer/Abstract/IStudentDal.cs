using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IStudentDal:IGenericDal<Student>
    {
        Student StudentLoginCheck(string username, string password);
    }
}
