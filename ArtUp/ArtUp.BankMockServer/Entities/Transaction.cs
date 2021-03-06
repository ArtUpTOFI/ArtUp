﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtUp.BankMockServer.Entities
{
    public class Transaction
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public string TargetAccountId { get; set; }

        public DateTime TransactionDate { get; set; }

        public float Money { get; set; }

        public string Card { get; set; }
    }
}
