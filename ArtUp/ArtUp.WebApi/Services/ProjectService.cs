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

        public IEnumerable<Comment> GetCommentsByProject(int projectId)
        {
            return data.Comments.Find(comment => comment.ProjectId == projectId).ToList();
        }
    }
}