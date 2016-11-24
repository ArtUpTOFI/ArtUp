using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.DataAccess.Entities;
using ArtUp.DataAccess.DataContext;

namespace ArtUp.WebApi.Services
{
    public class ProjectService : IProjectService
    {
        ArtUpData data;

        public ProjectService()
        {
            data = new ArtUpData();
        }

        public void CreateProject(Project project)
        {
            data.Projects.Create(project);
        }

        public Project Get(int projectId)
        {
            return data.Projects.Get(projectId);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return data.Projects.GetAll().ToList();
        }

        public IEnumerable<Project> GetByCategory(string categoty)
        {
            return data.Projects.Find(p => p.Category.Title == categoty).ToList();
        }

        public IEnumerable<Project> GetBySuccess(bool isSuccess)
        {
            return isSuccess
                ? data.Projects.Find(p => p.RequiredMoney <= p.CurrentMoney).ToList()
                : data.Projects.Find(p => p.RequiredMoney > p.CurrentMoney).ToList();
        }

        public IEnumerable<Project> GetUserProjects(int userId)
        {
            return data.Projects.Find(p => p.UserId == userId).ToList();
        }

        public void UpdateProject(Project project)
        {
            data.Projects.Update(project);
        }
    }
}