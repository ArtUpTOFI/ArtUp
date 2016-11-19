using ArtUp.WebApi.Models;
using ArtUp.WebApi.Services.Instances;
using ArtUp.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArtUp.WebApi.Controllers
{
    public class CategoryController : ApiController
    {
        ICategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        [HttpGet]
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return _categoryService.GetCategories();
        }
    }
}
