using ArtUp.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.WebApi.Models;
using ArtUp.DataAccess.DataContext;

namespace ArtUp.WebApi.Services.Instances
{
    public class CommentService : ICommentService
    {
        ArtUpData data;

        public CommentService()
        {
            data = new ArtUpData();
        }

        public IEnumerable<CommentViewModel> GetComments(int projectId)
        {
            var comments = data.Comments.Find(c => c.ProjectId == projectId)
                .Select(c => new CommentViewModel()
                {
                    Text = c.Text,
                    Date = c.Date,
                    Author = data.Users.Get(c.UserId ?? 0).Email
                });
            return comments.OrderByDescending(c => c.Date);
        }
    }
}