using ArtUp.WebApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;

using ArtUp.DataAccess.Entities;
using ArtUp.WebApi.Models;
using ArtUp.WebApi.Services.Instances;
using ArtUp.WebApi.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ArtUp.WebApi.Controllers
{
    public class ProjectController : ApiController
    {
        IProjectService _projectService;
        IUserManagementService _userManagementService;

        public ProjectController()
        {
            _userManagementService = new UserManagementService();
            _projectService = new ProjectService();

            Mapper.Initialize(Config);
        }

        //[System.Web.Http.Authorize]
        //api/Project/2
        [System.Web.Http.HttpGet]
        public ProjectViewModel Get(int id)
        {
            var proj = Mapper.Map<Project, ProjectViewModel>(_projectService.Get(id));
            return proj;
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<ProjectViewModel> Get()
        {
            var ps = Mapper.Map<IEnumerable<Project>, List<ProjectViewModel>>(_projectService.GetAllProjects());
            return ps;
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<ProjectViewModel> GetProjectsByCategory(string category)
        {
            var projs = Mapper.Map<IEnumerable<Project>, List<ProjectViewModel>>(_projectService.GetByCategory(category));
            return projs;
        }

        //TODO: Change type bool to json
        [System.Web.Http.HttpGet]
        public IEnumerable<ProjectViewModel> GetProjectsBySuccess(string isSuccess)
        {
            if (isSuccess.Equals("true"))
            {
                var projs =
                    Mapper.Map<IEnumerable<Project>, List<ProjectViewModel>>(_projectService.GetBySuccess(true));
                return projs;
            }
            return null;
        }

        private static void Config(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Project, ProjectViewModel>();
        }

        //[System.Web.Http.HttpGet]
        //public IEnumerable<ProjectViewModel> GetUserProject()
        //{
        //    var id = User.Identity.GetUserId();
        //    var result = Mapper.Map<IEnumerable<Project>, List<ProjectViewModel>>(_projectService.GetUserProjects(_userManagementService.GetByName(User.Identity.Name).Id));
        //    return result;
        //}
    }
}
