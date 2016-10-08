using System;
using System.Collections.Generic;

namespace ArtUp.DataAccess.Entities
{
    public class Project: BaseEntity
    {
        /// <summary>
        /// Title of the project
        /// </summary>
        public string Title { get; set; }

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

        /// <summary>
        /// Category of the project (Art, etc.)
        /// </summary>
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        /// <summary>
        /// Author of the project
        /// </summary>
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        /// <summary>
        /// Collection of gifts of this project
        /// </summary>
        public virtual ICollection<Gift> Gifts { get; set; }

        /// <summary>
        /// Collection of comments of the project
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// Colelction of user's donations for this project
        /// </summary>
        public virtual ICollection<UserDonation> UserDonations { get; set; }
    }
}
