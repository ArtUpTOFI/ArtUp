using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class ProjectUserDonation
    {
        public ProjectViewModel Project { get; set; }

        public decimal DonationTotal { get; set; }
    }
}