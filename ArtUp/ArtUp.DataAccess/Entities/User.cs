using System;
using System.Collections.Generic;

namespace ArtUp.DataAccess.Entities
{
    public class User: BaseEntity
    {
        /// <summary>
        /// User's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User's password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Date of the user's registration in system
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Flag of this user's account status
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// User's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User's surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// User's info or short description
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// User's profile picture/photo
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// User's location (city, country, etc.)
        /// </summary>
        public string Location { get; set; }

        //img ???
        //other properties???

        /// <summary>
        /// User's role in system
        /// </summary>
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

        /// <summary>
        /// Collection of user's donations
        /// </summary>
        public virtual ICollection<UserDonation> UserDonations { get; set; }

        /// <summary>
        /// Collection of user's comments
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// Collection of user's projects
        /// </summary>
        public virtual ICollection<Project> Projects { get; set; }

    }
}
