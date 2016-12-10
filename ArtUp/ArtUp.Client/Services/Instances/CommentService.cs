using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtUp.DataAccess.DataContext;
using ArtUp.Client.Services.Interfaces;
using ArtUp.Client.Models;

namespace ArtUp.CLient.Services.Instances
{
    public class CommentService : ICommentService
    {
        ArtUpData data;

        public CommentService()
        {
            data = new ArtUpData();
        }

        public void CreateComment(CommentViewModel comment)
        {
            data.Comments.Create(new DataAccess.Entities.Comment()
            {
                Date = DateTime.Now,
                UserId = comment.UserId,
                ProjectId = comment.ProjectId,
                Text = comment.Text
            });
            data.SaveAll();
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