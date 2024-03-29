﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ITeacherService:IGenericService<Teacher>
    {
        Teacher TTeacherLoginCheck(string username, string password);
        List<Project> TProjectListByTeacher(int id);
    }
}
