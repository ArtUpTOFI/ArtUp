﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.DataAccess.DataContext;
using ArtUp.Client.Services.Interfaces;
using ArtUp.Client.Models;

namespace ArtUp.Client.Services.Instances
{
    public class CategoryService : ICategoryService
    {
        ArtUpData data;

        public CategoryService()
        {
            data = new ArtUpData();
        }

        public CategoryViewModel Get(int categoryId)
        {
            var category = data.Categories.Get(categoryId);
            return new CategoryViewModel()
            {
                Id = category.Id,
                Title = category.Title
            };
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