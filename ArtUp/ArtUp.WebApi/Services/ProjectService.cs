using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.DataAccess.Entities;
using ArtUp.DataAccess.DataContext;
using ArtUp.WebApi.Models;

namespace ArtUp.WebApi.Services
{
    public class ProjectService : IProjectService
    {
        ArtUpData data;

        public ProjectService()
        {
            data = new ArtUpData();
        }

        public ProjectViewModel Get(int projectId)
        {
            var project = data.Projects.Get(projectId);
            return new ProjectViewModel()
            {
                Id = project.Id,
                Title = project.Title,
                Avatar = project.Avatar,
                CurrentMoney = project.CurrentMoney,
                Duration = project.Duration,
                FullDescription = project.FullDescription,
                Name = project.Name,
                RequiredMoney = project.RequiredMoney,
                ShortDescription = project.ShortDescription,
                Surname = project.Surname
            };
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
    }
}