﻿using System;
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
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        private readonly MyDbContext _context;
        public EfAdminDal(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public Admin AdminLoginCheck(string username, string password)
        {
            return _context.Admins.SingleOrDefault(x => x.UserName == username && x.Password == password);
        }
    }
}
