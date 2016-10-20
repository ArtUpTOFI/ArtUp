using ArtUp.BankMockServer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.BankMockServer.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public string Nubmer { get; set; }

        public AccountType Type { get; set; }

        public FaceType FaceType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PatronomicName { get; set; }

        public string Adress { get; set; }

        public float Money { get; set; }
    }
}
