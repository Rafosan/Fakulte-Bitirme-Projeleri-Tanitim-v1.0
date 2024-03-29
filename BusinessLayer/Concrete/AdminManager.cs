﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void TAdd(Admin t)
        {
            _adminDal.Insert(t);
        }

        public Admin TAdminLoginCheck(string username, string password)
        {
            return _adminDal.AdminLoginCheck(username, password);
        }

        public void TDelete(Admin t)
        {
            _adminDal.Delete(t);
        }

        public List<Admin> TGetAll()
        {
           return _adminDal.GetAll();
        }

        public Admin TGetByID(int id)
        {
            return _adminDal.GetByID(id);
        }

        public void TUpdate(Admin t)
        {
            _adminDal.Update(t);
        }
    }
}
