using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class PaymentCardData
    {
        public string CardNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CVV2 { get; set; }

        public string EndDate { get; set; }

        public float Amount { get; set; }
    }
}