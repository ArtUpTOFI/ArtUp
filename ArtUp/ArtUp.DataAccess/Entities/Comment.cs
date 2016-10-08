using System;

namespace ArtUp.DataAccess.Entities
{
    public class Comment: BaseEntity
    {
        /// <summary>
        /// Text of the comment
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Date of publishing
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Project where this comment is located
        /// </summary>
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }

        /// <summary>
        /// Author of the comment
        /// </summary>
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
