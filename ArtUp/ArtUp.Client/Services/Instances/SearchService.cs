﻿using ArtUp.Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.Client.Models;
using ArtUp.DataAccess.DataContext;

namespace ArtUp.Client.Services.Instances
{
    public class SearchService : ISearchService
    {
        ArtUpData data;

        public SearchService()
        {
            data = new ArtUpData();
        }

        public IEnumerable<ProjectViewModel> SearchFromMain(string model)
        {
            var results = data.Projects.Find(p => p.Title.Contains(model) && p.ProjectState == DataAccess.Entities.Enums.ProjectState.Approved);
            return results.Any() ? 
                results.Select(p => new ProjectViewModel()
                {
                    Avatar = p.Avatar,
                    CurrentMoney = p.CurrentMoney,
                    Duration = p.Duration,
                    RequiredMoney = p.RequiredMoney,
                    Title = p.Title,
                    ShortDescription = p.ShortDescription,
                    FullDescription = p.FullDescription,
                    CreationDate = p.CreationDate,
                    Id = p.Id,
                    UserId = p.UserId.Value,
                    WasPaid = p.WasPaid,
                    IsSuccessful = p.IsSuccessful
                }) 
                : null;
        }

        public IEnumerable<ProjectViewModel> WideSearch(WideSearchViewModel model)
        {
            string category = model.Category.ToEngName();
            
            IEnumerable<DataAccess.Entities.Project> fromCategory = model.Category == "Любая" ? data.Projects.Find(p => p.ProjectState == DataAccess.Entities.Enums.ProjectState.Approved) : data.Projects.Find(p => p.Category.Title == category && p.ProjectState == DataAccess.Entities.Enums.ProjectState.Approved);
            IEnumerable<DataAccess.Entities.Project> fromLocation = model.Location == "Любая" ? data.Projects.Find(p => p.ProjectState == DataAccess.Entities.Enums.ProjectState.Approved) : data.Projects.Find(p => p.Location == model.Location && p.ProjectState == DataAccess.Entities.Enums.ProjectState.Approved);
            IEnumerable<DataAccess.Entities.Project> fromSuccess = data.Projects.Find(p => p.ProjectState == DataAccess.Entities.Enums.ProjectState.Approved);
            if (model.IsSuccessful != "Не важно")
            {
                if (model.IsSuccessful == "Успешный")
                    fromSuccess = fromSuccess.Where(p => p.IsSuccessful == true);
                else
                    fromSuccess = fromSuccess.Where(p => p.IsSuccessful == false);
            }

            var searchResults = fromCategory.Intersect(fromLocation.Intersect(fromSuccess));

            return searchResults.Select(p => new ProjectViewModel()
            {
                Avatar = p.Avatar,
                CurrentMoney = p.CurrentMoney,
                Duration = p.Duration,
                RequiredMoney = p.RequiredMoney,
                Title = p.Title,
                ShortDescription = p.ShortDescription,
                FullDescription = p.FullDescription,
                CreationDate = p.CreationDate,
                Id = p.Id,
                UserId = p.UserId.Value,
                WasPaid = p.WasPaid,
                IsSuccessful = p.IsSuccessful
            });
        }
    }
}