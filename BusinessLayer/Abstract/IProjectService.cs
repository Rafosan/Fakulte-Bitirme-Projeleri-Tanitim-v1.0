﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IProjectService:IGenericService<Project>
    {
        List<Project> TGetListWithExpressionStudentAndTeacher(int id);
        List<Project> TGetProjectsByTeacherId(int id);
        Project TGetProjectByStudentId(int studentId);

        List<Project> TGetProjectsByCategory(Category.Types categoryType, string value);
    }
}
