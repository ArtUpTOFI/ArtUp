using ArtUp.DataAccess.Entities;
using System.Collections.Generic;

namespace ArtUp.WebApi.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAllProjects();

        Project Get(int projectId);

        IEnumerable<Project> GetByCategory(string categoty);

        IEnumerable<Project> GetBySuccess(bool isSuccess);

        IEnumerable<Project> GetUserProjects(int userId);
    }
}
