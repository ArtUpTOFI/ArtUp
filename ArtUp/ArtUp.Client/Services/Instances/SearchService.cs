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
    }
}