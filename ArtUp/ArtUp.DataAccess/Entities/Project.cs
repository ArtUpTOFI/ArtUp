using ArtUp.DataAccess.Entities.Enums;
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
        /// Main picture of the project
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Amount of collected money
        /// </summary>
        public decimal CurrentMoney { get; set; }

        /// <summary>
        /// Date when project was created
        /// </summary>
        public DateTime CreationDate { get; set; }

        public string Location { get; set; }

        /// <summary>
        /// Required amount of money for success
        /// </summary>
        public decimal RequiredMoney { get; set; }

        /// <summary>
        /// Duration of campaign to collect money
        /// </summary>
        public long Duration { get; set; }

        public byte[] Image { get; set; }

        /// <summary>
        /// Short description of the project
        /// </summary>
        public string ShortDescription { get; set; }

        public bool IsSuccessful { get; set; }

        public bool WasPaid { get; set; }

        /// <summary>
        /// Full description of the project
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// Current state of the project (draft, etc.)
        /// </summary>
        public ProjectState ProjectState { get; set; }

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

        #region Personal organizer's data
        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string DocumentType { get; set; }

        public string PasspotNumberSeries { get; set; }

        public string PersonalPassportNumber { get; set; }

        public string WhoAndWhereIssued { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string AccountNumber { get; set; }
        #endregion
    }
}
