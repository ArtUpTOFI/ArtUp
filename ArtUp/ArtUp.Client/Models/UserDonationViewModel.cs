using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class UserDonationViewModel
    {
        public string Email { get; set; }


        public DateTime DonationDate { get; set; }

        public decimal Amount { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public int? GiftId { get; set; }

        public string CardHolder { get; set; }

        public string CardNumber { get; set; }

        public string CardDate { get; set; }

        public int CVV { get; set; }
    }
}