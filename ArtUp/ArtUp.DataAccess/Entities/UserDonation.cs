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

        /// <summary>
        /// Number of an account or a card 
        /// </summary>
        public string AccountNumber { get; set; }

        ///// <summary>
        ///// Determines if this account number is a card number or not
        ///// </summary>
        //public bool IsCardNumber { get; set; }

        public string CardHolder { get; set; }

        public string CardDate { get; set; }

        public int CVV { get; set; }
    }
}
