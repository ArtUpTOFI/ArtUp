using System.Collections.Generic;

namespace ArtUp.DataAccess.Entities
{
    public class Role: BaseEntity
    {
        /// <summary>
        /// Name of the user's role
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
