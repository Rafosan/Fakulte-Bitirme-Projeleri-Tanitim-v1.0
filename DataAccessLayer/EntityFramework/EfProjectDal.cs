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
    public class EfProjectDal : GenericRepository<Project>, IProjectDal
    {
        public EfProjectDal(MyDbContext context) : base(context)
        {
        }
        public List<Project> GetListWithCategory()
        {
            throw new NotImplementedException();
        }
    }
}
