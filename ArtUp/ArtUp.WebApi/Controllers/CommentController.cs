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
    public class CommentController : ApiController
    {
        ICommentService _commentService;

        public CommentController()
        {
            _commentService = new CommentService();
        }

        [HttpGet]
        public IEnumerable<CommentViewModel> GetComments(int projectId)
        {
            return _commentService.GetComments(projectId);
        }
    }
}
