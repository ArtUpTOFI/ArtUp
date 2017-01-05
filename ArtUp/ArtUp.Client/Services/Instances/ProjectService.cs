using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.DataAccess.Entities;
using ArtUp.DataAccess.DataContext;
using ArtUp.Client.Models;
using ArtUp.DataAccess.Entities.Enums;

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
                Location = project.Location,
                CreationDate = project.CreationDate,
                CurrentMoney = project.CurrentMoney,
                Duration = project.Duration,
                FullDescription = project.FullDescription,
                Name = project.Name,
                Image = project.Image,
                RequiredMoney = project.RequiredMoney,
                ShortDescription = project.ShortDescription,
                Surname = project.Surname,
                Category = data.Categories.Get(project.CategoryId.Value).Title,
                UserId = project.UserId.Value,
                ProjectState = project.ProjectState,
                AccountNumber = project.AccountNumber,
                Adress = project.Adress,
                DateOfBirth = project.DateOfBirth,
                DocumentType = project.DocumentType,
                MiddleName = project.MiddleName,
                PasspotNumberSeries = project.PasspotNumberSeries,
                PersonalPassportNumber = project.PersonalPassportNumber,
                PhoneNumber = project.PhoneNumber,
                WhoAndWhereIssued = project.WhoAndWhereIssued
            };
        }

        public IEnumerable<ProjectViewModel> GetAllProjects()
        {
            return data.Projects.GetAll().Select(p => new ProjectViewModel()
            {
                Avatar = p.Avatar,
                CurrentMoney = p.CurrentMoney,
                CreationDate = p.CreationDate,
                Duration = p.Duration,
                FullDescription = p.FullDescription,
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Location = p.Location,
                RequiredMoney = p.RequiredMoney,
                ShortDescription = p.ShortDescription,
                Surname = p.Surname,
                Title = p.Title,
                ProjectState = p.ProjectState
            }).ToList();
        }

        public IEnumerable<ProjectViewModel> GetByCategory(string categoty)
        {
            return data.Projects.Find(p => p.Category.Title == categoty && p.ProjectState == ProjectState.Approved)
                .Select(p => new ProjectViewModel()
                {
                    Avatar = p.Avatar,
                    CurrentMoney = p.CurrentMoney,
                    CreationDate = p.CreationDate,
                    Duration = p.Duration,
                    FullDescription = p.FullDescription,
                    Id = p.Id,
                    Name = p.Name,
                    RequiredMoney = p.RequiredMoney,
                    ShortDescription = p.ShortDescription,
                    Surname = p.Surname,
                    Title = p.Title,
                    Image = p.Image
                }).ToList();
        }

        public IEnumerable<ProjectViewModel> GetBySuccess(bool isSuccess)
        {
            var projs = isSuccess
                ? data.Projects.Find(p => p.RequiredMoney <= p.CurrentMoney && p.ProjectState == ProjectState.Approved)
                : data.Projects.Find(p => p.RequiredMoney > p.CurrentMoney && p.ProjectState == ProjectState.Approved);
            return projs.Select(p => new ProjectViewModel()
            {
                Avatar = p.Avatar,
                CurrentMoney = p.CurrentMoney,
                Duration = p.Duration,
                CreationDate = p.CreationDate,
                FullDescription = p.FullDescription,
                Id = p.Id,
                Name = p.Name,
                RequiredMoney = p.RequiredMoney,
                ShortDescription = p.ShortDescription,
                Surname = p.Surname,
                Title = p.Title,
                Image = p.Image,
            }).ToList();
        }

        public IEnumerable<ProjectViewModel> GetUserProjects(int userId)
        {
            return data.Projects.Find(p => p.UserId == userId)
                .Select(p => new ProjectViewModel()
                {
                    Avatar = p.Avatar,
                    CurrentMoney = p.CurrentMoney,
                    CreationDate = p.CreationDate,
                    Duration = p.Duration,
                    FullDescription = p.FullDescription,
                    Id = p.Id,
                    Name = p.Name,
                    RequiredMoney = p.RequiredMoney,
                    ShortDescription = p.ShortDescription,
                    Surname = p.Surname,
                    Title = p.Title,
                    Image = p.Image
                }).ToList(); ;
        }

        public IEnumerable<ProjectViewModel> GetProjectsOnMainPaige()
        {
            return
                data.Projects.Find(p => p.CurrentMoney > p.RequiredMoney && p.ProjectState == ProjectState.Approved)
                    .Take(6)
                    .Select(p => new ProjectViewModel()
                    {
                        Avatar = p.Avatar,
                        CurrentMoney = p.CurrentMoney,
                        CreationDate = p.CreationDate,
                        Duration = p.Duration,
                        FullDescription = p.FullDescription,
                        Id = p.Id,
                        Name = p.Name,
                        RequiredMoney = p.RequiredMoney,
                        ShortDescription = p.ShortDescription,
                        Surname = p.Surname,
                        Title = p.Title,
                        Image = p.Image,
                    }).ToList();
        }

        public IEnumerable<ProjectViewModel> GetNewProjects()
        {
            var bound = DateTime.Now.Date - TimeSpan.FromDays(7);
            return data.Projects.Find(p => p.CreationDate > bound && p.ProjectState == ProjectState.Approved)
                .Select(p => new ProjectViewModel()
                {
                    Avatar = p.Avatar,
                    CurrentMoney = p.CurrentMoney,
                    CreationDate = p.CreationDate,
                    Duration = p.Duration,
                    FullDescription = p.FullDescription,
                    Id = p.Id,
                    Name = p.Name,
                    RequiredMoney = p.RequiredMoney,
                    ShortDescription = p.ShortDescription,
                    Surname = p.Surname,
                    Title = p.Title,
                    Image = p.Image,
                });
        }

        public void ApproveProject(int id)
        {
            var project = data.Projects.Get(id);
            project.ProjectState = DataAccess.Entities.Enums.ProjectState.Approved;
            project.CreationDate = DateTime.Now;

            data.Projects.Update(project);
            data.SaveAll();
        }

        public void RejectProject(int id, string comment)
        {
            var project = data.Projects.Get(id);
            project.ProjectState = DataAccess.Entities.Enums.ProjectState.Rejected;
            project.ShortDescription = comment;

            data.Projects.Update(project);
            data.SaveAll();
        }

        public IEnumerable<ProjectViewModel> GetByFilter(string filter)
        {
            switch (filter)
            {
                case "new":
                    return GetNewProjects();
                case "all":
                    return GetAllProjects();
                case "best":
                    return GetBySuccess(true);
            }

            return null;
        }

        public void CreateProject(ProjectViewModel model)
        {
            string category = model.Category.ToEngName();
            model.Duration = TimeSpan.FromDays(model.Duration).Ticks;
            data.Projects.Create(new Project()
            {
                Adress = model.Adress,
                Avatar = model.Avatar,
                CreationDate = DateTime.Now,
                CurrentMoney = 0,
                DateOfBirth = model.DateOfBirth,
                DocumentType = model.DocumentType,
                Duration = model.Duration,
                FullDescription = model.FullDescription,
                MiddleName = model.MiddleName,
                Name = model.Name,
                PasspotNumberSeries = model.PasspotNumberSeries,
                PersonalPassportNumber = model.PersonalPassportNumber,
                PhoneNumber = model.PhoneNumber,
                ProjectState = DataAccess.Entities.Enums.ProjectState.PendingApproval,
                RequiredMoney = model.RequiredMoney,
                ShortDescription = model.ShortDescription,
                Surname = model.Surname,
                Title = model.Title,
                WhoAndWhereIssued = model.WhoAndWhereIssued,
                Location = model.Location,
                Image = model.Image,
                AccountNumber = model.AccountNumber,
                UserId = model.UserId,
                CategoryId = data.Categories.Find(c => c.Title == category).FirstOrDefault().Id,
            });
            data.SaveAll();
            var lastProjectId = data.Projects.Find(p => p.Title == model.Title).FirstOrDefault().Id;
            if (model.Gifts != null)
            {
                foreach (var gift in model.Gifts)
                {
                    data.Gifts.Create(new Gift()
                    {
                        AvailableCount = gift.AvailableCount,
                        CurrentCount = 0,
                        Description = gift.Description,
                        MoneyAmount = gift.MoneyAmount,
                        ProjectId = lastProjectId
                    });
                }
            }
            data.SaveAll();
        }

        public IEnumerable<ProjectViewModel> GetByState(ProjectState state, int userId)
        {
            return data.Projects.Find(p => p.ProjectState == state && userId == p.UserId)
                .Select(p => new ProjectViewModel()
                {
                    Avatar = p.Avatar,
                    CurrentMoney = p.CurrentMoney,
                    CreationDate = p.CreationDate,
                    Duration = p.Duration,
                    FullDescription = p.FullDescription,
                    Id = p.Id,
                    Image = p.Image,
                    Name = p.Name,
                    RequiredMoney = p.RequiredMoney,
                    ShortDescription = p.ShortDescription,
                    Surname = p.Surname,
                    Title = p.Title
                });
        }

        public void UpdateProject(ProjectViewModel model)
        {
            var project = data.Projects.Get(model.Id);
            project.Avatar = model.Avatar;
            project.Duration = model.Duration;
            project.FullDescription = model.FullDescription;
            project.IsSuccessful = model.IsSuccessful;
            project.ShortDescription = model.ShortDescription;
            project.WasPaid = project.WasPaid;

            data.Projects.Update(project);
            data.SaveAll();
        }

        public void DeleteProject(int projectId)
        {
            if (data.Projects.Find(p => p.Id == projectId).Any())
            {
                var gifts = data.Gifts.Find(g => g.ProjectId == projectId);
                if (gifts.Any())
                {
                    foreach (var gift in gifts)
                    {
                        data.Gifts.Delete(gift.Id);
                    }
                }
                data.Projects.Delete(projectId);
                data.SaveAll();
            }
        }
    }

    public static class AnotherHelper
    {
        public static string ToEngName(this string category)
        {
            switch (category)
            {
                case "Музыка":
                    return "music";
                case "Литература":
                    return "literature";
                case "Кино и видео":
                    return "movie";
                case "Фотография":
                    return "photo";
                case "Живопись":
                    return "art";
            }
            return null;
        }
    }
}