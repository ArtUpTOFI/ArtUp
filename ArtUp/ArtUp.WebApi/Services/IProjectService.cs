using ArtUp.DataAccess.Entities;
using System.Collections.Generic;

namespace ArtUp.WebApi.Services
{
    public interface IProjectService
    {
        IEnumerable<Comment> GetCommentsByProject(int projectId);
    }
}
