﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.DataAccess.Entities;
using ArtUp.DataAccess.DataContext;
using ArtUp.Client.Models;

namespace ArtUp.Client.Services
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

        public IEnumerable<ProjectViewModel> GetAllProjects()
        {
            return data.Projects.GetAll().Select(p => new ProjectViewModel()
            {
                Avatar = p.Avatar,
                CurrentMoney = p.CurrentMoney,
                Duration = p.Duration,
                FullDescription = p.FullDescription,
                Id = p.Id,
                Name = p.Name,
                RequiredMoney = p.RequiredMoney,
                ShortDescription = p.ShortDescription,
                Surname = p.Surname,
                Title = p.Title
            }).ToList();
        }

        public IEnumerable<ProjectViewModel> GetByCategory(string categoty)
        {
            return data.Projects.Find(p => p.Category.Title == categoty)
                .Select(p => new ProjectViewModel()
            {
                Avatar = p.Avatar,
                CurrentMoney = p.CurrentMoney,
                Duration = p.Duration,
                FullDescription = p.FullDescription,
                Id = p.Id,
                Name = p.Name,
                RequiredMoney = p.RequiredMoney,
                ShortDescription = p.ShortDescription,
                Surname = p.Surname,
                Title = p.Title
            }).ToList();
        }

        public IEnumerable<ProjectViewModel> GetBySuccess(bool isSuccess)
        {
            var projs = isSuccess
                ? data.Projects.Find(p => p.RequiredMoney <= p.CurrentMoney)
                : data.Projects.Find(p => p.RequiredMoney > p.CurrentMoney);
            return projs.Select(p => new ProjectViewModel()
            {
                Avatar = p.Avatar,
                CurrentMoney = p.CurrentMoney,
                Duration = p.Duration,
                FullDescription = p.FullDescription,
                Id = p.Id,
                Name = p.Name,
                RequiredMoney = p.RequiredMoney,
                ShortDescription = p.ShortDescription,
                Surname = p.Surname,
                Title = p.Title
            }).ToList();
        }

        public IEnumerable<ProjectViewModel> GetUserProjects(int userId)
        {
            return data.Projects.Find(p => p.UserId == userId)
                .Select(p => new ProjectViewModel()
            {
                Avatar = p.Avatar,
                CurrentMoney = p.CurrentMoney,
                Duration = p.Duration,
                FullDescription = p.FullDescription,
                Id = p.Id,
                Name = p.Name,
                RequiredMoney = p.RequiredMoney,
                ShortDescription = p.ShortDescription,
                Surname = p.Surname,
                Title = p.Title
            }).ToList(); ;
        }
    }
}