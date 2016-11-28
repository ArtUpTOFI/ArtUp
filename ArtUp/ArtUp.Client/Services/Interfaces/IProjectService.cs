using ArtUp.Client.Models;
using System.Collections.Generic;

namespace ArtUp.Client.Services
{
    public interface IProjectService
    {
        IEnumerable<ProjectViewModel> GetAllProjects();

        ProjectViewModel Get(int projectId);

        IEnumerable<ProjectViewModel> GetByCategory(string categoty);

        IEnumerable<ProjectViewModel> GetBySuccess(bool isSuccess);

        IEnumerable<ProjectViewModel> GetUserProjects(int userId);
    }
}
