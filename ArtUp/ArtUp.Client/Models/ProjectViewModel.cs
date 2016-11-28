using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// Main picture of the project
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Amount of collected money
        /// </summary>
        public decimal CurrentMoney { get; set; }

        /// <summary>
        /// Required amount of money for success
        /// </summary>
        public decimal RequiredMoney { get; set; }

        /// <summary>
        /// Duration of campaign to collect money
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Short description of the project
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Full description of the project
        /// </summary>
        public string FullDescription { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}