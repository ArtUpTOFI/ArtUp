using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtUp.WebApi.Models
{
    public class UserDonationViewModel
    {
        public string Email { get; set; }

        public DateTime DonationDate { get; set; }

        public decimal Amount { get; set; }
    }
}