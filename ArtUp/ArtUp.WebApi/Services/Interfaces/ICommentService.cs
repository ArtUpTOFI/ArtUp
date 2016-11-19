using ArtUp.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.WebApi.Services.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentViewModel> GetComments(int projectId);
    }
}
