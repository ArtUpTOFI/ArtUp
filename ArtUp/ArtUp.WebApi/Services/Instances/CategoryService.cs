using ArtUp.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.WebApi.Models;
using ArtUp.DataAccess.DataContext;

namespace ArtUp.WebApi.Services.Instances
{
    public class CategoryService : ICategoryService
    {
        ArtUpData data;

        public CategoryService()
        {
            data = new ArtUpData();
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            var allCategories = data.Categories.GetAll()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Count = c.Projects.Count()
                });

            return allCategories;
        }
    }
}