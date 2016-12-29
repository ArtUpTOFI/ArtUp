using ArtUp.Client.Services.Interfaces;
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
            var results = data.Projects.Find(p => p.Title.Contains(model));
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
                    UserId = p.UserId.Value
                }) 
                : null;
        }

        public IEnumerable<ProjectViewModel> WideSearch(WideSearchViewModel model)
        {
            string category = model.Category.ToEngName();
            IEnumerable<DataAccess.Entities.Project> fromCategory = model.Category == "Любая" ? data.Projects.GetAll() : data.Projects.Find(p => p.Category.Title == category);
            IEnumerable<DataAccess.Entities.Project> fromLocation = model.Location == "Любая" ? data.Projects.GetAll() : data.Projects.Find(p => p.Location == model.Location);
            IEnumerable<DataAccess.Entities.Project> fromSuccess = model.IsSuccessful == "Не важно" ? data.Projects.GetAll() : data.Projects.Find(p => p.IsSuccessful == (model.IsSuccessful == "Успешный"));

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
                UserId = p.UserId.Value
            });
        }
    }
}