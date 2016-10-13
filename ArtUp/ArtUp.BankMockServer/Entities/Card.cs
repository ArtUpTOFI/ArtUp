using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.BankMockServer.Entities
{
    public class Card
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CVV2 { get; set; }

        public string CreateDate { get; set; }

        public string EndDate { get; set; }

        public string BillingAdress { get; set; }

        public int? AccountId { get; set; }
    }
}
