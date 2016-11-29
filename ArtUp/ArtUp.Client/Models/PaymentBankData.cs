using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtUp.Client.Models
{
    public class PaymentBankData
    {
        public PaymentCardData PaymentCardData { get; set; }

        public PaymentAccountData PaymentAccountData { get; set; }

        public byte[] AssignBytes { get; set; }

        public byte[] PublicKeyBytes { get; set; }
    }
}