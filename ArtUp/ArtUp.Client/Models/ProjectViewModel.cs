using ArtUp.DataAccess.Entities.Enums;
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
        
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Amount of collected money
        /// </summary>
        public decimal CurrentMoney { get; set; }

        public byte[] Image { get; set; }

        /// <summary>
        /// Required amount of money for success
        /// </summary>
        public decimal RequiredMoney { get; set; }

        /// <summary>
        /// Duration of campaign to collect money
        /// </summary>
        public long Duration { get; set; }

        /// <summary>
        /// Short description of the project
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Full description of the project
        /// </summary>
        public string FullDescription { get; set; }

        public bool IsSuccessful { get; set; }

        public bool WasPaid { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Category { get; set; }

        public int UserId { get; set; }

        public ProjectState ProjectState { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DocumentType DocumentType { get; set; }

        public string PasspotNumberSeries { get; set; }

        public string PersonalPassportNumber { get; set; }

        public string WhoAndWhereIssued { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Location { get; set; }

        public string AccountNumber { get; set; }

        public GiftViewModel[] Gifts { get; set; }
    }
}