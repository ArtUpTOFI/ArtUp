using System.Collections.Generic;

namespace ArtUp.DataAccess.Entities
{
    public class Category: BaseEntity
    {
        /// <summary>
        /// Title of project's category
        /// </summary>
        public string Title { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
