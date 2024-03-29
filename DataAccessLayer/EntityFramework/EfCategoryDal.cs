﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly MyDbContext _context;
        public EfCategoryDal(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public Category GetCategoryByValue(Category.Types types, string value)
        {
            return _context.Categorys.FirstOrDefault(c => c.Type == types && c.Value == value);
        }
    }
}
