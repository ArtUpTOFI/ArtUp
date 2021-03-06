﻿using System.Collections.Generic;

namespace ArtUp.DataAccess.Entities
{
    public class Gift: BaseEntity
    {
        /// <summary>
        /// Amount of money to get this gift
        /// </summary>
        public decimal MoneyAmount { get; set; }

        /// <summary>
        /// Current count of chosen gifts
        /// </summary>
        public int CurrentCount { get; set; }

        /// <summary>
        /// Maximum available count of the gift
        /// </summary>
        public int AvailableCount { get; set; }

        /// <summary>
        /// Description of the gift
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Project where this gift is published
        /// </summary>
        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }

        /// <summary>
        /// Collection of user donation of this gift
        /// </summary>
        public virtual ICollection<UserDonation> UserDonations { get; set; }
    }
}
