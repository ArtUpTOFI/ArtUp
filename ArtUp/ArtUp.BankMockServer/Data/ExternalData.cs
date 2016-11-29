using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.BankMockServer.Data
{
    public class ExternalData
    {
        public string AccountNumber { get; set; }

        public string targetAccountNumber { get; set; }

        public float Amount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PassportNumber { get; set; }

        public string CardNumber { get; set; }

        public int CVV2 { get; set; }

        public string EndDate { get; set; }

        public byte[] ArtUpSignature { get; set; }

        public byte[] PublicArtUpKey { get; set; }
    }
}
