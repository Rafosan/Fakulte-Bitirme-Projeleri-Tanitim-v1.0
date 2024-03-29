﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectDal;
        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }
        public void TAdd(Project t)
        {
            _projectDal.Insert(t);
        }

        public void TDelete(Project t)
        {
            _projectDal.Delete(t);
        }

        public List<Project> TGetAll()
        {
            return _projectDal.GetAll();
        }

        public void TUpdate(Project t)
        {
            _projectDal.Update(t);
        }//
        public List<Project> TGetListWithExpressionStudentAndTeacher(int id)
        {
            return _projectDal.GetListWithExpressionStudentAndTeacher(x => x.ProjectID == id);
        }

        public Project TGetByID(int id)
        {
           return _projectDal.GetByID(id);
        }

        public List<Project> TGetProjectsByTeacherId(int id)
        {
            return _projectDal.GetProjectsByTeacherId(id);
        }

        public Project TGetProjectByStudentId(int studentId)
        {
            return _projectDal.GetProjectByStudentId(studentId);
        }

        public List<Project> TGetProjectsByCategory(Category.Types categoryType, string value)
        {
            return _projectDal.GetProjectsByCategory(categoryType, value);
        }
    }
}
