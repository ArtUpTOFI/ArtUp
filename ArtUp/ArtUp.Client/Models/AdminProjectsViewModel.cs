using ArtUp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class AdminProjectsViewModel
    {
        public IEnumerable<ProjectViewModel> FinishedProject { get; set; }

        public IEnumerable<ProjectViewModel> ApprovedProjects { get; set; }

        public IEnumerable<ProjectViewModel> RejectProjects { get; set; }

        public IEnumerable<ProjectViewModel> PendingProjects { get; set; }
    }
}