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
            Mapper.Initialize(Config);
            var proj = Mapper.Map<Project, ProjectViewModel>(_projectService.Get(id));
            //return _projectService.GetCommentsByProject(id).Select(c => c.Text).ToList();
            return proj;
        }

        public IEnumerable<ProjectViewModel> Get()
        {
            Mapper.Initialize(Config);
            var pr = _projectService.Get(1);
            var p = _projectService.GetAllProjects();
            var ps = Mapper.Map<IEnumerable<Project>, List<ProjectViewModel>>(_projectService.GetAllProjects());
            return ps;
        }

        private static void Config(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Project, ProjectViewModel>();
        }
    }
}
