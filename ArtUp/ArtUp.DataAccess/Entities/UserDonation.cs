using System;

namespace ArtUp.DataAccess.Entities
{
    public class UserDonation: BaseEntity
    {
        /// <summary>
        /// Amount of money to donate to project
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Date of donation
        /// </summary>
        public DateTime DonationDate { get; set; }

        /// <summary>
        /// User who donates
        /// </summary>
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        /// <summary>
        /// Project for donation
        /// </summary>
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }

        /// <summary>
        /// Gift which user chose while donated
        /// </summary>
        public int? GiftId { get; set; }
        public virtual Gift Gift { get; set; }
    }
}
