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

        public Project Get(int projectId)
        {
            return data.Projects.Get(projectId);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return data.Projects.GetAll().ToList();
        }

        public IEnumerable<Project> GetByCategory(Category categoty)
        {
            return data.Projects.Find(p => p.Category == categoty).ToList();
        }

        public IEnumerable<Project> GetBySuccess(bool isSuccess)
        {
            return isSuccess
                ? data.Projects.Find(p => p.RequiredMoney <= p.CurrentMoney).ToList()
                : data.Projects.Find(p => p.RequiredMoney > p.CurrentMoney).ToList();
        }

        public IEnumerable<Comment> GetCommentsByProject(int projectId)
        {
            return data.Comments.Find(comment => comment.ProjectId == projectId).ToList();
        }
    }
}