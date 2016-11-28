using ArtUp.DataAccess.Entities;
using ArtUp.WebApi.Models;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ArtUp.WebApi.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAllProjects();

        Project Get(int projectId);

        IEnumerable<Project> GetByCategory(string categoty);

        IEnumerable<Project> GetBySuccess(bool isSuccess);

        IEnumerable<Project> GetUserProjects(int userId);

        void UpdateProject(Project project);

        void CreateProject(Project project);
    }
}
