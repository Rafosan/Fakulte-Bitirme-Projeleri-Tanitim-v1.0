using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class TeacherManager : ITeacherService
    {
        ITeacherDal _teacherDal;
        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public void TAdd(Teacher t)
        {
            _teacherDal.Insert(t);
        }

        public void TDelete(Teacher t)
        {
            _teacherDal.Delete(t);
        }

        public List<Teacher> TGetAll()
        {
            return _teacherDal.GetAll();
        }

        public Teacher TGetByID(int id)
        {
            return _teacherDal.GetByID(id);
        }

        public void TUpdate(Teacher t)
        {
            _teacherDal.Update(t);
        }
    }
}
