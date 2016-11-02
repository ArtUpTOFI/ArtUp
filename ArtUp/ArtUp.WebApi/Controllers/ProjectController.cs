using ArtUp.WebApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ArtUp.WebApi.Controllers
{
    public class ProjectController : ApiController
    {
        ProjectService _projectService;

        public ProjectController()
        {
            _projectService = new ProjectService();
        }

        //api/Project/2
        public IEnumerable<string> Get(int id)
        {
            return _projectService.GetCommentsByProject(id).Select(c => c.Text).ToList();
        }
    }
}
