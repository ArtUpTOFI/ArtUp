using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

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
    }
}