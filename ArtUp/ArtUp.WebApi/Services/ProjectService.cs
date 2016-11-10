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

        public IEnumerable<Comment> GetCommentsByProject(int projectId)
        {
            return data.Comments.Find(comment => comment.ProjectId == projectId).ToList();
        }
    }
}