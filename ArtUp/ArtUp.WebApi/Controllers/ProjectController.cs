using ArtUp.WebApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;

using ArtUp.DataAccess.Entities;
using ArtUp.WebApi.Models;

namespace ArtUp.WebApi.Controllers
{
    public class ProjectController : ApiController
    {
        ProjectService _projectService;

        public ProjectController()
        {
            _projectService = new ProjectService();
            Mapper.Initialize(Config);
        }

        //api/Project/2
        public ProjectViewModel Get(int id)
        {
            var proj = Mapper.Map<Project, ProjectViewModel>(_projectService.Get(id));
            return proj;
        }

        public IEnumerable<ProjectViewModel> Get()
        {
            var ps = Mapper.Map<IEnumerable<Project>, List<ProjectViewModel>>(_projectService.GetAllProjects());
            return ps;
        }

        //TODO: Change type Category to json
        [System.Web.Http.HttpGet]
        public IEnumerable<ProjectViewModel> GetProjectsByCategory(Category category)
        {
            var projs = Mapper.Map<IEnumerable<Project>, List<ProjectViewModel>>(_projectService.GetByCategory(category));
            return projs;
        }

        //TODO: Change type bool to json
        [System.Web.Http.HttpGet]
        public IEnumerable<ProjectViewModel> GetProjectsBySuccess(bool isSuccess)
        {
            var projs = Mapper.Map<IEnumerable<Project>, List<ProjectViewModel>>(_projectService.GetBySuccess(isSuccess));
            return projs;
        }


        private static void Config(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Project, ProjectViewModel>();
        }
    }
}
