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
    //bunları da bu şekilde eklemen lazım birde yine DI a ITeacherDal istenirse  EfTeacherDal
    //ver gibisinden eklemen lazım diğerlerini de
    public class EfTeacherDal : GenericRepository<Teacher>, ITeacherDal
    {
        public EfTeacherDal(MyDbContext context) : base(context)
        {
        }
    }
}
